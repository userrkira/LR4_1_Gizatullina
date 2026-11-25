using System;
using System.Collections.ObjectModel;
using LR4_1_Gizatullina.Model;

namespace LR4_1_Gizatullina.ViewModel
{
    public class PersonViewModel
    {
        public static PersonViewModel Instance { get; } =
            new PersonViewModel();

        public ObservableCollection<Person> ListPerson { get; set; } =
            new ObservableCollection<Person>();

        public PersonViewModel()
        {
            ListPerson.Add(new Person(1, 1, "Иван", "Иванов",
                new DateTime(1980, 2, 28)));

            ListPerson.Add(new Person(2, 2, "Петр", "Петров",
                new DateTime(1981, 3, 20)));

            ListPerson.Add(new Person(3, 3, "Виктор", "Викторов",
                new DateTime(1982, 4, 15)));

            ListPerson.Add(new Person(4, 3, "Сидор", "Сидоров",
                new DateTime(1983, 5, 10)));
        }
    }
}