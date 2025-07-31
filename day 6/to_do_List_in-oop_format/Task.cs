using System;

namespace ToDoListOOP
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }

        public Task(int id, string description)
        {
            Id = id;
            Description = description;
            CreatedDate = DateTime.Now;
            IsCompleted = false;
            CompletedDate = null;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
            CompletedDate = DateTime.Now;
        }

        public void MarkAsIncomplete()
        {
            IsCompleted = false;
            CompletedDate = null;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[✓]" : "[ ]";
            string completedInfo = IsCompleted && CompletedDate.HasValue 
                ? $" (Completed: {CompletedDate.Value:yyyy-MM-dd HH:mm})" 
                : "";
            return $"{Id}. {status} {Description}{completedInfo}";
        }

        public string ToFileString()
        {
            return $"{Id}|{Description}|{CreatedDate:yyyy-MM-dd HH:mm:ss}|{IsCompleted}|{CompletedDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? ""}";
        }

        public static Task FromFileString(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 4)
            {
                int id = int.Parse(parts[0]);
                string description = parts[1];
                DateTime createdDate = DateTime.Parse(parts[2]);
                bool isCompleted = bool.Parse(parts[3]);
                
                Task task = new Task(id, description)
                {
                    CreatedDate = createdDate,
                    IsCompleted = isCompleted
                };

                if (parts.Length > 4 && !string.IsNullOrEmpty(parts[4]))
                {
                    task.CompletedDate = DateTime.Parse(parts[4]);
                }

                return task;
            }
            throw new ArgumentException("Invalid task format in file");
        }
    }
} 