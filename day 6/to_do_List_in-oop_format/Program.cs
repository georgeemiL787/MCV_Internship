using System;

namespace ToDoListOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the To-Do List Application ");
            

            TaskManager taskManager = new TaskManager();
            UserInterface ui = new UserInterface(taskManager);

            while (true)
            {
                ui.ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ui.HandleViewAllTasks();
                        break;
                    case "2":
                        ui.HandleViewPendingTasks();
                        break;
                    case "3":
                        ui.HandleViewCompletedTasks();
                        break;
                    case "4":
                        ui.HandleAddTask();
                        break;
                    case "5":
                        ui.HandleEditTask();
                        break;
                    case "6":
                        ui.HandleDeleteTask();
                        break;
                    case "7":
                        ui.HandleToggleTaskCompletion();
                        break;
                    case "8":
                        ui.ShowStatistics();
                        break;
                    case "9":
                        ui.ShowExitMessage();
                        return;
                    default:
                        ui.ShowInvalidOptionMessage();
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
} 