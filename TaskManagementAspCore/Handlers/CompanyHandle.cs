using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Models;

namespace TaskManager.Handlers
{
    public class CompanyHandle
    {
        public CompanyHandle(long iD, string name)
        {
            ID = iD;
            Name = name;
            List<Department> Departments = new List<Department>();
        }

        public List<Company> Companies { get; private set; }
        public long ID { get;private  set; }
        public string Name { get; private set; }
        public List<Department> Departments { get; private set; }

        /*public void RegisterCompany(int id, string name, List<Department> departments)
        {
            Companies.Add(new Company(id, name));
        }*/
     /*   public void RemoveCompany(int id)
        {
            //Faltar remover tambem posteriormente do banco de dados
            foreach (var item in Departments)
            {
                if (item.ID == id)
                    Departments.Remove(item);                
            }
        }*/
    }
}
