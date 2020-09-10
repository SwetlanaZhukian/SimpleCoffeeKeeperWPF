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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoffeKeeper.BusinessLayer.Interfaces;
using CoffeKeeper.BusinessLayer.Models;
using CoffeKeeper.BusinessLayer.Services;
using System.Collections.ObjectModel;
using CoffeKeeper.Dialogs;
using CoffeKeeper.DataLayer.Repositories;
using AutoMapper;
using CoffeKeeper.DataLayer.Entities;
using CoffeKeeper.DataLayer.EFContext;


namespace CoffeKeeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        ObservableCollection<GroupViewModel> groupVM;
        IGroupService groupService;
        ICoffeService coffeService;
        double p=0.0;
        double s = 0.0;
        double ps = 0.0;
        public MainWindow()
        {
            InitializeComponent();
            groupService = new GroupServise("DbConnection");
            groupVM = groupService.GetAll();
            coffeService = new CoffeService("DbConnection");
            lbGroup.DataContext = groupVM;
            lbGroup_1.DataContext = groupVM;

        }
        private void list_selected(object sender, RoutedEventArgs e)
        {
            if ((CoffeViewModel)lbCoffe.SelectedItem != null)
            {
                CoffeViewModel coffe = (CoffeViewModel)lbCoffe.SelectedItem;
                
                p += Convert.ToDouble(coffe.Price);
                tbprice.Text = p.ToString();
                lbPice.Items.Add(coffe);
                
                
                
            }
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lbPice.Items.Clear();
            p = 0;
            tbprice.Text=Convert.ToString(0.00);
            tbsale.Text = Convert.ToString(0.00);


        }

       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Продажа завершена успешно!");
            lbPice.Items.Clear();
            tbprice.Text = Convert.ToString(0.00);
            tbsale.Text = Convert.ToString(0.00);
           
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if ((CoffeViewModel)lbCoffe.SelectedItem != null)
            {

                s = 0.0;
                tbprice.Text = p.ToString();
                tbsale.Text = s.ToString();
            }
          
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if ((CoffeViewModel)lbCoffe.SelectedItem != null)
            {
               
                s = (p * 10) / 100;
                ps =p-s ;
                tbprice.Text = ps.ToString();
                tbsale.Text = s.ToString();
            }

        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if ((CoffeViewModel)lbCoffe.SelectedItem != null)
            {
               
                s = (p * 20) / 100;
                ps = p - s;
                tbprice.Text = ps.ToString();
                tbsale.Text = s.ToString();
            }


        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if ((CoffeViewModel)lbCoffe.SelectedItem != null)
            {
               
                s = (p * 100) / 100;
                ps = p - s;
                tbprice.Text = ps.ToString();
                tbsale.Text = s.ToString();
            }

        }
        private void AddCoffeClick(object sender, RoutedEventArgs e)
        {
            if (lbGroup_1.SelectedItem != null)
            {
                EddOrEditCoffe dialog = new EddOrEditCoffe(((GroupViewModel)lbGroup_1.SelectedItem).GroupId);
                dialog.Show();
                dialog.Closed += Dialog_Closed;
                groupService = new GroupServise("DbConnection");
                groupVM = groupService.GetAll();
                lbGroup.DataContext = groupVM;

            }
            
        }
        private void ChangeCoffeClick(object sender, RoutedEventArgs e)
        {
            if (lbCoffe_1.SelectedItem != null)
            {
                EddOrEditCoffe dialog = new EddOrEditCoffe((CoffeViewModel)lbCoffe_1.SelectedItem);
                dialog.Show();
                dialog.Closed += Dialog_Closed;
               
            }
            else
            {
                MessageBox.Show("Выберите кофе для изменения", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
         
        }
        private void DeleteCoffeClick(object sender, RoutedEventArgs e)
        {
            if (lbCoffe_1.SelectedItem != null )
            {
                
                groupService.RemoveCoffeFromGroup(((GroupViewModel)lbGroup_1.SelectedItem).GroupId, ((CoffeViewModel)lbCoffe_1.SelectedItem).CoffeId);
               
                UpdateControls();
                UpdateControls_1();
            }
            else
            {
                MessageBox.Show("Выберите кофе для удаления", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Dialog_Closed(object sender, EventArgs e)
        {
            UpdateControls();
            UpdateControls_1();
            if (lbGroup_1.Items.Count == 1)
            {
                lbGroup_1.SelectedIndex = 0;
            }
            

        }
        private void UpdateControls()
        {
            int index = lbGroup_1.SelectedIndex;
           
            EntityUnitOfWork u = new EntityUnitOfWork("DbConnection");
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Group, GroupViewModel>());
            IEnumerable<Group> l = u.Groups.GetAll();
            lbGroup_1.DataContext = Mapper.Map<IEnumerable<GroupViewModel>>(l);
           lbGroup_1.SelectedIndex = index;
            
        }
        private void UpdateControls_1()
        {
           
            EntityUnitOfWork u = new EntityUnitOfWork("DbConnection");
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Group, GroupViewModel>());
            IEnumerable<Group> l = u.Groups.GetAll();
            lbGroup.DataContext = Mapper.Map<IEnumerable<GroupViewModel>>(l);
            //lbGroup.DataContext = Mapper.Map<IEnumerable<GroupViewModel>>(l);
            

        }


        private void AddGroupClick(object sender, RoutedEventArgs e)
        {
            EddOrEditGroup dialog = new EddOrEditGroup();
            dialog.Show();
            dialog.Closed += Dialog_Closed;
            

        }
        private void DeleteGroupClick(object sender, RoutedEventArgs e)
        {
            if (lbGroup_1.SelectedItem != null)
            {
                
                groupService.DeleteGroup(((GroupViewModel)lbGroup_1.SelectedItem).GroupId);
                UpdateControls();
                UpdateControls_1();
                lbGroup_1.SelectedIndex++;
            }
            else
            {
                MessageBox.Show("Выбирите группу для удаления", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ChangeGroupClick(object sender, RoutedEventArgs e)
        {
            if ((GroupViewModel)lbGroup_1.SelectedItem != null)
            {



                EddOrEditGroup dialog = new EddOrEditGroup((GroupViewModel)lbGroup_1.SelectedItem);
                dialog.Show();
                dialog.Closed += Dialog_Closed;

            }
            else
            {
                MessageBox.Show("Выбирите  группу для изменения", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
    }
}
