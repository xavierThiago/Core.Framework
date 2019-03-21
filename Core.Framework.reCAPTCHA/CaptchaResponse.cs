using System;

namespace Core.Framework.reCAPTCHA
{
    public class CaptchaResponse
    {
        public bool Success { get; set; }
        public decimal Score { get; set; }
        public string Action { get; set; }
        public DateTime ChallengeTimestamp { get; set; }
        public string Hostname { get; set; }
    }
}
