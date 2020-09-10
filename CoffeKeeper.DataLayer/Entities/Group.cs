using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeKeeper.DataLayer.Entities
{
   public class Group
    {
        public Group()
        {
            Coffes = new List<Coffe>();
        }  
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public List<Coffe> Coffes { get; set; }

    }
}
