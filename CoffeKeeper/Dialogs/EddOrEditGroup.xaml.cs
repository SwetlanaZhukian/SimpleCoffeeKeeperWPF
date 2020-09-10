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
using System.Collections.ObjectModel;

namespace CoffeKeeper.Dialogs
{
    /// <summary>
    /// Interaction logic for EddOrEditGroup.xaml
    /// </summary>
    public partial class EddOrEditGroup : Window
    
    {

        private int GID = -1;
        private bool flag = false;
        private List<CoffeViewModel> coffes;
        public EddOrEditGroup()
        {
            InitializeComponent();
        }
        public EddOrEditGroup(GroupViewModel groupVM)
        {
            flag = true;
            InitializeComponent();
            ModelToWindow(groupVM);
        }
        private void ModelToWindow(GroupViewModel groupVM)
        {
            tbname.Text = groupVM.GroupName;
          
            GID = groupVM.GroupId;
            //coffes = groupVM.Coffes;
            
            
        }
        private GroupViewModel WindowToModel()
        {
            GroupViewModel groupVM = new GroupViewModel();
            groupVM.GroupName = tbname.Text;

            return groupVM;
        }
        
        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbname.Text == "" )
            {
                MessageBox.Show("Заполните форму", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!flag)
            {
                IGroupService groupService = new GroupServise("DbConnection");
                groupService.CreateGroup(WindowToModel());
                Close();
            }
            else
            {
                IGroupService groupService = new GroupServise("DbConnection");
               GroupViewModel groupVM = WindowToModel();

                groupVM.GroupId = GID;
              // groupVM.Coffes = coffes;
                groupService.UpdateGroup(groupVM);
                
                Close();
            }
        }

    }
}
