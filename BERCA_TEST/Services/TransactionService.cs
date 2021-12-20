using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BERCA_TEST.Models.DTOs;
using BERCA_TEST.Repositories.IRepository;
using BERCA_TEST.Services.IService;

namespace BERCA_TEST.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<bool> DeleteCollection(int? id)
        {
            return await _transactionRepository.DeleteCollection(id);
        }

        public async Task<IEnumerable<string>> GetAllCurrency()
        {
            return await _transactionRepository.GetAllCurrency();
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomer()
        {
            return await _transactionRepository.GetAllCustomer();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoice(string customerName, string invoiceNo)
        {
            return await _transactionRepository.GetAllInvoice(customerName, invoiceNo);
        }

        public async Task<string> GetCurrencyRate(string id)
        {
            return await _transactionRepository.GetCurrencyRate(id);
        }

        public async Task<InvoiceDTO> GetDetailInvoice(string id)
        {
            return await _transactionRepository.GetDetailInvoice(id);
        }

        public async Task<InvoiceDTO> GetInvoiceInfo(string id)
        {
            return await _transactionRepository.GetInvoiceInfo(id);
        }

        public async Task<IEnumerable<CollectionDTO>> GetListCollection(string id)
        {
            return await _transactionRepository.GetListCollection(id);
        }

        public async Task<bool> SetInActiveInvoice(string id)
        {
            return await _transactionRepository.SetInActiveInvoice(id);
        }

        public async Task<bool> SubmitInvoice(InvoiceDTO invoiceDTO)
        {
            return await _transactionRepository.SubmitInvoice(invoiceDTO);
        }
    }
}
