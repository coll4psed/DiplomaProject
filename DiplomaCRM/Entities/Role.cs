using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string RoleValue { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
