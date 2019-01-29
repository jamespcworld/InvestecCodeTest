using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestecCodeTest.Contracts
{
    public class AccountBalance
    {
        public int Id { get; set; }
        public decimal? Balance{ get; set; }
        public decimal? Overdraft { get; set; }
    }
}
