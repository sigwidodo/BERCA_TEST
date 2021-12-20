using System;
namespace BERCA_TEST.Models.DTOs
{
    public class CurrencyDTO
    {
        public CurrencyDTO()
        {
        }

        public string Currency1 { get; set; }
        public string EffectiveDate { get; set; }
        public decimal? Rate { get; set; }
    }
}
