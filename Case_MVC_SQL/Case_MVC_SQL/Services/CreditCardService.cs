using Case_MVC_SQL.Interfaces;
using Case_MVC_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case_MVC_SQL.Services
{
    public class CreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardService(ICreditCardRepository repository)
        {
            _creditCardRepository = repository;
        }

        public List<CreditCard> GetAllCreditCards()
        {
            return _creditCardRepository.GetAll().ToList();
        }

        public List<string> GetAllCardTypes()
        {
            var allCreditCards = GetAllCreditCards();
            var allCardTypes = allCreditCards.GroupBy(elem => elem.CardType).Select(group => group.First().CardType).ToList();

            return allCardTypes;
        }

        //public bool AddNewCustomer(string newCustomerName, int newCountryID)
        //{
        //    Customer newCustomer = new Customer
        //    {
        //        Name = newCustomerName,
        //        CountryId = newCountryID
        //    };

        //    _customerRepository.Create(newCustomer);

        //    return true;
        //}
        //public bool DeleteCard(int creditCardId)
        //{
        //    Customer newCustomer = new Customer
        //    {
        //        Name = newCustomerName,
        //        CountryId = newCountryID
        //    };

        //    _customerRepository.Create(newCustomer);

        //    return true;
        //}

    }
}
