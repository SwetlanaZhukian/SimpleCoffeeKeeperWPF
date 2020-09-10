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
  public  class CoffeService:ICoffeService
    {
        IUnitOfWork dataBase;

        public CoffeService (string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void ChangeCoffeGroup(int groupID, int coffeID)
        {
            throw new NotImplementedException();
        }

        public void CreateCoffe(CoffeViewModel   coffeVM)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<CoffeViewModel, Coffe>());
            dataBase.Coffes.Create(Mapper.Map<Coffe>(coffeVM));
            dataBase.Save();
        }

        public void DeleteCoffe(int coffeID)
        {
            dataBase.Coffes.Delete(coffeID);
            dataBase.Save();
        }

        public CoffeViewModel Get(int coffeID)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<CoffeViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void UpdateCoffe(CoffeViewModel coffeVM)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<CoffeViewModel, Coffe>());
            dataBase.Coffes.Update(Mapper.Map<Coffe>(coffeVM));
            dataBase.Save();
        }

    }
}
