using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BERCA_TEST.DbContexts;
using BERCA_TEST.Models;
using BERCA_TEST.Models.DTOs;
using BERCA_TEST.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BERCA_TEST.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public TransactionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomer()
        {
            List<Customer> listCustomer = await _db.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDTO>>(listCustomer);
        }
    }
}
