using FPLSP_TypingContest.Server.BLL.ViewModels.Recaptcha.Option;
using FPLSP_TypingContest.Server.BLL.ViewModels.Recaptcha.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.Recaptcha.Helper
{
    public class RecaptchaHelper
    {
        private readonly RecaptchaOption _option;

        public RecaptchaHelper(IOptions<RecaptchaOption> option)
        {
            _option = option.Value;
        }
        /// <summary>
        /// Kiểm tra xem ValidateCaptcha được chuyền xuống thông qua key
        /// </summary>
        /// <param name="response">key</param>
        /// <returns>Thông qua SecretKey và Url kiểm tra, Success khi đã checkes và ErrorMessages khi có lỗi xảy ra </returns>
        public RecaptchaResponse ValidateCaptcha(string response)
        {
            using (var client = new WebClient())
            {
                string secret = _option.SecretKey;
                string url = $"{_option.Url}secret={secret}&response={response}";
                var result = client.DownloadString(url);

                try
                {
                    var data = JsonConvert.DeserializeObject<RecaptchaResponse>(result.ToString());

                    return data;
                }
                catch (Exception)
                {
                    return default(RecaptchaResponse);
                }
            }

        }
    }
}
