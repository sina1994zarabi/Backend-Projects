using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Entity;

namespace TaskTracker.Contract
{
    public interface ITaskRepository
    {
        void Add(UserTask newTask);
        UserTask GetTask(int taskId);
        List<UserTask> GetAllTasks();
        void Update(int id,UserTask updatedTask);
        string Delete(int id);
        int GetLatestTaskId();
    }
}
