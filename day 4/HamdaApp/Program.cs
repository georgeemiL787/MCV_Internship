using System;
using System.IO;
using System.Collections.Generic;

namespace hamda1
{
    class Program
    {
        static string filename = "tasks.txt";
        static List<string> tasks = new List<string>();

        static void Main(string[] args)
        {
            LoadTasks();
            while (true)
            {
                Console.WriteLine("\n--- TO-DO LIST MENU ---");
                Console.WriteLine("1. View tasks");
                Console.WriteLine("2. Add task");
                Console.WriteLine("3. Edit task");
                Console.WriteLine("4. Delete task");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        EditTask();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        SaveTasks();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void LoadTasks()
        {
            tasks.Clear();
            if (File.Exists(filename))
            {
                tasks.AddRange(File.ReadAllLines(filename));
            }
        }

        static void SaveTasks()
        {
            File.WriteAllLines(filename, tasks);
        }

        static void ViewTasks()
        {
            Console.WriteLine("\n--- Your Tasks ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Enter new task: ");
            string newTask = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTask))
            {
                tasks.Add(newTask);
                SaveTasks();
                Console.WriteLine("Task added.");
            }
            else
            {
                Console.WriteLine("Task cannot be empty.");
            }
        }

        static void EditTask()
        {
            ViewTasks();
            if (tasks.Count == 0) return;
            Console.Write("Enter the number of the task to edit: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= tasks.Count)
            {
                Console.Write("Enter new content: ");
                string newContent = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newContent))
                {
                    tasks[num - 1] = newContent;
                    SaveTasks();
                    Console.WriteLine("Task updated.");
                }
                else
                {
                    Console.WriteLine("Task cannot be empty.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        static void DeleteTask()
        {
            ViewTasks();
            if (tasks.Count == 0) return;
            Console.Write("Enter the number of the task to delete: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= tasks.Count)
            {
                tasks.RemoveAt(num - 1);
                SaveTasks();
                Console.WriteLine("Task deleted.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
    }
}
