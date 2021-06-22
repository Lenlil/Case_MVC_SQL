using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case_MVC_SQL.Data;
using Case_MVC_SQL.Models;
using Case_MVC_SQL.Services;
using Case_MVC_SQL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Case_MVC_SQL.Controllers
{
    public class HomeController : Controller
    {     
        private CreditCardService _creditCardService;
   
        public HomeController(CreditCardService creditCardService)
        {        
            _creditCardService = creditCardService;            
        }

        public IActionResult Index(string page, string pageSize, string errorMessage)
        {
            if (errorMessage != null)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            var model = CreateHomeViewModel(page, pageSize);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCreditCard(HomeViewModel model)
        {
            bool ok = true;

            if (!ModelState.IsValid || !ok)
            {            
                return RedirectToAction("Index", new { errorMessage = "Vänligen fyll i alla nödvändiga fält" });
            }

            var addNewCardStatus =_creditCardService.AddNewCreditCard(model.NewCardNumber, model.NewCardType, model.NewExpMonth, model.NewExpYear);

            if (!addNewCardStatus)
            {
                return RedirectToAction("Index", new { errorMessage = "Någonting gick fel, kortet kunde inte sparas." });
            }

            return RedirectToAction("Index", "Home");
        }     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCreditCard(HomeViewModel model)
        {          
            var id = model.CardToDeleteId;      
            var deleteCardStatus = _creditCardService.DeleteCreditCard(id);

            if (!deleteCardStatus)
            {
                return RedirectToAction("Index", new { errorMessage = "Någonting gick fel, kortet kunde inte tas bort." });
            }

            return RedirectToAction("Index", "Home");
        }

        public HomeViewModel CreateHomeViewModel(string page, string pageSize)
        {
            var homeViewModel = new HomeViewModel();
            int currentPage;

            IEnumerable<CreditCard> allCreditCards = _creditCardService.GetAllCreditCards().OrderBy(x => x.CreditCardId);

            if (string.IsNullOrEmpty(pageSize))
                homeViewModel.PagingViewModel.PageSize = 50;
            else
                homeViewModel.PagingViewModel.PageSize = Convert.ToInt32(pageSize);

            if (string.IsNullOrEmpty(page))
                currentPage = 1;
            else
                currentPage = Convert.ToInt32(page);


            var pageCount = (double)allCreditCards.Count() / homeViewModel.PagingViewModel.PageSize;

            homeViewModel.PagingViewModel.MaxPages = (int)Math.Ceiling(pageCount);

            allCreditCards = allCreditCards.Skip((currentPage - 1) * homeViewModel.PagingViewModel.PageSize).Take(homeViewModel.PagingViewModel.PageSize);

            homeViewModel.PagingViewModel.CurrentPage = currentPage;

            homeViewModel.AllCreditCards = allCreditCards.ToList();
            homeViewModel.AllCardTypes = _creditCardService.GetAllCardTypes();

            return homeViewModel;
        }
    }
}
