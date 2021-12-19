using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BERCA_TEST.Models.DTOs;

namespace BERCA_TEST.Repositories.IRepository
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomer();
    }
}
