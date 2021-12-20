using System;
using System.Collections.Generic;

#nullable disable

namespace BERCA_TEST.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? Topdays { get; set; }
    }
}
