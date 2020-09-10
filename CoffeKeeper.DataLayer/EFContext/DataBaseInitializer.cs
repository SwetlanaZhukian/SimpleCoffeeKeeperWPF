using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CoffeKeeper.DataLayer.Entities;

namespace CoffeKeeper.DataLayer.EFContext
{
    class DataBaseInitializer : CreateDatabaseIfNotExists<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Groups.AddRange(new Group[] { new Group { GroupName="Кофе 1 маленький",
                Coffes =new List<Coffe>
                {
                new Coffe { Name="Американо", Volume="200 мл",Price=1.90 },
                new Coffe { Name="Капучино", Volume="200 мл",Price=2.30},
                new Coffe { Name="Флэт Уайт", Volume="200 мл",Price=2.70},
                new Coffe { Name="Эспрессо", Volume="30 мл",Price=1.90},
                new Coffe { Name="Эспрессо", Volume="60 мл",Price=2.40},
                }
            },
               new Group { GroupName="Кофе 2 средний",Coffes =new List<Coffe>
                {
                new Coffe { Name="Американо", Volume="300 мл",Price=2.40},
                new Coffe { Name="Капучино", Volume="300 мл",Price=2.80},
                new Coffe { Name="Латте", Volume="300 мл",Price=2.80},
                new Coffe { Name="Клубничный латте", Volume="300 мл",Price=3.30},
                new Coffe { Name="Мокачино", Volume="300 мл",Price=3.40},
                new Coffe { Name="Раф", Volume="300 мл",Price=3.40},
                new Coffe { Name="Лавандовый раф", Volume="300 мл",Price=3.40},
                }
            },
                new Group { GroupName="Кофе 3 большой",Coffes =new List<Coffe>
                {
                new Coffe { Name="Лока-Мока", Volume="400 мл",Price=4.30},
                new Coffe { Name="Капучино", Volume="400 мл",Price=3.30},
                new Coffe { Name="Латте", Volume="400 мл",Price=3.30},
                new Coffe { Name="Клубничный латте", Volume="400 мл",Price=3.80},
                new Coffe { Name="Мокачино", Volume="400 мл",Price=3.90},
                new Coffe { Name="Раф", Volume="400 мл",Price=3.90},
                new Coffe { Name="Лавандовый раф", Volume="400 мл",Price=3.90},
                new Coffe { Name="Эмили Свит", Volume="400 мл",Price=4.00},
                }
            },
                 new Group { GroupName="Некофейные напитки",Coffes =new List<Coffe>
                {
                new Coffe { Name="Какао", Volume="300 мл",Price=2.30},
                new Coffe { Name="Какао", Volume="400 мл",Price=2.90},
                new Coffe { Name="Матча латте", Volume="300 мл",Price=3.80},
                new Coffe { Name="Чай черный ", Volume="200 мл",Price=1.50},
                new Coffe { Name="Чай черный", Volume="300 мл",Price=1.70},
                new Coffe { Name="Чай черный", Volume="400 мл",Price=1.90},
                new Coffe { Name="Чай зелёный", Volume="200 мл",Price=1.50},
                new Coffe { Name="Чай зелёный", Volume="300 мл",Price=1.70},
                new Coffe { Name="Чай зелёный", Volume="400 мл",Price=1.90},
                new Coffe { Name="Чай мята", Volume="200 мл",Price=1.50},
                new Coffe { Name="Чай мята", Volume="300 мл",Price=1.70},
                new Coffe { Name="Чай мята", Volume="400 мл",Price=1.90},
                new Coffe { Name="Чай молочный улун", Volume="200 мл",Price=1.50},
                new Coffe { Name="Чай молочный улун", Volume="300 мл",Price=1.70},
                new Coffe { Name="Чай молочный улун", Volume="400 мл",Price=1.90},

                }
            },
                  new Group { GroupName="Сиропы",Coffes =new List<Coffe>
                {
                   new Coffe { Name="Арбуз", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Амаретто", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Дыня", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Ежевика", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Мята", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Кокос", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Лаванда", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Белый шоколад", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Ваниль", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Миндаль", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Лесной орех", Volume="15 мл",Price=0.50},
                   new Coffe { Name="Карамель", Volume="15 мл",Price=0.50},
                }
            },
                  new Group { GroupName="Молоко/Сливки",Coffes =new List<Coffe>
                {
                 new Coffe { Name="Молоко", Volume="50 мл",Price=0.50},
                 new Coffe { Name="Сливки", Volume="20 мл",Price=0.50},

                }
            }
            }); context.SaveChanges();
        }
    }
    }
