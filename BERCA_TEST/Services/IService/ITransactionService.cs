using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BERCA_TEST.Models.DTOs;

namespace BERCA_TEST.Services.IService
{
    public interface ITransactionService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomer();
    }
}
