using System.ComponentModel.DataAnnotations;

namespace taskapp.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public int Salary { get; set; }
    }
} 