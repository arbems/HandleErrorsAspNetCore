using CustomProblemDetails;
using Microsoft.AspNetCore.Mvc;

namespace HandleErrorsAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        // /api/divide/1/2
        [HttpGet("divide/{Numerator}/{Denominator}")]
        public IActionResult Divide(double Numerator, double Denominator)
        {
            if (Denominator == 0)
            {
                var errorType = new MathErrorFeature
                {
                    MathError = MathErrorType.DivisionByZeroError
                };
                HttpContext.Features.Set(errorType);
                return BadRequest();
            }

            return Ok(Numerator / Denominator);
        }

        // /api/squareroot/4
        [HttpGet("squareroot/{radicand}")]
        public IActionResult Squareroot(double radicand)
        {
            if (radicand < 0)
            {
                var errorType = new MathErrorFeature
                {
                    MathError = MathErrorType.NegativeRadicandError
                };
                HttpContext.Features.Set(errorType);
                return BadRequest();
            }

            return Ok(Math.Sqrt(radicand));
        }
    }
}
