using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CoffeKeeper.BusinessLayer.Interfaces;
using CoffeKeeper.BusinessLayer.Models;
using CoffeKeeper.BusinessLayer.Services;
using Microsoft.Win32;
using System.IO;



namespace CoffeKeeper.Dialogs
{
    /// <summary>
    /// Interaction logic for EddOrEditCoffe.xaml
    /// </summary>
    public partial class EddOrEditCoffe : Window
    {
        bool flag = false;
        int GID =1;
        int CID=1 ;


        public EddOrEditCoffe(int groupId)
        {
            GID = groupId;
            InitializeComponent();
        }
        public EddOrEditCoffe(CoffeViewModel coffeVM)
        {
            InitializeComponent();
            ModelToWindow(coffeVM);
        }

        private void ModelToWindow(CoffeViewModel coffeVM)
        {
            tbname.Text = coffeVM.Name;
            tbvolume.Text = coffeVM.Volume;
            tbprice.Text = Convert.ToString(coffeVM.Price);
            GID = coffeVM.groupId;
            CID = coffeVM.CoffeId;
            flag = true;
        }
        private CoffeViewModel WindowToModel()
        {
            CoffeViewModel coffeVM = new CoffeViewModel();
            coffeVM.Name = tbname.Text;
            coffeVM.Volume = tbvolume.Text;
            coffeVM.Price =Convert.ToDouble( tbprice.Text);
           
            return coffeVM;
        }
        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbname.Text == "" || tbvolume.Text == "" || tbprice.Text == "")
                {
                    MessageBox.Show("Заполните форму", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else if (!flag)
                {
                    IGroupService groupService = new GroupServise("DbConnection");

                    groupService.AddCoffeToGroup(GID, WindowToModel());
                    Close();
                }
                else
                {
                    ICoffeService coffeService = new CoffeService("DbConnection");
                    CoffeViewModel coffe = WindowToModel();
                    coffe.CoffeId = CID;
                    coffe.groupId = GID;
                    // coffeService.CreateCoffe(coffe);
                    coffeService.UpdateCoffe(coffe);
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Введены некорректные данные!!!");
            }


        }

    }
}
