using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Clients = new HashSet<Client>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeLastName { get; set; } = null!;
        public string EmployeeFirstName { get; set; } = null!;
        public string? EmployeeMiddleName { get; set; }
        public string EmployeeLogin { get; set; } = null!;
        public string EmployeePassword { get; set; } = null!;
        public int EmployeeRole { get; set; }

        public virtual Role EmployeeRoleNavigation { get; set; } = null!;
        public virtual ICollection<Client> Clients { get; set; }

        public string FullName
        {
            get
            {
                return EmployeeLastName + " " + EmployeeFirstName + " " + EmployeeMiddleName;
            }
        }
    }
}
