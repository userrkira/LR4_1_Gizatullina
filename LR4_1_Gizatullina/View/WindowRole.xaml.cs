using System.Windows;
using LR4_1_Gizatullina.ViewModel;

namespace LR4_1_Gizatullina.View
{
    public partial class WindowRole : Window
    {
        public WindowRole()
        {
            InitializeComponent();

            RoleViewModel roleVM = new RoleViewModel();

            lvRole.ItemsSource = roleVM.ListRole;
        }
    }
}