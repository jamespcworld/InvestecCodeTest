using InvestecCodeTest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestecCodeTest.Repositories
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
    }
}
