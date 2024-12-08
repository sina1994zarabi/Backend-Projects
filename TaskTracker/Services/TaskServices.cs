using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Contract;
using TaskTracker.Entity;
using TaskTracker.Repositories;

namespace TaskTracker.Services
{
    public class TaskServices : ITaskService
    {
        ITaskRepository taskRepository;

        public TaskServices()
        {
            taskRepository = new TaskRepository();
        }

        public void AddNewTask(string desc)
        {

            UserTask task = new UserTask { Id = taskRepository.GetLatestTaskId() + 1,
                                           Description  =  desc,
                                           Status = status.InProgress,
                                           Createdat = DateTime.Now};
            taskRepository.Add(task);
        }

        public void ChangeStatus(int id, status newStatus)
        {
            UserTask taskToUpdate = taskRepository.GetTask(id);
            taskToUpdate.Status = newStatus;
            taskRepository.Update(id, taskToUpdate);
        }

        public void DeleteTask(int id)
        {
            taskRepository.Delete(id);
        }

        public void DisplayAllTasks()
        {
            List<UserTask> userTasks = taskRepository.GetAllTasks();
            foreach (var item in userTasks)
            {
                Console.WriteLine($"Id : {item.Id} - Description : {item.Description} - Status : {item.Status.ToString()}\n");
            }
        }

        public void DisplayCompletedTasks()
        {
            List<UserTask> userTasks = taskRepository.GetAllTasks();
            foreach (var item in userTasks)
            {
                if (item.Status == status.Done)
                {
                    Console.WriteLine($"Id : {item.Id} - Description : {item.Description} - Status : {item.Status.ToString()}\n");
                }
            }
        }

        public void DisplayFailedTasks()
        {
            List<UserTask> userTasks = taskRepository.GetAllTasks();
            foreach (var item in userTasks)
            {
                if (item.Status == status.Todo)
                {
                    Console.WriteLine($"Id : {item.Id} - Description : {item.Description} - Status : {item.Status.ToString()}\n");
                }
            };
        }

        public void DisplayInProgressTasks()
        {
            List<UserTask> userTasks = taskRepository.GetAllTasks();
            foreach (var item in userTasks)
            {
                if (item.Status == status.InProgress)
                {
                    Console.WriteLine($"Id : {item.Id} - Description : {item.Description} - Status : {item.Status.ToString()}\n");
                }
            };
        }

        public void UpdateTask(int id, string newDesc)
        {
            UserTask taskToUpdate = taskRepository.GetTask(id);
            taskToUpdate.Description = newDesc;
            taskRepository.Update(id,taskToUpdate);
        }
    }
}
