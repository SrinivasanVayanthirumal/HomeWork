using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ApplicationCore.Models
{
    public class SPCustomerAccountsData
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? FullName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        public bool isFilipino { get; set; }
        public int CustomerId { get; set; }
        [Required]

        public int AccountNumber { get; set; }
        [Required]
        public int AccountType { get; set; }
        [NotMapped]
        public string AccountTypeName { get; set; }
        [Required]

        public string BranchAddress { get; set; }
        [Required]
        public decimal InitialAmount { get; set; }
    }
}
