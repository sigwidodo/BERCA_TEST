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
        public string Rate { get; set; }
        public string CollectionAmmountIdr { get; set; }
        public string CollectionAmmountForeign { get; set; }

        public virtual Invoice InvoiceNoNavigation { get; set; }
    }
}
