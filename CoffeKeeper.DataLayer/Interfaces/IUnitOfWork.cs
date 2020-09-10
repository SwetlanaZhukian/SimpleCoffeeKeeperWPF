using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CoffeKeeper.DataLayer.Entities;

namespace CoffeKeeper.DataLayer.Interfaces
{
   public interface IUnitOfWork
    {
        IRepository<Group> Groups { get; }
        IRepository<Coffe> Coffes { get; }
        void Save();
    }
}
