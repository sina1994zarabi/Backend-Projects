using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Entity;

namespace TaskTracker.Contract
{
    public interface ITaskService
    {
        void AddNewTask(string desc);
        
        void UpdateTask(int id,string newDesc);

        void DeleteTask(int id);

        void ChangeStatus(int id,status newStatus);

        void DisplayAllTasks();

        void DisplayCompletedTasks();

        void DisplayInProgressTasks();

        void DisplayFailedTasks();
    }
}
