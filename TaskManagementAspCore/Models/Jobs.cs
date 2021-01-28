using System;
using System.Collections.Generic;
using TaskManager.Entities;
using TaskManagementAspCore.Enums;

namespace TaskManagementAspCore.Models
{
    public class Jobs : Entity
    {
        public Jobs()
        {
            this.Status = ETaskStatus.CREATED;
            this.Users = new HashSet<User>();
        }
        public Jobs(string name, ETaskStatus predecessorTaskStatus, DateTime startDate, DateTime endDate)
        {
            this.Name = name;
            this.PredecessorTaskStatus = predecessorTaskStatus;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Status = ETaskStatus.CREATED;
            this.Users = new HashSet<User>();
        }
        public Jobs(string name, ETaskStatus predecessorTaskStatus, DateTime startDate, DateTime endDate, List<User> users)
        {
            this.Name = name;
            this.PredecessorTaskStatus = predecessorTaskStatus;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Status = ETaskStatus.CREATED;
            this.Users = new HashSet<User>();
            this.Users = users;
        }

        public string Name { get;  set; }
        public ETaskStatus PredecessorTaskStatus { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public ETaskStatus Status { get;  set; }
        public virtual ICollection<User> Users { get; set; }

        public void SetStarted()
        {
            this.Status = ETaskStatus.STARTED;
        }
        public void SetConcluded() {
            this.Status = ETaskStatus.CONCLUDED;
        }
    }
}