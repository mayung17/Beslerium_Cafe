using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_CW.Data
{
    public class Transaction
    {
        public DateTime Timestamp { get; set; }
        public string CustomerName { get; set; }
        public List<string> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
