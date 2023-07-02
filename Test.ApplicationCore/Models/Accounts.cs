using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ApplicationCore.Models
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; }
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
