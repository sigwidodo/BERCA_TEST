using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
            List<InvoiceDTO> listInvoice = new List<InvoiceDTO>();

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
                            InvoiceDTO invoice = new InvoiceDTO();
                            invoice.CustomerId = int.Parse(dr["customer_id"].ToString());
                            invoice.Currency = dr["currency"].ToString();
                            invoice.CustomerName = dr["customer_name"].ToString();
                            invoice.DueDate = dr["due_date"].ToString();
                            invoice.InvoiceAmmountForeign = dr["invoice_ammount_foreign"].ToString().Replace("," ,".");
                            invoice.InvoiceAmmountIdr = dr["invoice_ammount_idr"].ToString().Replace(",", ".");
                            invoice.InvoiceDate = dr["invoice_date"].ToString();
                            invoice.InvoiceNo = dr["invoice_no"].ToString();
                            invoice.IsActive = int.Parse(dr["status"].ToString());
                            invoice.OpenAmmountForeign = dr["open_ammount_foreign"].ToString().Replace(",", ".");
                            invoice.OpenAmmountIdr = dr["open_ammount_idr"].ToString().Replace(",", ".");
                            invoice.Rate = dr["rate"].ToString().Replace(",", ".");
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
                            invoice.InvoiceDate = dr["invoice_date"].ToString();
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

        public async Task<bool> SubmitInvoice(InvoiceDTO invoiceDTO)
        {
            Invoice invoice = new Invoice();
            try
            {
                if (invoiceDTO.InvoiceDate != null)
                {
                    String newDate = invoiceDTO.InvoiceDate.Substring(0, 2);
                    String newMonth = invoiceDTO.InvoiceDate.Substring(3, 2);
                    String newYear = invoiceDTO.InvoiceDate.Substring(6, 4);
                    invoice.InvoiceDate = newDate + "-" + newMonth + "-" + newYear;
                }

                if (invoiceDTO.DueDate != null)
                {
                    String newDate = invoiceDTO.DueDate.Substring(0, 2);
                    String newMonth = invoiceDTO.DueDate.Substring(3, 2);
                    String newYear = invoiceDTO.DueDate.Substring(6, 4);
                    invoice.DueDate = newDate + "-" + newMonth + "-" + newYear;
                }

                if (invoiceDTO.Currency.Equals("USD"))
                {
                    string invoiceIdr = invoiceDTO.InvoiceAmmountForeign.Replace(",", "");
                    string rate = invoiceDTO.Rate.Replace(",", "");
                    CultureInfo culture = new CultureInfo("en-US");
                    invoice.InvoiceAmmountIdr =  (Convert.ToDecimal(invoiceIdr, culture) * Convert.ToDecimal(rate, culture));
                    decimal result = Convert.ToDecimal(invoiceIdr, culture);
                    invoice.InvoiceAmmountForeign = result;
                    invoice.OpenAmmountForeign = result;
                    invoice.OpenAmmountIdr = invoice.InvoiceAmmountIdr;
                }
                else
                {
                    string invoiceIdr = invoiceDTO.InvoiceAmmountIdr.Replace(",", "");
                    string rate = invoiceDTO.Rate.Replace(",", "");
                    invoice.InvoiceAmmountIdr = (int.Parse(invoiceIdr) * int.Parse(rate));
                    invoice.InvoiceAmmountForeign = 0;
                    invoice.OpenAmmountForeign = invoice.InvoiceAmmountForeign;
                    invoice.OpenAmmountIdr = invoice.InvoiceAmmountIdr;
                }

                invoice.CustomerId = invoiceDTO.CustomerId;
                invoice.Currency = invoiceDTO.Currency;
                invoice.InvoiceNo = invoiceDTO.InvoiceNo;
                invoice.IsActive = invoiceDTO.IsActive;
                invoice.Rate = decimal.Parse(invoiceDTO.Rate.Replace(",", ""));

                _db.Invoices.Add(invoice);
                await _db.SaveChangesAsync();
                
            }
            catch (SqlException e) {
                return false;
            }

            return true;
        }

        public async Task<InvoiceDTO> GetDetailInvoice(string id)
        {
            InvoiceDTO invoice = new InvoiceDTO();

            using (var cmd = _db.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "sp_v_detail_invoice";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@invoice_no", id));
                await _db.Database.OpenConnectionAsync();
                using (var result = cmd.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(result);

                        foreach (DataRow dr in dt.Rows)
                        {
                            invoice = new InvoiceDTO();
                            invoice.CustomerId = int.Parse(dr["customer_id"].ToString());
                            invoice.Currency = dr["currency"].ToString();
                            invoice.CustomerName = dr["customer_name"].ToString();
                            invoice.DueDate = dr["due_date"].ToString();
                            invoice.InvoiceAmmountForeign = dr["invoice_ammount_foreign"].ToString().Replace(",", ".");
                            invoice.InvoiceAmmountIdr = dr["invoice_ammount_idr"].ToString().Replace(",", ".");
                            invoice.InvoiceDate = dr["invoice_date"].ToString();
                            invoice.InvoiceNo = dr["invoice_no"].ToString();
                            invoice.IsActive = int.Parse(dr["status"].ToString());
                            invoice.OpenAmmountForeign = dr["open_ammount_foreign"].ToString().Replace(",", ".");
                            invoice.OpenAmmountIdr = dr["open_ammount_idr"].ToString().Replace(",", ".");
                            invoice.Rate = dr["rate"].ToString().Replace(",", ".");
                            invoice.Remark = dr["remark"].ToString();
                        }
                    }
                }

                return invoice;

            }
        }

        public async Task<IEnumerable<CollectionDTO>> GetListCollection(string id)
        {
            List<Collection> listCollection = await _db.Collections.Where(m => m.InvoiceNo == id).ToListAsync();
            return _mapper.Map<List<CollectionDTO>>(listCollection);
        }

        public async Task<bool> DeleteCollection(int? id)
        {
            Invoice invoice = new Invoice();
            try
            {
                using (var cmd = _db.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "sp_delete_collection";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    await _db.Database.OpenConnectionAsync();
                    cmd.ExecuteReader();
                }

            }
            catch (SqlException e)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> SetInActiveInvoice(string id)
        {
            Invoice invoice = await _db.Invoices.SingleAsync(m => m.InvoiceNo == id);
            try
            {
                invoice.IsActive = 0;

                _db.Invoices.Update(invoice);
                await _db.SaveChangesAsync();

            }
            catch (SqlException e)
            {
                return false;
            }

            return true;
        }
    }
}
