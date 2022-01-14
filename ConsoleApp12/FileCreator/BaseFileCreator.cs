using System;
using System.Collections.Generic;
using Order_Accounting_System;
using System.IO;
using System.Text.Json;

namespace FileCreator
{
    public abstract class BaseFileCreator : IDisposable
    {
        private readonly string _fileName;
        protected FileStream _stream;

        public bool IsOpened => _stream != null;
        protected BaseFileCreator(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException(nameof(filename));
            _fileName = filename;
        }

        public void Open()
        {
            _stream = new FileStream(_fileName, FileMode.Create);
        }

        protected void Close()
        {
            if (_stream == null)
                throw new NullReferenceException(nameof(_stream));
            _stream.Dispose();
            _stream = null;
        }

        public void Dispose()
        {
            if (_stream != null)
                _stream.Dispose();
        }
    }

    public class CustomerFileCreator : BaseFileCreator
    {
        public CustomerFileCreator(string filename) : base(filename) { }

        public void WriteAll(ref List<Customer> customers)
        {
            if (!IsOpened) Open();

            using (var sw = new StreamWriter(_stream)) 
            {
                foreach (var c in customers)
                {
                    var s = JsonSerializer.Serialize(c);
                    sw.WriteLine(s);
                }
            }
        }

    }


    public class ProductFileCreator : BaseFileCreator
    {
        public ProductFileCreator(string filename) : base(filename) { }

        public void WriteAll(ref List<Product> products)
        {
            if (!IsOpened) Open();
            using (var sw = new StreamWriter(_stream))
            {
                foreach (var p in products)
                {
                    var s = JsonSerializer.Serialize(p);
                    sw.WriteLine(s);
                }
            }
        }

    }


    public class OrderFileCreator : BaseFileCreator
    {
        public OrderFileCreator(string filename) : base(filename) { }

        public void WriteAll(ref List<Order> orders)
        {
            if (!IsOpened) Open();
            using (var sw = new StreamWriter(_stream))
            {
                foreach (var r in orders)
                {
                    var s = JsonSerializer.Serialize(r);
                    sw.WriteLine(s);
                }
            }
        }

    }
}
