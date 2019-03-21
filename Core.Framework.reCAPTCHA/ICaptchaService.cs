using System.Threading;
using System.Threading.Tasks;

namespace Core.Framework.reCAPTCHA
{
    public interface ICaptchaService
    {
        Task<CaptchaResponse> Validate(string token, string hostname = null, bool antiForgery = true, CancellationToken cancellationToken = default);
    }
}
