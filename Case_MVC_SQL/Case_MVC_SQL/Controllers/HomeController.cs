using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case_MVC_SQL.Data;
using Microsoft.AspNetCore.Mvc;

namespace Case_MVC_SQL.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDBContext _context;
        private CreditCardService _creditCardService;
   
        public HomeController(ApplicationDBContext context, CreditCardService creditCardService)
        {
            _context = context;
            _creditCardService = creditCardService;            
        }

        public IActionResult Index()
        {
            var allCountries = _countryService.GetAllCountries().OrderBy(x => x.Name).ToList();
            var allCustomers = _customerService.GetAllCustomers();

            var model = new HomeViewModel
            {
                AllCountries = allCountries,
                AllCustomers = allCustomers
            };

            return View(model);
        }
    }
}
