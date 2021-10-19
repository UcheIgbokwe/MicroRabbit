using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Application.Models
{
    public class AccountTransfer
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public decimal Amount { get; set; }
        
    }
}