using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorApp
{
    public class Product
    {
        public string? Name { get; set; }
        public double Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
