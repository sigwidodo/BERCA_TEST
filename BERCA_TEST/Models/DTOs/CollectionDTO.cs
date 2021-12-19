using System;
namespace BERCA_TEST.Models.DTOs
{
    public class CollectionDTO
    {
        public CollectionDTO()
        {
        }

        public string CollectionId { get; set; }
        public string InvoiceNo { get; set; }
        public string CollectionDate { get; set; }
        public string Currency { get; set; }
        public string Rate { get; set; }
        public string CollectionAmmountIdr { get; set; }
        public string CollectionAmmountForeign { get; set; }
    }
}
