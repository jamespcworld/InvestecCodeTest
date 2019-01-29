using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InvestecCodeTest.Models;
using InvestecCodeTest.Services;

namespace InvestecCodeTest.Controllers
{
    [Route("accounts")]
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("search")]
        public IActionResult SearchAccounts(AccountSearchRequest request)
        {
            if (this.ModelState.IsValid)
            {
              var accounts=  _accountService.SearchAccounts(request);
                return Ok(accounts);
            }
             return BadRequest(ModelState);
        }

        [HttpGet("~/accounts/balances")]
        public IActionResult GetAllAccountBalances()
        {
            var accountBalances = _accountService.GetAllAccountBalances();
            return Ok(accountBalances);
        }
    }
}
