using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using OneTimePassword.Api.Models;
using OtpNet;

namespace OneTimePassword.Api.Controllers
{
    [ApiController]
    [Route("api/v1/totp")]
    public class TotpController : ControllerBase
    {
        private readonly ILogger<TotpController> _logger;
        private readonly IMemoryCache _cache;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   logger:
        //     The logger param.
        //
        //   cache:
        //     The cache param.
        //
        public TotpController(ILogger<TotpController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        //
        // Summary:
        //     /// Method responsible for action: New (POST). ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        [HttpPost("new")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResultNewTotp), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ResultNewTotp> New(RequestNewTotp command)
        {
            _logger.LogInformation("Request: [new token]");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            byte[] bytes = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");

            Totp totp = new Totp(bytes);

            string result = totp.ComputeTotp();

            _logger.LogInformation("Request: [generate new token]");

            return new ResultNewTotp() { Token = result };
        }

        //
        // Summary:
        //     /// Method responsible for action: Valiate (POST). ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        [HttpPost("validate")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResultValidateTotp), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ResultValidateTotp> Validate(RequestValidateTotp command)
        {
            _logger.LogInformation("Request: [new token]");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            byte[] bytes = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");

            Totp totp = new Totp(bytes);

            long timeStepMatched;

            bool verify = totp.VerifyTotp(command.Token, out timeStepMatched, window: new VerificationWindow(previous: 1, future: 1));

            _logger.LogInformation("Request: [validate token]");

            return new ResultValidateTotp() { TimeStepMatched = timeStepMatched, RemainingSeconds = totp.RemainingSeconds(), Verify = verify };
        }
    }
}
