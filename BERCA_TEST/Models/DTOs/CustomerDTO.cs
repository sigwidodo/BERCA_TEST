using System;
namespace BERCA_TEST.Models.DTOs
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? Topdays { get; set; }
    }
}
