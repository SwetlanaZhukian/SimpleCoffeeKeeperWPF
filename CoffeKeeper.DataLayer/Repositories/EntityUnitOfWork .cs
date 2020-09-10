using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeKeeper.DataLayer.Entities;
using CoffeKeeper.DataLayer.EFContext;
using CoffeKeeper.DataLayer.Interfaces;

namespace CoffeKeeper.DataLayer.Repositories
{
  public class EntityUnitOfWork : IUnitOfWork
    {
        EntityContext context;
        GroupsRepository groupsRepository;
        CoffeRepository coffesRepository;

        public EntityUnitOfWork(string name)

        {
            context = new EntityContext(name);
        }
        public IRepository<Group> Groups
        {
            get
            {
                if (groupsRepository == null)
                    groupsRepository = new GroupsRepository(context);
                return groupsRepository;
            }
        }
        public IRepository<Coffe> Coffes
        {
            get
            {
                if (coffesRepository == null)
                    coffesRepository = new CoffeRepository(context);
                return coffesRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                { context.Dispose(); }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
