using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementCore.Entities;

namespace TaskManagementCore.Models
{
    public class User : Entity
    {
        #region Constructors
        public User()
        {
            this.Jobs = new HashSet<Jobs>();
            this.Departments = new HashSet<Department>();
        }
        public User(string name, string email, DateTime signUpDate, bool isActive, List<Department> departments, Company company)
        {
            Name = name;
            Email = email;
            SignUpDate = signUpDate;
            IsActive = isActive;
            this.Jobs = new HashSet<Jobs>();
            this.Departments = new HashSet<Department>();
            this.Departments = departments;
            Company = company;
        }

        public User(string name, string email, DateTime signUpDate, bool isActive, List<Department> departments, Company company, List<Jobs> jobs)
        {
            Name = name;
            Email = email;
            SignUpDate = signUpDate;
            IsActive = isActive;
            this.Departments = new HashSet<Department>();
            this.Departments = departments;
            this.Jobs = new HashSet<Jobs>();
            this.Jobs = jobs;
            Company = company;
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime SignUpDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }  
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Jobs> Jobs { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{this.Name}";
        }

        public void SetAsAdmin()
        {
            this.IsAdmin = true;
        }
        #endregion
    }
}
