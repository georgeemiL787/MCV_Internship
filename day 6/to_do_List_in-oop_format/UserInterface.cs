using System;

namespace ToDoListOOP
{
    public class UserInterface
    {
        private TaskManager taskManager;

        public UserInterface(TaskManager taskManager)
        {
            this.taskManager = taskManager;
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("\n=== TO-DO LIST APPLICATION (OOP Version) ===");
            Console.WriteLine("1. View all tasks");
            Console.WriteLine("2. View pending tasks");
            Console.WriteLine("3. View completed tasks");
            Console.WriteLine("4. Add new task");
            Console.WriteLine("5. Edit task");
            Console.WriteLine("6. Delete task");
            Console.WriteLine("7. Toggle task completion");
            Console.WriteLine("8. Show statistics");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option (1-9): ");
        }

        public void ShowStatistics()
        {
            Console.WriteLine("\n=== TASK STATISTICS ===");
            Console.WriteLine($"Total tasks: {taskManager.GetTaskCount()}");
            Console.WriteLine($"Completed tasks: {taskManager.GetCompletedTaskCount()}");
            Console.WriteLine($"Pending tasks: {taskManager.GetPendingTaskCount()}");
            
            if (taskManager.GetTaskCount() > 0)
            {
                double completionRate = (double)taskManager.GetCompletedTaskCount() / taskManager.GetTaskCount() * 100;
                Console.WriteLine($"Completion rate: {completionRate:F1}%");
            }
        }

        public void HandleViewAllTasks()
        {
            taskManager.ViewAllTasks();
        }

        public void HandleViewPendingTasks()
        {
            taskManager.ViewPendingTasks();
        }

        public void HandleViewCompletedTasks()
        {
            taskManager.ViewCompletedTasks();
        }

        public void HandleAddTask()
        {
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            taskManager.AddTask(description);
        }

        public void HandleEditTask()
        {
            taskManager.ViewAllTasks();
            if (taskManager.GetTaskCount() == 0) return;

            Console.Write("Enter the ID of the task to edit: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                if (taskManager.TaskExists(taskId))
                {
                    Console.Write("Enter new task description: ");
                    string newDescription = Console.ReadLine();
                    taskManager.EditTask(taskId, newDescription);
                }
                else
                {
                    Console.WriteLine($"Task with ID {taskId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID. Please enter a number.");
            }
        }

        public void HandleDeleteTask()
        {
            taskManager.ViewAllTasks();
            if (taskManager.GetTaskCount() == 0) return;

            Console.Write("Enter the ID of the task to delete: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                if (taskManager.TaskExists(taskId))
                {
                    Console.Write("Are you sure you want to delete this task? (y/n): ");
                    string confirmation = Console.ReadLine()?.ToLower();
                    if (confirmation == "y" || confirmation == "yes")
                    {
                        taskManager.DeleteTask(taskId);
                    }
                    else
                    {
                        Console.WriteLine("Task deletion cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine($"Task with ID {taskId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID. Please enter a number.");
            }
        }

        public void HandleToggleTaskCompletion()
        {
            taskManager.ViewAllTasks();
            if (taskManager.GetTaskCount() == 0) return;

            Console.Write("Enter the ID of the task to toggle completion: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                if (taskManager.TaskExists(taskId))
                {
                    taskManager.ToggleTaskCompletion(taskId);
                }
                else
                {
                    Console.WriteLine($"Task with ID {taskId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID. Please enter a number.");
            }
        }

        public void ShowInvalidOptionMessage()
        {
            Console.WriteLine("Invalid option. Please choose a number between 1 and 9.");
        }

        public void ShowExitMessage()
        {
            Console.WriteLine("Thank you for using the To-Do List Application!");
            Console.WriteLine("Your tasks have been saved.");
        }
    }
}