using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CoffeKeeper.DataLayer.Entities;

namespace CoffeKeeper.DataLayer.EFContext
{
    public class EntityContext:DbContext
    {
        public EntityContext(string name) : base(name)
        {
            Database.SetInitializer(new DataBaseInitializer());
        }
        public DbSet<Coffe> Coffes { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
