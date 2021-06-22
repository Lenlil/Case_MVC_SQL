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
        private ApplicationDBContext _context;
        private CreditCardService _creditCardService;
   
        public HomeController(ApplicationDBContext context, CreditCardService creditCardService)
        {
            _context = context;
            _creditCardService = creditCardService;            
        }

        public IActionResult Index(string page, string pageSize)
        {
            var allCreditCards = _creditCardService.GetAllCreditCards().OrderBy(x => x.CreditCardId);
            var allCardTypes = _creditCardService.GetAllCardTypes();

            var model = CreateHomeViewModel(page, pageSize, allCreditCards);

            return View(model);
        }

        public HomeViewModel CreateHomeViewModel(string page, string pageSize, IEnumerable<CreditCard> allCreditCards)
        {
            var homeViewModel = new HomeViewModel();
            int currentPage;

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
