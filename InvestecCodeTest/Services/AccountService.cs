using InvestecCodeTest.Contracts;
using InvestecCodeTest.Extensions;
using InvestecCodeTest.Models;
using InvestecCodeTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestecCodeTest.Services
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountBalanceRepository _accountBalanceRepository;

        public AccountService(
            IAccountRepository accountRepository,
            IAccountBalanceRepository accountBalanceRepository)
        {
            _accountRepository = accountRepository;
            _accountBalanceRepository = accountBalanceRepository;
        }
        public List<Account> SearchAccounts(AccountSearchRequest request)
        {
           var allAccounts= _accountRepository.GetAccounts();

            try
            {
                var searchedAccounts = allAccounts.Where(i =>(!string.IsNullOrEmpty(i.Name) &&i.Name.ToLower().Contains(request.AccountName.ToLower())) &&
                (!string.IsNullOrEmpty(i.Number)&&
                i.Number.ToLower().Contains(request.AccountNumber.ToLower()))).ToList();
                return searchedAccounts;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }


        public List<AccountBalanceViewModel> GetAllAccountBalances()
        {
            var allAccounts = _accountRepository.GetAccounts();
            var allAccountBalances = _accountBalanceRepository.GetAccountBalances().GroupBy(i=>i.Id).Select(j=>new AccountBalance {
                 Id=j.Key,
                 Balance=j.Sum(i=>i.Balance),
                 Overdraft=j.Sum(i=>i.Overdraft)
            });

            
            var result = allAccounts.Where(x=> allAccountBalances.Select(y=>y.Id).Contains(x.Id)).Select(x => new AccountBalanceViewModel
            {
                AccountNumber = "xxx"+x.Number?.GetLast(4),
                Balance = allAccountBalances.SingleOrDefault(z=>z.Id==x.Id).Balance
            });
            return result.ToList();
        }

    }
}
