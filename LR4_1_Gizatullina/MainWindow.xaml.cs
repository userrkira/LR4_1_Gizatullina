using System.Windows;
using LR4_1_Gizatullina.View;

namespace LR4_1_Gizatullina
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Employee_OnClick(object sender, RoutedEventArgs e)
        {
            WindowEmployee window = new WindowEmployee();
            window.Show();
        }

        private void Role_OnClick(object sender, RoutedEventArgs e)
        {
            WindowRole window = new WindowRole();
            window.Show();
        }
    }
}