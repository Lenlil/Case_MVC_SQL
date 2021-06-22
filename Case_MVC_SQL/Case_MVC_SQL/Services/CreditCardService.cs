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

        public List<CreditCard> GetAllCountries()
        {
            return _creditCardRepository.GetAll().ToList();
        }
    }
}
