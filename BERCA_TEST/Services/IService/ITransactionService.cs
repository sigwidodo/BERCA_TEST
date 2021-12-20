using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BERCA_TEST.Models.DTOs;

namespace BERCA_TEST.Services.IService
{
    public interface ITransactionService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomer();
        Task<IEnumerable<string>> GetAllCurrency();
        Task<string> GetCurrencyRate(string id);
        Task<IEnumerable<InvoiceDTO>> GetAllInvoice(string customerName, string invoiceNo);
        Task<InvoiceDTO> GetInvoiceInfo(string id);
        Task<InvoiceDTO> GetDetailInvoice(string id);
        Task<bool> SubmitInvoice(InvoiceDTO invoiceDTO);
        Task<bool> SetInActiveInvoice(string id);
        Task<bool> DeleteCollection (int? id);
        Task<IEnumerable<CollectionDTO>> GetListCollection(string id);
    }
}
