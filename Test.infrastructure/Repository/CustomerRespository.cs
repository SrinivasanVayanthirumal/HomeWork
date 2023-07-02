using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Test.ApplicationCore.Models;
using Test.infrastructure.IRepository;

using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web;
using System.IO;
using System.Net.Http.Headers;
using System.Data;
using System.Data.Common;


namespace Test.infrastructure.Repository
{
    public class CustomerRespository  :ICustomerRespository
    {
        public TestContext dbContext;
        public string SaveCustomers(Customers customerdata)
        {
            //string result = string.Empty;
            // SheLocationMapping sheLocationMapping = new SheLocationMapping();

            using (var context = new TestContext())
            {
                if (customerdata.Id == 0)
                {
                    Customers customer = new Customers();
                    customer.FirstName = customerdata.FirstName;
                    customer.LastName = customerdata.LastName;
                    customer.MiddleName = customerdata.MiddleName;
                    customer.FullName = customerdata.LastName + " " + customerdata.FirstName + " " + customerdata.MiddleName;
                    customer.DateOfBirth = customerdata.DateOfBirth;
                    DateTime today = DateTime.Today;
                    int years = today.Year - customerdata.DateOfBirth.Year;
                    customer.Age = years;
                    customer.isFilipino = customerdata.isFilipino;
                    context.Add(customer);
                    context.SaveChanges();
                    return "inserted";
                }
                else
                {
                    var result = context.Customers.SingleOrDefault(x => x.Id == customerdata.Id);
                    if (result != null)
                    {
                        result.FirstName = customerdata.FirstName;
                        result.LastName = customerdata.LastName;
                        result.MiddleName = customerdata.MiddleName;
                        result.FullName = customerdata.LastName + " " + customerdata.FirstName + " " + customerdata.MiddleName;
                        result.DateOfBirth = customerdata.DateOfBirth;
                        DateTime today = DateTime.Today;
                        int years = today.Year - customerdata.DateOfBirth.Year;
                        result.Age = years;
                        result.isFilipino = customerdata.isFilipino;
                        context.SaveChanges();
                        return "Updated";
                    }
                    else
                    {
                        return "Customer does not exist";
                    }
                }
               
                
            }
            
        }

        public Customers GetCustomers(int CustomerId)
        {
            Customers customers = new Customers();
            using (var context = new TestContext())
            {
                customers = context.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();

               
            }
            return customers;
        }
        public List<SPCustomerListPaging> GetAllCustomersPaging(int PageNumber, int PageSize)
        {
            using (var context = new TestContext())
            {
                List<SPCustomerListPaging> objallEventList = new List<SPCustomerListPaging>();
                SqlParameter pageNumber = new SqlParameter("@PageNumber", PageNumber);
                SqlParameter pageSize = new SqlParameter("@PageSize", PageSize);
                objallEventList = context.SPCustomerListPaging
    .FromSql($"EXECUTE SPCustomerListPaging @PageNumber={pageNumber},@PageSize={pageSize}")
    .ToList();

                return objallEventList;
            }
        }


            public List<Customers> GetAllCustomers()
        {
            
            using (var context = new TestContext())
            {
                return context.Customers.ToList();

            }
           
        }
        public string DeleteCustomerInformation(string UserId)
        {
            string result = string.Empty;
            // SheLocationMapping sheLocationMapping = new SheLocationMapping();

            using (var context = new TestContext())
            {
                if (Convert.ToInt32(UserId) > 0)
                {
                    var UserInfo = context.Customers.Where(x => x.Id == Convert.ToInt32(UserId)).FirstOrDefault();
                    if (UserInfo != null)
                    {

                        var AccountsInfo = context.Accounts.Where(x => x.CustomerId == Convert.ToInt32(UserId)).ToList();
                        if (AccountsInfo.Count() > 0)
                        {

                            context.Accounts.RemoveRange(AccountsInfo);
                            context.SaveChanges();
                            result = "Deleted";

                        }

                        context.Remove(UserInfo);

                        context.SaveChanges();
                        result = "Deleted";
                    }
                    else
                    {
                        result = "Customer does not exist";
                    }

                }
            }
            


            return result;
        }
    }
}
