using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FußballBestellung
{
    public class Customer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int Postal { get; set; }
        public string City { get; set; }
        public string chosenPayment { get; set; }
        public PayPal Paypal { get; set; }
        public BankAccount BankAccount { get; set; }

        public Customer(string lastName, string firstName, string phone, string street, int houseNumber, int postal, string city)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Phone = phone;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.Postal = postal;
            this.City = city;
        }

    }
}
