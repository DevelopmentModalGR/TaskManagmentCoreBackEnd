using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entities;
using TaskManager.Enums;
using TaskManager.ValueObjects;

namespace TaskManager.Models
{
    public class User: Entity
    {
        public User()
        {
            this.Tasks = new HashSet<Jobs>();
            this.Departments = new HashSet<Department>();
        }
        public User(string name, string email, DateTime signUpDate, bool isActive, List<Department> department, Company company)
        {
            Name = name;
            Email = email;
            SignUpDate = signUpDate;
            IsActive = isActive;
            this.Tasks = new HashSet<Jobs>();
            this.Departments = new HashSet<Department>();
            this.Departments = department;
            Company = company;
        }

        public User(string name, string email, DateTime signUpDate, bool isActive, List<Department> department, Company company, List<Jobs>tasks)
        {
            Name = name;
            Email = email;
            SignUpDate = signUpDate;
            IsActive = isActive;
            this.Departments = new HashSet<Department>();
            this.Departments = department;
            this.Tasks = new HashSet<Jobs>();
            this.Tasks = tasks;
            Company = company;
        }

        public string Name { get;   set; }
        public string Email { get;   set; }
        public DateTime SignUpDate { get;   set; }
        public bool IsActive { get;   set; }
        public bool IsAdmin { get;  set; }
        public string Password { get;  set; }
        public string Role { get; set; }
        public int CompanyId { get; set; }
       /* public int DepartmentsId { get; set; }
        public int TasksId { get; set; }*/
        public Company Company { get; set; }       
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Jobs> Tasks { get; set; }


        public override string ToString()
        {
            return $"{this.Name}";
        }

        public void SetAsAdmin()
        {
            this.IsAdmin = true;
        }
    }
}
