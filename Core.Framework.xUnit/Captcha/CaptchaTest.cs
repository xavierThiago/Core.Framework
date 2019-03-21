using Core.Framework.reCAPTCHA;
using Xunit;

namespace Core.Framework.xUnit.Captcha
{
    public class CaptchaTest
    {
        [Fact]
        public void ValidateCaptcha()
        {
            // Arrange
            var siteKey = "";
            var secretKey = "";
            //var token = "";
            CaptchaSettings settings =
                new CaptchaSettings
                {
                    SiteKey = siteKey,
                    SecretKey = secretKey
                };
            ICaptchaService service =
                new CaptchaService(settings);
            // Act
            //CaptchaResponse response =
            //service.Validate(token).ConfigureAwait(false)
            //.GetAwaiter()
            //.GetResult();
            // Assert
            //Assert.NotNull(response);
            //Assert.True(response.Success);
        }
    }
}
