using Blazored.Toast;
using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Repositories.Services;
using FPLSP_TypingContest.Server.DAL.ApplicationDbContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using FPLSP_TypingContest.Server.BLL.ViewModels.Recaptcha.Option;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FPLSP_IdentityDbContext>(options => options.UseSqlServer("Data Source=66.42.55.38;Initial Catalog=FPLSP_TypingContest;User ID=test;Password=E=lPJeY>-g/9QxzE;MultipleActiveResultSets=true"));

// Đọc cấu hình từ file appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.Configure<RecaptchaOption>(builder.Configuration.GetSection(nameof(RecaptchaOption))); 
builder.Services.AddSession(options =>
{
    // Configure session options here
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//AddTransient ở đây
builder.Services.AddTransient<IUserRepositories, UserRepositories>();
builder.Services.AddTransient<ITrainingFacilitysRepositories, TrainingFacilitysRepositories>();
builder.Services.AddTransient<IContentForRoundRepositories, ContentForRoundRepositories>();
builder.Services.AddTransient<IScoreOfParticipantRepositories, ScoreOfParticipantRepositories>();
builder.Services.AddTransient<ILevelRespositories, LevelRespositories>();
builder.Services.AddTransient<ITextTemplateRespositories, TextTemplateRespositories>();
builder.Services.AddTransient<IUserIdentityRespositories, UserIdentityRespositories>();


//Kết nối client với backendapi qua cổng BackEndAPIURL
builder.Services.AddHttpClient("examapi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BackEndAPIURL"]);
});


builder.Services.AddScoped(api => new HttpClient { BaseAddress = new Uri(builder.Configuration["BackEndAPIURL"]) });

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<FPLSP_IdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}
)
    //.AddOpenIdConnect("oidc", options =>
    //{
    //    // Thiết lập các thông tin đăng xuất
    //    options.SignedOutCallbackPath = "/signout-callback-oidc";
    //    options.SignOutScheme = "Cookies";
    //    options.RemoteSignOutPath = "/signout-google";
    //    options.SignedOutRedirectUri = "/";
    //})

    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "CookieForTruong";
        options.LoginPath = "/Account/Login";
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Thiết lập chính sách bảo mật
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Thiết lập thời gian sống của cookie
        options.SlidingExpiration = true; // Cho phép cookie được cập nhật thời gian sống mỗi khi có request mới
        options.Cookie.HttpOnly = true;
    })
       .AddGoogle(options =>
       {
           IConfigurationSection googleAuthNSection =
           builder.Configuration.GetSection("Authentication:Google");
           options.ClientId = googleAuthNSection["ClientId"];
           options.ClientSecret = googleAuthNSection["ClientSecret"];
           options.AuthorizationEndpoint += "?prompt=consent"; // thêm prompt consent để yêu cầu xác thực người dùng
           options.AccessType = "offline"; // yêu cầu truy cập offline để có thể lấy refresh token
           options.SaveTokens = true;
       });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => { policy.RequireAuthenticatedUser(); policy.RequireRole("ADMIN"); });
    options.AddPolicy("FacilityAdmin", policy => { policy.RequireAuthenticatedUser(); policy.RequireRole("FACILITYADMIN"); });
    options.AddPolicy("Organizer", policy => { policy.RequireAuthenticatedUser(); policy.RequireRole("ORGANIZER"); });
    options.AddPolicy("Participant", policy => { policy.RequireAuthenticatedUser(); policy.RequireRole("PARTICIPANT"); });
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");//Trang bắt đầu sau Layout

app.Run();
