using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FußballBestellung
{
    public class PayPal
    {
        public string Mail { get; set; }
    }
    public class BankAccount
    {
        public string BIC { get; set; }
        public string IBAN { get; set; }
        public string AccountName { get; set; }
    }
}
