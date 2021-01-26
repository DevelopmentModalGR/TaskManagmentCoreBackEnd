using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.Models
{
    public class CheckoutProcess : Entity
    {
        public CheckoutProcess()
        {
            this.Tasks = new HashSet<Jobs>();
        }
        public CheckoutProcess(string name, Department department, string description, DateTime startDate, DateTime endDate, List<Jobs> tasks)
        {
            Name = name;
            Department = department;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            this.Tasks = new HashSet<Jobs>();
            this.Tasks = tasks;
        }

        public CheckoutProcess(string name, Department department, string description, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Department = department;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            this.Tasks = new HashSet<Jobs>();
        }

        public string Name { get;  set; }
        public Department Department { get;  set; }
        public string Description { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public virtual ICollection<Jobs> Tasks { get; set; }

        public bool CheckProcessStatus()
        {
            return false;
        }
        public bool CheckTasksStatus()
        {
            return false;
        }

        public void StartTask(Jobs task)
        {
            task.SetStarted();

            //implementar inicialização da task
            //verifica se PredecessorTaskStatus == true
        }

        public void EndTask(Jobs task)
        {
            //implementar atualização da task
        }

        public void DeleteTask(Jobs task)
        {
            //implementar remoção da task
        }

        public void UpdateTask(Jobs task)
        {
            //implementar atualização da task
        }
    }
}
