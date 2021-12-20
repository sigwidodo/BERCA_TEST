using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BERCA_TEST.Models.DTOs;

namespace BERCA_TEST.Repositories.IRepository
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomer();
        Task<IEnumerable<string>> GetAllCurrency();
        Task<IEnumerable<InvoiceDTO>> GetAllInvoice(string customerName, string invoiceNo);
        Task<InvoiceDTO> GetInvoiceInfo(string id);
        Task<string> GetCurrencyRate(string id);
        Task<bool> SubmitInvoice(InvoiceDTO invoiceDTO);
    }
}
