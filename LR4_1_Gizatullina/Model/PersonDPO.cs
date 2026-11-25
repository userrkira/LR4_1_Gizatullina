
using System;

namespace LR4_1_Gizatullina.Model
{
    public class PersonDPO
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public PersonDPO() { }

        public PersonDPO(int id, string role, string firstName,
            string lastName, DateTime birthday)
        {
            Id = id;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }
    }
}
