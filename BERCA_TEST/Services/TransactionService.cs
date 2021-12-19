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

        public Task<IEnumerable<CustomerDTO>> GetAllCustomer()
        {
            return _transactionRepository.GetAllCustomer();
        }
    }
}
