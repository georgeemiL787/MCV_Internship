using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoListOOP
{
    public class TaskManager
    {
        private List<Task> tasks;
        private string filename;
        private int nextId;

        public TaskManager(string filename = "tasks.txt")
        {
            this.filename = filename;
            this.tasks = new List<Task>();
            this.nextId = 1;
            LoadTasks();
        }

        public void LoadTasks()
        {
            tasks.Clear();
            if (File.Exists(filename))
            {
            
                    string[] lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            Task task = Task.FromFileString(line);
                            tasks.Add(task);
                            if (task.Id >= nextId)
                            {
                                nextId = task.Id + 1;
                            }
                        }
                    }
            
            }
        }

        public void SaveTasks()
        {
        
                List<string> lines = tasks.Select(t => t.ToFileString()).ToList();
                File.WriteAllLines(filename, lines);
            
        
        }

        public void AddTask(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                Task newTask = new Task(nextId++, description);
                tasks.Add(newTask);
                SaveTasks();
                Console.WriteLine($"Task added with ID: {newTask.Id}");
            }
            else
            {
                Console.WriteLine("Task description cannot be empty.");
            }
        }

        public void EditTask(int taskId, string newDescription)
        {
            Task task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                if (!string.IsNullOrWhiteSpace(newDescription))
                {
                    task.Description = newDescription;
                    SaveTasks();
                    Console.WriteLine("Task updated successfully.");
                }
                else
                {
                    Console.WriteLine("Task description cannot be empty.");
                }
            }
            else
            {
                Console.WriteLine($"Task with ID {taskId} not found.");
            }
        }

        public void DeleteTask(int taskId)
        {
            Task task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                tasks.Remove(task);
                SaveTasks();
                Console.WriteLine($"Task '{task.Description}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Task with ID {taskId} not found.");
            }
        }

        public void ToggleTaskCompletion(int taskId)
        {
            Task task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                if (task.IsCompleted)
                {
                    task.MarkAsIncomplete();
                    Console.WriteLine($"Task '{task.Description}' marked as incomplete.");
                }
                else
                {
                    task.MarkAsCompleted();
                    Console.WriteLine($"Task '{task.Description}' marked as completed.");
                }
                SaveTasks();
            }
            else
            {
                Console.WriteLine($"Task with ID {taskId} not found.");
            }
        }

        public void ViewAllTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            Console.WriteLine("\n--- All Tasks ---");
            foreach (Task task in tasks.OrderBy(t => t.Id))
            {
                Console.WriteLine(task.ToString());
            }
        }

        public void ViewCompletedTasks()
        {
            var completedTasks = tasks.Where(t => t.IsCompleted).OrderBy(t => t.Id);
            if (!completedTasks.Any())
            {
                Console.WriteLine("No completed tasks found.");
                return;
            }

            Console.WriteLine("\n--- Completed Tasks ---");
            foreach (Task task in completedTasks)
            {
                Console.WriteLine(task.ToString());
            }
        }

        public void ViewPendingTasks()
        {
            var pendingTasks = tasks.Where(t => !t.IsCompleted).OrderBy(t => t.Id);
            if (!pendingTasks.Any())
            {
                Console.WriteLine("No pending tasks found.");
                return;
            }

            Console.WriteLine("\n--- Pending Tasks ---");
            foreach (Task task in pendingTasks)
            {
                Console.WriteLine(task.ToString());
            }
        }

        public int GetTaskCount()
        {
            return tasks.Count;
        }

        public int GetCompletedTaskCount()
        {
            return tasks.Count(t => t.IsCompleted);
        }

        public int GetPendingTaskCount()
        {
            return tasks.Count(t => !t.IsCompleted);
        }

        public bool TaskExists(int taskId)
        {
            return tasks.Any(t => t.Id == taskId);
        }
    }
} 