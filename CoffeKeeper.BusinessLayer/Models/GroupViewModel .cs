using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoffeKeeper.BusinessLayer.Models
{
     public class GroupViewModel
    { 
        public int GroupId { get; set; }
        
        public string GroupName { get; set; }
       

        public List<CoffeViewModel> Coffes { get; set; }
        
        
    }
}
