using System;

namespace OneTimePassword.Api.Models
{
    public class ResultValidateTotp
    {
        public long TimeStepMatched { get; set; }

        public int RemainingSeconds { get; set; }

        public bool Verify { get; set; }
    }
}
