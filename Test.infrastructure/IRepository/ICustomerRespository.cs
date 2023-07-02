using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ApplicationCore.Models;

namespace Test.infrastructure.IRepository
{
    public interface ICustomerRespository
    {
        // string SaveCustomers(string FirstName, string MiddleName, string LastName, DateTime DateOfBirth, bool isFilipino);
        string SaveCustomers(Customers customerdata);
        Customers GetCustomers(int CustomerId);
        List<Customers> GetAllCustomers();

        string DeleteCustomerInformation(string UserId);
        List<SPCustomerListPaging> GetAllCustomersPaging(int PageNumber, int PageSize);
    } 

}
