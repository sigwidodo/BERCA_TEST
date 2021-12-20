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
        public string CustomerName { get; set; }
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

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
    }
}
