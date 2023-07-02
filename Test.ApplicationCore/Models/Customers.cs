using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ApplicationCore.Models
{
    public class Customers
    {
        [Key]
      
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? FullName { get; set; }
       
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        [Required]
        public bool isFilipino { get; set; }
    }
}
