using LR4_1_Gizatullina.Model;
using System.Collections.Generic;

namespace LR4_1_Gizatullina.Helper
{
    public class FindRole
    {
        public int Id { get; set; }

        public FindRole(int id)
        {
            Id = id;
        }

        public bool RolePredicate(Role role)
        {
            return role.Id == Id;
        }
    }
}
