using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CoffeKeeper.BusinessLayer.Models;

namespace CoffeKeeper.BusinessLayer.Interfaces
{
   public interface IGroupService
    {

        ObservableCollection<GroupViewModel> GetAll();
        GroupViewModel Get(int id);
        void AddCoffeToGroup(int groupId, CoffeViewModel coffe);
        void RemoveCoffeFromGroup(int groupId, int coffeId);
        void CreateGroup(GroupViewModel group);
        void DeleteGroup(int groupId);
        void UpdateGroup(GroupViewModel group);
       
    }
}
