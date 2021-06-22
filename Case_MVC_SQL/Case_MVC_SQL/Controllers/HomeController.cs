using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case_MVC_SQL.Data;
using Case_MVC_SQL.Services;
using Case_MVC_SQL.ViewModels;
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
            var allCreditCards = _creditCardService.GetAllCreditCards().OrderBy(x => x.CreditCardId).ToList();
            var allCardTypes = _creditCardService.GetAllCardTypes();

            var model = new HomeViewModel
            {
                AllCreditCards = allCreditCards,
                AllCardTypes = allCardTypes
            };

            return View(model);
        }
    }
}
