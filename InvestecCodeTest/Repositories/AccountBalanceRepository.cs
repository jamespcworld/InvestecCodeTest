using InvestecCodeTest.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InvestecCodeTest.Repositories
{
    public class AccountBalanceRepository:IAccountBalanceRepository
    {

        public List<AccountBalance> GetAccountBalances()
        {
            List<AccountBalance> accountBalances = new List<AccountBalance>();

            using (StreamReader file = File.OpenText(@"accountbalances.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                accountBalances = (List<AccountBalance>)serializer.Deserialize(file, typeof(List<AccountBalance>));
            }
            return accountBalances;
        }
    }
}
