using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ApplicationCore.Models
{
    public class SPCustomerListPaging
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? FullName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        public bool isFilipino { get; set; }
    }
}
