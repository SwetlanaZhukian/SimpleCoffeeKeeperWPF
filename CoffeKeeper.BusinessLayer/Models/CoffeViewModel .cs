using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace CoffeKeeper.BusinessLayer.Models
{
    public class CoffeViewModel 
    {
       
        public int CoffeId { get; set; }
           
          
        public string Name { get; set; }
        
        public string Volume { get; set; }
       
        public double Price { get; set; }
       
        public int groupId { get; set; }
        
       

    }
}
