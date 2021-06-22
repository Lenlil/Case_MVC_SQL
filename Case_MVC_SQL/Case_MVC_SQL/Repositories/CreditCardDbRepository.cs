using Case_MVC_SQL.Data;
using Case_MVC_SQL.Interfaces;
using Case_MVC_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case_MVC_SQL.Repositories
{
    public class CreditCardDbRepository : ICreditCardRepository
    {
        private readonly ApplicationDBContext dbContext;

        public CreditCardDbRepository(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(CreditCard creditCard)
        {
            dbContext.CreditCards.Add(creditCard);
            dbContext.SaveChanges();
        }

        public IQueryable<CreditCard> GetAll()
        {
            return dbContext.CreditCards;
        }

        public CreditCard GetOneByID(int id)
        {
            return dbContext.CreditCards.Find(id);
        }

        public void Update(CreditCard creditCard)
        {
            dbContext.CreditCards.Update(creditCard);
            dbContext.SaveChanges();
        }
    }
}
