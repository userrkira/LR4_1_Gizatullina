using System;
using System.Windows;
using LR4_1_Gizatullina.Model;
using LR4_1_Gizatullina.ViewModel;

namespace LR4_1_Gizatullina.View
{
    public partial class WindowPersonEdit : Window
    {
        public Person Result { get; private set; }
        private Person currentPerson;
        private void Name_PreviewTextInput( object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(
                e.Text, @"^[а-яА-ЯёЁa-zA-Z\s-]+$");
        }

        public WindowPersonEdit(Person person = null)
        {
            InitializeComponent();

            currentPerson = person;
            cbRole.ItemsSource = new RoleViewModel().ListRole;

            if (person != null)
            {
                tbLastName.Text = person.LastName;
                tbFirstName.Text = person.FirstName;
                cbRole.SelectedValue = person.RoleId;
                dpBirthday.SelectedDate = person.Birthday;
            }
            else
            {
                cbRole.SelectedIndex = 0;
                dpBirthday.SelectedDate = DateTime.Today;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string lastName = tbLastName.Text.Trim();
            string firstName = tbFirstName.Text.Trim();

            if (string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Введите фамилию и имя!");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(
                lastName, @"^[а-яА-ЯёЁa-zA-Z\s-]+$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(
                firstName, @"^[а-яА-ЯёЁa-zA-Z\s-]+$"))
            {
                MessageBox.Show(
                    "Фамилия и имя должны содержать только буквы, пробелы и дефис!");
                return;
            }

            if (cbRole.SelectedValue == null ||
                dpBirthday.SelectedDate == null)
            {
                MessageBox.Show("Выберите должность и дату рождения!");
                return;
            }

            Result = new Person(
                currentPerson == null ? 0 : currentPerson.Id,
                (int)cbRole.SelectedValue,
                firstName,
                lastName,
                dpBirthday.SelectedDate.Value
            );

            DialogResult = true;
        }
    }
}