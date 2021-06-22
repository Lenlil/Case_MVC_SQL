using Case_MVC_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case_MVC_SQL.Interfaces
{
    public interface ICreditCardRepository
    {       
        IQueryable<CreditCard> GetAll();
        CreditCard GetOneByID(int creditCardId);
        void Create(CreditCard creditCard);
        void Update(CreditCard creditCard);
        void Delete(CreditCard creditCard);
    }
}
