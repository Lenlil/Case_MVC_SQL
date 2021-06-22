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

        public bool AddNewCreditCard(string newCardNumber, string newCardType, int newExpMonth, int newExpYear)
        {
            CreditCard newCreditCard = new CreditCard
            {
                CardType = newCardType,
                CardNumber = newCardNumber,
                ExpMonth = (byte)newExpMonth,
                ExpYear = (short)newExpYear,
                ModifiedDate = DateTime.Now
            };

            try
            {
                _creditCardRepository.Create(newCreditCard);
            }
            catch (Exception)
            {
                return false;              
            }          
            return true;
        }

        public bool DeleteCreditCard(int creditCardId)
        {
            var creditCardToRemove = _creditCardRepository.GetOneByID(creditCardId);

            try
            {
                _creditCardRepository.Delete(creditCardToRemove);
            }
            catch (Exception)
            {
                return false;
            }          
            return true;
        }

    }
}
