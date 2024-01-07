using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_CW.Data
{
    public class customer
    {
        public string Username { get; set; }
        public string NFCId { get; set; }
        public MembershipLevel MembershipLevel { get; set; }
        public int PurchaseCount { get; set; }
    }
}
