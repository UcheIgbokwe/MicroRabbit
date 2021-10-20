using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfer.Domain.Models
{
    public class TransferLog
    {
        public int Id { get; set; }
        public int Source { get; set; }
        public int Destination { get; set; }
        public decimal Amount { get; set; }
    }
}