using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Order_Accounting_System
{
    public class OrdersReader : BaseModelReader
    {
        public OrdersReader(string filename) : base(filename)
        {
        }

        public IEnumerable<Order> ReadAll()
        {
            if (IsOpened) Close();
            Order c;
            while ((c = ReadNext()) != null)
                yield return c;
        }

        public Order ReadNext()
        {
            if (!IsOpened) Open();
            var s = ReadLine();
            if (s == null)
                return null;
            return JsonSerializer.Deserialize<Order>(s);
        }
    }
}
