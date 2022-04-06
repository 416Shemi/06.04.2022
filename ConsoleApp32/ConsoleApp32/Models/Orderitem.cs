using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp32.Models
{
    class Orderitem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
    }
}
