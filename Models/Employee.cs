using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.Models //Employeee modeli 
{
    public class Employee
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Name can only be 50 characters long")]
        public string Name { get; set; }

        public bool IsComplete { get; set; } ///silinebilir

    }
}
