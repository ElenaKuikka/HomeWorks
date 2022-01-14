using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace Order_Accounting_System
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Customer() { }
        public Customer(Guid id, string name, string phone, string email)
        {
            Id = id;
            Name = name;

            if (IsCorrectPhone(phone))
                Phone = PhoneWithoutSymbols(phone);
            else throw new ArgumentException(nameof(phone));

            if (IsCorrectEmail(email))
                Email = email;
            else throw new ArgumentException(nameof(email));
        }

        private bool IsCorrectEmail(string email) {
            var rx = new Regex(@"^[a-zA-Z0-9\.\-]+@[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,6}$", RegexOptions.None);
            return rx.IsMatch(email);
        }

        private bool IsCorrectPhone(string phone)
        {
            var rx = new Regex(@"[0-9\s\-\+()]{5,20}", RegexOptions.None);
            return rx.IsMatch(phone);
        }

        private string PhoneWithoutSymbols(string phone)
        {
            Regex rg = new Regex(@"\D");
            return rg.Replace(phone, "");
        }
    }
}
