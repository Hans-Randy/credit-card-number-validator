using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Facade;

namespace Web.Controllers
{
    public class CreditCardController : Controller
    {
        public IActionResult Index()
        {
            return View(new CreditCardManager().Items);
        }
    }
}