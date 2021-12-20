using System;
using System.Collections.Generic;

#nullable disable

namespace BERCA_TEST.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Collections = new HashSet<Collection>();
        }

        public string InvoiceNo { get; set; }
        public int? CustomerId { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
        public string Currency { get; set; }
        public decimal? Rate { get; set; }
        public decimal? InvoiceAmmountIdr { get; set; }
        public decimal? OpenAmmountIdr { get; set; }
        public decimal? InvoiceAmmountForeign { get; set; }
        public decimal? OpenAmmountForeign { get; set; }
        public string Remark { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
    }
}
