using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeTask
{
    class Task
    {
        public string Description { get; }
        public DateTime Deadline { get; }
        public string Initiator { get; }
        public string Executor { get; private set; }
        public TaskStatus Status { get; private set; }
        public Report Report { get; private set; }

        public Task(string description, DateTime deadline, string initiator)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Status = TaskStatus.Assigned;
        }

        public void TakeInWork(string executor)
        {
            Executor = executor;
            Status = TaskStatus.Proccessing;
        }

        public void Delegate(string newExecutor)
        {
            Executor = newExecutor;
            Status = TaskStatus.Assigned;
        }

        public void Reject()
        {
            Executor = null;
            Status = TaskStatus.Assigned;
        }

        public void Complete(string reportText)
        {
            Report = new Report(reportText, DateTime.Now, Executor);
            Status = TaskStatus.Complete;
        }

        public void Review(bool approve)
        {
            if (approve)
            {
                Status = TaskStatus.Complete;
            }
            else
            {
                Status = TaskStatus.Checking;
            }
        }
    }
}
