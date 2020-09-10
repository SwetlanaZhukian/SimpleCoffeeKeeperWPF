using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Keeper
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Cofe selectedCofe;

        public ObservableCollection<Cofe> Cofes { get; set; }
        public ObservableCollection<Cofe> CofeSmall { get; set; }
        public ObservableCollection<Cofe> CofeMidll { get; set; }
        public ObservableCollection<Cofe> CofeBig { get; set; }
        public ObservableCollection<Cofe> CofeSyrups { get; set; }
        public ObservableCollection<Cofe> CofeMilk { get; set; }
        public ObservableCollection<Cofe> CofeNot { get; set; }

        public Cofe SelectedCofe
        {
            get { return  ; }
            set
            {    

                selectedCofe = value;
                OnPropertyChanged("SelectedCofe");
            }
        }

        public ApplicationViewModel()
        {
            Cofes = new ObservableCollection<Cofe>
            {
                new Cofe { Title="Кофе 1 маленький " },
                new Cofe {Title="Кофе 2 средний " },
                new Cofe {Title="Кофе 3 большой" },
                new Cofe {Title="Некофейные напитки" },
                 new Cofe {Title="Молоко/Сливки" },
                  new Cofe {Title="Сиропы" },
            };
            CofeSmall = new ObservableCollection<Cofe>
            {
                new Cofe { Title="Американо", Volume="200 мл",Price=1.90},
                new Cofe { Title="Капучино", Volume="200 мл",Price=2.30},
                new Cofe { Title="Флэт Уайт", Volume="200 мл",Price=2.70},
                new Cofe { Title="Эспрессо", Volume="30 мл",Price=1.90},
                new Cofe { Title="Эспрессо", Volume="60 мл",Price=2.40},
            };
            CofeMidll = new ObservableCollection<Cofe>
            {
                new Cofe { Title="Американо", Volume="300 мл",Price=2.40},
                new Cofe { Title="Капучино", Volume="300 мл",Price=2.80},
                new Cofe { Title="Латте", Volume="300 мл",Price=2.80},
                new Cofe { Title="Клубничный латте", Volume="300 мл",Price=3.30},
                new Cofe { Title="Мокачино", Volume="300 мл",Price=3.40},
                new Cofe { Title="Раф", Volume="300 мл",Price=3.40},
                new Cofe { Title="Лавандовый раф", Volume="300 мл",Price=3.40},
            };
            CofeBig = new ObservableCollection<Cofe>
           {
               new Cofe { Title="Лока-Мока", Volume="400 мл",Price=4.30},
                new Cofe { Title="Капучино", Volume="400 мл",Price=3.30},
                new Cofe { Title="Латте", Volume="400 мл",Price=3.30},
                new Cofe { Title="Клубничный латте", Volume="400 мл",Price=3.80},
                new Cofe { Title="Мокачино", Volume="400 мл",Price=3.90},
                new Cofe { Title="Раф", Volume="400 мл",Price=3.90},
                new Cofe { Title="Лавандовый раф", Volume="400 мл",Price=3.90},
                 new Cofe { Title="Эмили Свит", Volume="400 мл",Price=4.00},
           };
            CofeSyrups= new ObservableCollection<Cofe>
           {
               new Cofe { Title="Арбуз", Volume="15 мл",Price=0.50},
                new Cofe { Title="Амаретто", Volume="15 мл",Price=0.50},
                new Cofe { Title="Дыня", Volume="15 мл",Price=0.50},
                new Cofe { Title="Ежевика", Volume="15 мл",Price=0.50},
                new Cofe { Title="Мята", Volume="15 мл",Price=0.50},
                new Cofe { Title="Кокос", Volume="15 мл",Price=0.50},
                new Cofe { Title="Лаванда", Volume="15 мл",Price=0.50},
                 new Cofe { Title="Белый шоколад", Volume="15 мл",Price=0.50},
                 new Cofe  { Title="Ваниль", Volume="15 мл",Price=0.50},
                  new Cofe  { Title="Миндаль", Volume="15 мл",Price=0.50},
                 new Cofe  { Title="Лесной орех", Volume="15 мл",Price=0.50},
                  new Cofe  { Title="Карамель", Volume="15 мл",Price=0.50},
           };
            CofeMilk = new ObservableCollection<Cofe>
           {
               new Cofe { Title="Молоко", Volume="50 мл",Price=0.50},
                new Cofe { Title="Сливки", Volume="20 мл",Price=0.50},
                
           };
            CofeNot = new ObservableCollection<Cofe>
            {
                new Cofe { Title="Какао", Volume="300 мл",Price=2.30},
                new Cofe { Title="Какао", Volume="400 мл",Price=2.90},
                new Cofe { Title="Матча латте", Volume="300 мл",Price=3.80},
                new Cofe { Title="Чай черный ", Volume="200 мл",Price=1.50},
                new Cofe { Title="Чай черный", Volume="300 мл",Price=1.70},
                new Cofe { Title="Чай черный", Volume="400 мл",Price=1.90},
                new Cofe { Title="Чай зелёный", Volume="200 мл",Price=1.50},
                new Cofe { Title="Чай зелёный", Volume="300 мл",Price=1.70},
                new Cofe { Title="Чай зелёный", Volume="400 мл",Price=1.90},
                new Cofe { Title="Чай мята", Volume="200 мл",Price=1.50},
                new Cofe { Title="Чай мята", Volume="300 мл",Price=1.70},
                new Cofe { Title="Чай мята", Volume="400 мл",Price=1.90},
                new Cofe { Title="Чай молочный улун", Volume="200 мл",Price=1.50},
                new Cofe { Title="Чай молочный улун", Volume="300 мл",Price=1.70},
                new Cofe { Title="Чай молочный улун", Volume="400 мл",Price=1.90},

            };


        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

