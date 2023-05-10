using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using FPLSP_TypingContest.Server.BLL.ViewModels.Login;
using FPLSP_TypingContest.Server.BLL.Services.Implements;
using Newtonsoft.Json;
using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.User;
using FPLSP_TypingContest.Server.BLL.ViewModels.Recaptcha.Option;
using Microsoft.Extensions.Options;
using FPLSP_TypingContest.Server.BLL.ViewModels.Recaptcha.Helper;

namespace FPLSP_TypingContest.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IUserRepositories _userRepositories;
        private readonly RecaptchaOption _recaptchaOption;
        private readonly RecaptchaHelper _recaptchaHelper;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<AccountController> logger, IUserRepositories userRepositories,IOptions<RecaptchaOption> recaptchaOption)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
            _userRepositories = userRepositories;
            _recaptchaOption = recaptchaOption.Value;
            _recaptchaHelper = new RecaptchaHelper(recaptchaOption);
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        // và nhận tham số truyền vào là 
        /// <summary>
        /// Hiển thị form chọn tài khoản
        /// </summary>
        /// <param name="IdTrainingFacility">id cơ sở</param>
        /// <returns>Chuyển tới phương thức đăng nhập</returns>
        public IActionResult GoogleSignIn(Guid IdTrainingFacility)
        {
            //Lấy Request thông qua g-recaptcha-response để kiểm tra xem đã check recaptcha chưa 
            string captchaResponse = Request.Query["g-recaptcha-response"].ToString();
            var validate = _recaptchaHelper.ValidateCaptcha(captchaResponse);
            if (validate.Success)
            {                
                var properties = new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleCallback", "Account", new { IdTrainingFacility = IdTrainingFacility }),
                    Items =
                {
                    { "Scheme", "Google" }
                }
                };

                return Challenge(properties, "Google");
            }
            return RedirectToAction("Login");
            
        }

        /// <summary>
        /// Từ token lấy được thông tin người đăng nhập và lưu và csdl
        /// </summary>
        /// <param name="IdTrainingFacility">Id cơ sở được chọn</param>
        /// <returns>Chuyển tới trang chủ</returns>
        public async Task<IActionResult> GoogleCallback(Guid IdTrainingFacility)
        {
            var result = await HttpContext.AuthenticateAsync("Google");

            if (result.Succeeded)
            {
                var accessToken = result.Properties.GetTokens().FirstOrDefault(token => token.Name == "access_token")?.Value;
                var userinfo = await GetGoogleUserInfoAsync(accessToken);
                var getuser = await _userManager.FindByEmailAsync(userinfo.Email);
                if (getuser == null && userinfo.HostedDomain == "fpt.edu.vn")
                {
                    //Tạo mới user bên identity
                    IdentityUser identityUser = new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = userinfo.Email,
                        UserName = userinfo.Email.Split("@")[0],
                    };
                    await _userManager.CreateAsync(identityUser);
                    getuser = await _userManager.FindByEmailAsync(userinfo.Email);
                }
                
                var roles = await _userManager.GetRolesAsync(getuser);
                //Kiểm tra nếu không có quyền gì thì mặc định thêm quyền PARTICIPANT
                if (roles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(getuser, "PARTICIPANT");
                }
                var claims = new List<Claim>();
                roles = await _userManager.GetRolesAsync(getuser);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Xác thực thông tin đăng nhập
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                var User = await _userRepositories.GetAllActiveAsync();
                var checkUser = User.FirstOrDefault(c => c.Email == userinfo.Email);

                if (getuser != null)
                {
                    if (checkUser == null)
                    {
                        UserCreateVM user = new UserCreateVM()
                        {
                            Id = Guid.Parse(getuser.Id),
                            Email = userinfo.Email,
                            Status = 0,
                            CreateBy = Guid.Parse(getuser.Id),
                            IdFacility = IdTrainingFacility
                        };
                        //Tạo mới user bên bảng User
                        await _userRepositories.AddAsync(user);
                    }
                    else
                    {
                        if (checkUser.IdTrainingFacility != IdTrainingFacility && !roles.Any(c=>c == "ADMIN"))
                        {
                            return RedirectToAction("Login");
                        }
                    }                   

                    HttpContext.Session.SetObject("UserLogin", userinfo);//Lưu thông tin của tài khoản đang đăng nhập vào session

                    UserVM userVM = new UserVM()
                    {
                        Id = Guid.Parse(getuser.Id),
                        IdTrainingFacility = checkUser.IdTrainingFacility
                    };
                    HttpContext.Session.SetObject("user", userVM);//Lưu iduser
                    return RedirectToPage("/_Host");

                }
            }
            return RedirectToAction("Login");
        }
        /// <summary>
        /// Từ token được truyền vào lấy ra được thông tin người đăng nhập
        /// </summary>
        /// <param name="accessToken">token</param>
        /// <returns>Thông tin người đăng nhập</returns>
        private async Task<GoogleUserInfoVM> GetGoogleUserInfoAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync("https://www.googleapis.com/oauth2/v2/userinfo");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var userinfo = JsonConvert.DeserializeObject<GoogleUserInfoVM>(json);

            return userinfo;
        }

    }
}
