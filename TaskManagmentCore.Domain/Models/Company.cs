using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementCore.Entities;

namespace TaskManagementCore.Models
{
    public class Company : Entity
    {
        #region Constructors
        public Company()
        {
            this.Users = new HashSet<User>();
        }
        public Company(string name)
        {
            Name = name;
            this.Users = new HashSet<User>();
        }
        public Company(string name, List<User> user)
        {
            Name = name;
            this.Users = new HashSet<User>();
            this.Users = user;
        }
        #endregion

        #region attributes        
        public string Name { get;  set; }
        public string CNPJ { get;  set; }
        public virtual ICollection<User> Users { get; set; }
        #endregion

        #region Methods
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
        public string ListAllUsersNames()
        {
            var aux = "";
            int count = 1;
            foreach (var item in Users)
            {
                aux += $"{count}.{item.Name} || ";
                count++;
            }
            count = 1;
            return aux;
        }
        #endregion
    }
}
