using System;
using System.Collections.Generic;

#nullable disable

namespace BERCA_TEST.Models
{
    public partial class Collection
    {
        public string CollectionId { get; set; }
        public string InvoiceNo { get; set; }
        public string CollectionDate { get; set; }
        public string Currency { get; set; }
        public decimal? Rate { get; set; }
        public decimal? CollectionAmmountIdr { get; set; }
        public decimal? CollectionAmmountForeign { get; set; }

        public virtual Invoice InvoiceNoNavigation { get; set; }
    }
}
