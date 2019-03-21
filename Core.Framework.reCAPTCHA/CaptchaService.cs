using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Core.Framework.reCAPTCHA
{
    public class CaptchaService : ICaptchaService
    {
        const string captchaURI =
            "https://www.google.com/recaptcha/api/siteverify";

        readonly HttpClient _httpClient;
        readonly CaptchaSettings _settings;

        public CaptchaService(CaptchaSettings settings)
        {
            _httpClient = new HttpClient();
            _settings = settings;
        }

        public CaptchaService(IConfigurationSection configurationSection)
            : this(new CaptchaSettings())
        {
            new ConfigureFromConfigurationOptions<CaptchaSettings>(
                configurationSection).Configure(_settings);
        }

        public CaptchaService(string siteKey, string secretKey)
            : this(new CaptchaSettings { SiteKey = siteKey, SecretKey = secretKey })
        { }

        public async Task<CaptchaResponse> Validate(string token, string hostname = null, bool antiForgery = true, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(token)) throw new ValidationException("Invalid token.");

            // get the response from Google's endpoint
            var jsonResponse = await _httpClient.GetStringAsync(
                $"{captchaURI}?secret={_settings.SecretKey}&response={token}");
            // de-serialize it into custom response
            var response = JsonConvert.DeserializeObject<CaptchaResponse>(jsonResponse, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            // validate hostname if anti forgery is active
            if (response.Success && antiForgery &&
                !string.IsNullOrEmpty(hostname) && response.Hostname.ToLower() != hostname.ToLower())
                throw new ValidationException("Captcha hostname and request hostname do not match. Please review anti forgery settings.");

            return response;
        }
    }
}
