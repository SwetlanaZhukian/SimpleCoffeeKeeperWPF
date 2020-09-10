using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeKeeper.DataLayer.Entities;
using CoffeKeeper.DataLayer.EFContext;
using CoffeKeeper.DataLayer.Interfaces;
using System.Data.Entity;


namespace CoffeKeeper.DataLayer.Repositories
{
    class CoffeRepository : IRepository<Coffe>
    {
        EntityContext context;

        public CoffeRepository(EntityContext context)
        {
            this.context = context;
        }

        public void Create(Coffe t)
        {
            context.Coffes.Add(t);
        }

        public void Delete(int id)
        {
        
           Coffe  coffe = context.Coffes.Find(id);
            context.Coffes.Remove(coffe);
        }

        public IEnumerable<Coffe> Find(Func<Coffe, bool> predicate)
        {
            return context.Coffes.Where(predicate).ToList();
        }

        public Coffe Get(int id)
        {
            return context.Coffes.Find(id);
        }

        public IEnumerable<Coffe> GetAll()
        {
            return context.Coffes;
        }

        public void Update(Coffe t)
        {
            context.Entry<Coffe>(t).State = EntityState.Modified;
        }

    }
}
