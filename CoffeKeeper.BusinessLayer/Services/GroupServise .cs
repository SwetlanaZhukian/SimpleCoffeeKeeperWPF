using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeKeeper.BusinessLayer.Interfaces;
using CoffeKeeper.DataLayer.Entities;
using CoffeKeeper.BusinessLayer.Models;
using CoffeKeeper.DataLayer.Interfaces;
using CoffeKeeper.DataLayer.Repositories;
using AutoMapper;
using System.Collections.ObjectModel;


namespace CoffeKeeper.BusinessLayer.Services
{
      public class GroupServise: IGroupService
    {

        IUnitOfWork dataBase;

        public GroupServise(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }

        public void AddCoffeToGroup(int groupId, CoffeViewModel coffeVM)
        {
            Group group = dataBase.Groups.Get(groupId);
            // Конфигурировани AutoMapper.
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<CoffeViewModel, Coffe>());
            Coffe coffe = Mapper.Map<Coffe>(coffeVM);
            coffe.GroupId = groupId;
            group.Coffes.Add(coffe);
            // Сохраняем изменения.
            dataBase.Save();
        }

        public void CreateGroup(GroupViewModel groupVM)
        {
            // Конфигурировани AutoMapper.
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<GroupViewModel, Group>());
            Group group = Mapper.Map<Group>(groupVM);
            dataBase.Groups.Create(group);
            // Сохранить изменения.
            dataBase.Save();
        }

        public void DeleteGroup(int groupID)
        {
            dataBase.Groups.Delete(groupID);
            dataBase.Save();
        }

        public GroupViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<GroupViewModel> GetAll()
        {
            // Конфигурировани AutoMapper.
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Group, GroupViewModel>();
                cfg.CreateMap<Coffe, CoffeViewModel>();
            });
            
            ObservableCollection<GroupViewModel> groupVM = Mapper.Map<ObservableCollection<GroupViewModel>>(dataBase.Groups.GetAll());
            return groupVM;
        }

        public void RemoveCoffeFromGroup(int groupId, int coffeId)
        {
            Group group = dataBase.Groups.Get(groupId);
            group.Coffes.Remove(dataBase.Coffes.Get(coffeId));
            dataBase.Groups.Update(group);
            dataBase.Coffes.Delete(coffeId);
            dataBase.Save();
        }

        public void UpdateGroup(GroupViewModel groupVM)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<GroupViewModel,Group >());
            dataBase.Groups.Update(Mapper.Map<Group>(groupVM));
            dataBase.Save();
        }
        
    }
}
