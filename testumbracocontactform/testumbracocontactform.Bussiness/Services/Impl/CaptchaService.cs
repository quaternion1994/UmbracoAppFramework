using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace testumbracocontactform.Bussiness.Services.Impl
{
    public class CaptchaService : ICaptchaService
    {
        private const string secretCode = "6Lf4Qj0UAAAAAK7v8I83IuRaTdgCN5k4SJyMvaHa";

        public bool ValidateCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return false;

            var client = new WebClient();

            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretCode, code));
            dynamic obj = JObject.Parse(result);
            return obj.success;
        }
    }
}
