using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeKeeper.DataLayer.Entities
{
   public class Coffe
    {
        public int CoffeId { get; set; }
        public string Name { get; set; }
        public string Volume { get; set;}
        public double Price { get; set; }


        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
