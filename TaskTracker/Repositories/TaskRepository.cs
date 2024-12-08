using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Contract;
using System.Text.Json;
using TaskTracker.Entity;


namespace TaskTracker.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public string filePath = "C:\\Users\\dell\\Desktop\\BackEnd Development\\ASP.NET Developer\\BackEnd C Sharp\\Mini Projects\\Beginner\\TaskTracker\\File\\Tasks.txt";

        public void Add(UserTask newTask)
        {
            string task = JsonSerializer.Serialize(newTask) + "\n";
            File.AppendAllText(filePath, task);
        }

        public string Delete(int id)
        {
            string[] lines = File.ReadAllLines(filePath);
            string updatedLines = string.Empty;
            foreach (string line in lines)
            {
                UserTask task = JsonSerializer.Deserialize<UserTask>(line);
                if (task.Id != id)
                {
                    updatedLines += line;
                }
            }
            File.WriteAllText(filePath, updatedLines);
            return $"Successfully Deleted This Task";
        }

        public List<UserTask> GetAllTasks()
        {
            List<UserTask> result = new List<UserTask>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                
                result.Add(JsonSerializer.Deserialize<UserTask>(filePath));
            }
            return result;
        }

        public UserTask GetTask(int taskId)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                UserTask task = JsonSerializer.Deserialize<UserTask>(line);
                if (task.Id  == taskId)
                {
                    return task;
                }
            }
            return null;
        }

        public int GetLatestTaskId()
        {
            string[] lines = File.ReadAllLines(filePath);
            int lastIndex = lines.Length - 1;
            UserTask latestTask = JsonSerializer.Deserialize<UserTask>(lines[lastIndex]);
            return latestTask.Id;
        }

        public void Update(int id, UserTask updatedTask)
        {
            string[] lines = File.ReadAllLines(filePath);
            string newLines = string.Empty;
            foreach (var line in lines)
            {
                UserTask task = JsonSerializer.Deserialize<UserTask>(line);
                if (task.Id != id)
                {
                    newLines += line;
                }
            }
            File.WriteAllText(filePath , newLines);
        }
    }
}
