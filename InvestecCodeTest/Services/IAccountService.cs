using InvestecCodeTest.Contracts;
using InvestecCodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestecCodeTest.Services
{
    public interface IAccountService
    {
        List<Account> SearchAccounts(AccountSearchRequest accountSearchRequest);
        List<AccountBalanceViewModel> GetAllAccountBalances();
    }
}
