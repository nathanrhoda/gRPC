using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Api.Controllers
{
    public class WithdrawalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
