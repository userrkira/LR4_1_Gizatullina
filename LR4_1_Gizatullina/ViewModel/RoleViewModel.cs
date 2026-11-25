using System.Collections.ObjectModel;
using LR4_1_Gizatullina.Model;

namespace LR4_1_Gizatullina.ViewModel
{
    public class RoleViewModel
    {
        public ObservableCollection<Role> ListRole { get; set; }

        public RoleViewModel()
        {
            ListRole = new ObservableCollection<Role>();

            ListRole.Add(new Role(1, "Директор"));
            ListRole.Add(new Role(2, "Бухгалтер"));
            ListRole.Add(new Role(3, "Менеджер"));
        }
    }
}