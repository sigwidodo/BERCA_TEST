using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BERCA_TEST.DbContexts;
using BERCA_TEST.Models;
using BERCA_TEST.Models.DTOs;
using BERCA_TEST.Repositories.IRepository;
using Microsoft.Data.SqlClient;
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

        public async Task<IEnumerable<string>> GetAllCurrency()
        {
            List<string> listCurrency = await _db.Currencies.Select(m => m.Currency1).Distinct().ToListAsync();
            return listCurrency;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomer()
        {
            List<Customer> listCustomer = await _db.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDTO>>(listCustomer);
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoice(string customerName, string invoiceNo)
        {
            List<Invoice> listInvoice = new List<Invoice>();

            using (var cmd = _db.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "sp_v_invoice";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customer_name", customerName));
                cmd.Parameters.Add(new SqlParameter("@invoice_no", invoiceNo));
                await _db.Database.OpenConnectionAsync();
                using (var result = cmd.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(result);

                        foreach (DataRow dr in dt.Rows)
                        {
                            Invoice invoice = new Invoice();
                            invoice.CustomerId = int.Parse(dr["customer_id"].ToString());
                            invoice.Currency = dr["currency"].ToString();
                            invoice.CustomerName = dr["customer_name"].ToString();
                            invoice.DueDate = dr["due_date"].ToString();
                            invoice.InvoiceAmmountForeign = dr["invoice_ammount_foreign"].ToString();
                            invoice.InvoiceAmmountIdr = dr["invoice_ammount_idr"].ToString();
                            invoice.InvoiceDate = dr["invoice_date"].ToString();
                            invoice.InvoiceNo = dr["invoice_no"].ToString();
                            invoice.IsActive = int.Parse(dr["status"].ToString());
                            invoice.OpenAmmountForeign = dr["open_ammount_foreign"].ToString();
                            invoice.OpenAmmountIdr = dr["open_ammount_idr"].ToString();
                            invoice.Rate = dr["rate"].ToString();
                            invoice.Remark = dr["remark"].ToString();
                            listInvoice.Add(invoice);

                        }
                    }
                }

                return _mapper.Map<List<InvoiceDTO>>(listInvoice);
            }
        }

        public async Task<InvoiceDTO> GetInvoiceInfo(string id)
        {
            Invoice invoice = new Invoice();

            using (var cmd = _db.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "sp_set_invoice_info";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customer_id", int.Parse(id)));
                await _db.Database.OpenConnectionAsync();
                using (var result = cmd.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(result);

                        foreach (DataRow dr in dt.Rows)
                        {
                            invoice = new Invoice();
                            invoice.DueDate = dr["due_date"].ToString();
                            invoice.InvoiceNo = dr["invoice_no"].ToString();

                        }
                    }
                }

                return _mapper.Map<InvoiceDTO>(invoice);
            }
        }

        public async Task<string> GetCurrencyRate(string id)
        {
            string rate = "";

            using (var cmd = _db.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "sp_get_currency_info";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@currency", id));
                await _db.Database.OpenConnectionAsync();
                using (var result = cmd.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(result);

                        foreach (DataRow dr in dt.Rows)
                        {
                            rate = dr["rate"].ToString();
                        }
                    }
                }

                return rate;
            }
        }
    }
}
