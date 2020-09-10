using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CoffeKeeper.BusinessLayer.Models;

namespace CoffeKeeper.BusinessLayer.Interfaces
{
    public  interface ICoffeService
    {
        ObservableCollection<CoffeViewModel> GetAll();
        CoffeViewModel Get(int coffeID);
        void ChangeCoffeGroup(int groupID, int coffeID);
        void CreateCoffe(CoffeViewModel coffe);
        void DeleteCoffe(int coffeID);
        void UpdateCoffe(CoffeViewModel coffe);
    }
}
