using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Order_Accounting_System
{
    public class CustomersReader : BaseModelReader
    {
        public CustomersReader(string filename) : base(filename)
        {
        }

        public IEnumerable<Customer> ReadAll()
        {
            if (IsOpened) Close();
            Customer c;
            while ((c = ReadNext()) != null)
                yield return c;
        }

        public Customer ReadNext()
        {
            if (!IsOpened) Open();
            var s = ReadLine();
            if (s == null)
                return null;
            return JsonSerializer.Deserialize<Customer>(s);
        }
    }
}
