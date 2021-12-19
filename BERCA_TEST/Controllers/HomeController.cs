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
    }
}
