using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // Static in-memory balance — shared across all requests for the lifetime of the app
        private static decimal _balance = 1000m;

        // GET api/account/balance
        [HttpGet("balance")]
        public ActionResult<decimal> GetBalance()
        {
            return Ok(_balance);
        }

        // POST api/account/deposit
        [HttpPost("deposit")]
        public ActionResult<decimal> Deposit([FromBody] decimal amount)
        {
            if (amount <= 0)
                return BadRequest("Deposit amount must be positive.");

            _balance += amount;
            return Ok(_balance);
        }

        // POST api/account/withdraw
        [HttpPost("withdraw")]
        public ActionResult<decimal> Withdraw([FromBody] decimal amount)
        {
            if (amount <= 0)
                return BadRequest("Withdrawal amount must be positive.");
            _balance -= amount;

            return Ok(_balance);
        }
    }
}