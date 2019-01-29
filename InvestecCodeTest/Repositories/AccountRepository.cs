using InvestecCodeTest.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InvestecCodeTest.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            using (StreamReader file = File.OpenText(@"accounts.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                 accounts = (List<Account>)serializer.Deserialize(file, typeof(List<Account>));
            }
            return accounts;
        }
    }
}
