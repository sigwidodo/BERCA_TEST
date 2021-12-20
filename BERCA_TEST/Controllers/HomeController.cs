using BERCA_TEST.Models;
using BERCA_TEST.Models.DTOs;
using BERCA_TEST.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BERCA_TEST.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ITransactionService _transactionService;

        public HomeController(ITransactionService transactionService)
        {
            _transactionService = transactionService;   
        }

        public IActionResult Index()
        {
            return View();
        }

        /* GET LIST CUSTOMER */
        public async Task<JsonResult> GetListCustomer()
        {

            List<CustomerDTO> listCustomer = (List<CustomerDTO>)await _transactionService.GetAllCustomer();
            var jsonResult = Json(listCustomer);
            return jsonResult;

        }

        /* GET LIST CURRENCY */
        public async Task<JsonResult> GetListCurrency()
        {

            List<string> listCurrency = (List<string>)await _transactionService.GetAllCurrency();
            var jsonResult = Json(listCurrency);
            return jsonResult;

        }

        /* GET LIST INVOICE */
        public async Task<JsonResult> GetListInvoice(string customerName, string invoiceNo)
        {
            if (customerName == null) {
                customerName = "";
            };

            if (invoiceNo == null) {
                invoiceNo = "";
            }
            List<InvoiceDTO> listInvoice = (List<InvoiceDTO>)await _transactionService.GetAllInvoice(customerName, invoiceNo);
            var jsonResult = Json(listInvoice);
            return jsonResult;

        }

        /* GET LIST COLLECTION */
        public async Task<JsonResult> GetListCollection(string id)
        {
            List<CollectionDTO> listCollection = (List<CollectionDTO>)await _transactionService.GetListCollection(id);
            var jsonResult = Json(listCollection);
            return jsonResult;

        }

        /* SET INVOICE INFO */
        public async Task<JsonResult> SetInvoiceInfo(string id)
        {

            InvoiceDTO invoice = (InvoiceDTO)await _transactionService.GetInvoiceInfo(id);
            var jsonResult = Json(invoice);
            return jsonResult;

        }

        /* GET DETAIL INVOICE INFO */
        public async Task<JsonResult> GetDetailInvoice(string id)
        {

            InvoiceDTO invoice = (InvoiceDTO)await _transactionService.GetDetailInvoice(id);
            var jsonResult = Json(invoice);
            return jsonResult;

        }

        /* GET CURRENCY RATE */
        public async Task<JsonResult> GetCurrencyRate(string id)
        {

            var jsonResult = Json((string)await _transactionService.GetCurrencyRate(id));
            return jsonResult;

        }

        /* SUBMIT INVOICE */
        [HttpPost]
        public async Task<bool> SubmitInvoice(InvoiceDTO invoiceDTO)
        {
            try
            {
                await _transactionService.SubmitInvoice(invoiceDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;

        }

        /* DELETE COLLECTION */
        public async Task<bool> DeleteCollection(int? id)
        {
            try
            {
                await _transactionService.DeleteCollection(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;

        }

        public async Task<bool> SetInActiveInvoice(string id)
        {
            try
            {
                await _transactionService.SetInActiveInvoice(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;

        }

    }
}
