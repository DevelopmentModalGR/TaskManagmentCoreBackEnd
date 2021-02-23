using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementCore.Entities;

namespace TaskManagementCore.Models
{

    public class Department : Entity
    {
        #region Constructors
        public Department()
        {
            this.CheckoutProcesses = new HashSet<CheckoutProcess>();
            this.Users = new HashSet<User>();
        }
        public Department(string name)
        {
            Name = name;
            this.CheckoutProcesses = new HashSet<CheckoutProcess>();
            this.Users = new HashSet<User>();
        }
        public Department(string name, List<User> users)
        {
            Name = name;
            this.CheckoutProcesses = new HashSet<CheckoutProcess>();
            this.Users = new HashSet<User>();
            this.Users = users;
        }
        #endregion

        #region Atributtes
        public string Name { get; set; }
        public virtual ICollection<CheckoutProcess> CheckoutProcesses { get; set; }
        public virtual ICollection<User> Users { get; set; }
        #endregion

    }
}
