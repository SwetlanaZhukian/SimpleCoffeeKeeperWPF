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
    class GroupsRepository: IRepository<Group>
    {

        EntityContext context;
        public GroupsRepository(EntityContext context)
        {
            this.context = context;
        }
        public void Create(Group t)
        {
            context.Groups.Add(t);
        }
        public void Delete(int id)
        {
            var group = context.Groups.Find(id);
            context.Groups.Remove(group);
        }
        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return context.Groups.Include(g => g.Coffes).Where(predicate).ToList();
        }
        public Group Get(int id)
        {
            return context.Groups.Find(id);
        }
        public IEnumerable<Group> GetAll()
        {
            return context.Groups.Include(g => g.Coffes);
        }
        public void Update(Group t)
        {
            context.Entry<Group>(t).State = EntityState.Modified;
        }
    }
}
