using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using LR4_1_Gizatullina.Model;
using LR4_1_Gizatullina.ViewModel;
using LR4_1_Gizatullina.Helper;

namespace LR4_1_Gizatullina.View
{
    public partial class WindowEmployee : Window
    {
        private ObservableCollection<Person> people;

        public WindowEmployee()
        {
            InitializeComponent();

            people = PersonViewModel.Instance.ListPerson; //чтобы список сохранялся
            UpdateList();
        }

        private void UpdateList()
        {
            List<Role> roles = new List<Role>(
                new RoleViewModel().ListRole);

            ObservableCollection<PersonDPO> result =
                new ObservableCollection<PersonDPO>();

            foreach (Person person in people)
            {
                FindRole finder = new FindRole(person.RoleId);
                Role role = roles.Find(finder.RolePredicate);

                result.Add(new PersonDPO(
                    person.Id, role.NameRole,
                    person.FirstName, person.LastName,
                    person.Birthday));
            }

            lvEmployee.ItemsSource = result;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WindowPersonEdit window = new WindowPersonEdit();

            if (window.ShowDialog() == true)
            {
                int id = 1;

                foreach (Person p in people)
                    if (p.Id >= id) id = p.Id + 1;

                window.Result.Id = id;
                people.Add(window.Result);
                UpdateList();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            PersonDPO selected = lvEmployee.SelectedItem as PersonDPO;

            if (selected == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            Person person = null;

            foreach (Person p in people)
                if (p.Id == selected.Id) person = p;

            WindowPersonEdit window = new WindowPersonEdit(person);

            if (window.ShowDialog() == true)
            {
                int index = people.IndexOf(person);
                people[index] = window.Result;
                UpdateList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            PersonDPO selected = lvEmployee.SelectedItem as PersonDPO;

            if (selected == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            if (MessageBox.Show("Удалить сотрудника?",
                "Подтверждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Person p in people)
                {
                    if (p.Id == selected.Id)
                    {
                        people.Remove(p);
                        break;
                    }
                }

                UpdateList();
            }
        }
    }
}