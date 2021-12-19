using System;
namespace BERCA_TEST.Models.DTOs
{
    public class InvoiceDTO
    {
        public InvoiceDTO()
        {
        }

        public string InvoiceNo { get; set; }
        public int? CustomerId { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
        public string Currency { get; set; }
        public string Rate { get; set; }
        public string InvoiceAmmountIdr { get; set; }
        public string OpenAmmountIdr { get; set; }
        public string InvoiceAmmountForeign { get; set; }
        public string OpenAmmountForeign { get; set; }
        public string Remark { get; set; }
        public int? IsActive { get; set; }
    }
}
