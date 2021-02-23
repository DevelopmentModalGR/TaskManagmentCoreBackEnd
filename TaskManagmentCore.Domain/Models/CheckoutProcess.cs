using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementCore.Entities;

namespace TaskManagementCore.Models
{
    public class CheckoutProcess : Entity
    {
        #region Constructors 
        public CheckoutProcess()
        {
            this.Jobs = new HashSet<Jobs>();
        }
        public CheckoutProcess(string name, Department department, string description, DateTime startDate, DateTime endDate, List<Jobs> tasks)
        {
            Name = name;
            Department = department;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            this.Jobs = new HashSet<Jobs>();
            this.Jobs = tasks;
        }

        public CheckoutProcess(string name, Department department, string description, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Department = department;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            this.Jobs = new HashSet<Jobs>();
        }
        #endregion

        #region Attributes
        public string Name { get;  set; }
        public Department Department { get;  set; }
        public string Description { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public virtual ICollection<Jobs> Jobs { get; set; }
        #endregion

        #region Methods
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
        #endregion
    }
}
