using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeTask
{
    class Project
    {
        public string Description { get; }
        public DateTime Deadline { get; }
        public string Initiator { get; }
        public string TeamLead { get; }
        public List<Task> Tasks { get; }
        public ProjectStatus Status { get; private set; }

        public Project(string description, DateTime deadline, string initiator, string teamLead)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            TeamLead = teamLead;
            Tasks = new List<Task>();
            Status = ProjectStatus.Project;
        }

        public void AddTask(Task task)
        {
            if (Status == ProjectStatus.Project)
            {
                Tasks.Add(task);
            }
            else
            {
                throw new InvalidOperationException("Задачи могут быть добавлены только тогда, когда проект находится в статусе 'Проект'.");
            }
        }

        public void StartExecution()
        {
            if (Status == ProjectStatus.Project && Tasks.Count > 0)
            {
                Status = ProjectStatus.Execution;
            }
            else
            {
                throw new InvalidOperationException("Проект должен иметь задачи и находиться в статусе 'Проект', чтобы начать выполнение.");
            }
        }

        public bool IsCompleted()
        {
            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.Complete)
                {
                    return false;
                }
            }
            Status = ProjectStatus.Closed;
            return true;
        }
    }
}
