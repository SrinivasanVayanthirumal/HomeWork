using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ApplicationCore.Models;
using Test.ApplicationCore.BusinessModels;
using Test.infrastructure.IRepository;
using static Test.infrastructure.Repository.AccountsRepository;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Test.infrastructure.Repository
{
    public class AccountsRepository :IAccountsRepository
    {
        public  TestContext dbContext;
        public string SaveAccounts(int CustomerId, int AccountNumber, int AccountType, string BranchAddress, int InitialAmount)
        {
            string result = string.Empty;
            // SheLocationMapping sheLocationMapping = new SheLocationMapping();

            using (var context = new TestContext())
            {
                Accounts accounts = new Accounts();
                accounts.CustomerId = CustomerId;
                accounts.AccountNumber = AccountNumber;
                accounts.AccountType = AccountType;
                accounts.BranchAddress = BranchAddress;
                accounts.InitialAmount = InitialAmount;
                context.Add(accounts);
                context.SaveChanges();
                result= accounts.Id.ToString();
            }
            return result;
        }

        public string SaveAccounts(Accounts Accountsdata)
        {
            using (var context = new TestContext())
            {
                if (Accountsdata.Id == 0)
                {
                    var cusresult = context.Customers.SingleOrDefault(x => x.Id == Accountsdata.CustomerId);
                    if (cusresult != null)
                    {
                        Accounts accounts = new Accounts();
                        accounts.CustomerId = Accountsdata.CustomerId;
                        accounts.AccountNumber = Accountsdata.AccountNumber;
                        accounts.AccountType = Accountsdata.AccountType;
                        accounts.BranchAddress = Accountsdata.BranchAddress;
                        accounts.InitialAmount = Accountsdata.InitialAmount;
                        context.Add(accounts);
                        context.SaveChanges();
                        return "inserted";
                    }
                    else
                    {
                        return "Customer Id is not available";

                    }
                }
                else
                {
                    var result = context.Accounts.SingleOrDefault(x => x.Id == Accountsdata.Id);
                    if (result != null)
                    {

                        result.CustomerId = Accountsdata.CustomerId;
                        result.AccountNumber = Accountsdata.AccountNumber;
                        result.AccountType = Accountsdata.AccountType;
                        result.BranchAddress = Accountsdata.BranchAddress;
                        context.SaveChanges();
                        return "Updated";

                    }
                    else
                    {
                        return "Account does not exist";

                    }
                }
                    
            }

        }

        public List<SPCustomerAccountsData> GetCustomerAccounts(int CustomerId)
        {
            using (var context = new TestContext())
            {

                List<SPCustomerAccountsData> CustomerAccounts = new List<SPCustomerAccountsData>();
                SqlParameter customerId = new SqlParameter("@CustomerId", CustomerId);
                CustomerAccounts = context.SPCustomerAccountsData
    .FromSql($"EXECUTE SPCustomerAccountsData @CustomerId={customerId}")
    .ToList();


                foreach (var cusacc in CustomerAccounts)
                {
                    if (cusacc.AccountType == 1)
                        cusacc.AccountTypeName = AccountsTypeEnum.AccountsType.Saving.ToString();
                    else
                        cusacc.AccountTypeName = AccountsTypeEnum.AccountsType.Checking.ToString();
                }
                return CustomerAccounts;

            }
            
        }

        public List<Accounts> GetAllAccounts()
        {
            using (var context = new TestContext())
            {
                List<Accounts> AccList = new List<Accounts>();
                AccList= context.Accounts.ToList();
                foreach(var acc in AccList)
                {
                    if (acc.AccountType == 1)
                        acc.AccountTypeName = AccountsTypeEnum.AccountsType.Saving.ToString();
                    else
                        acc.AccountTypeName = AccountsTypeEnum.AccountsType.Checking.ToString();
                }
                return AccList;   

            }

        }
        public string DeleteAccountsInformation(string CustomerId)
        {
            string result = string.Empty;
            
            using (var context = new TestContext())
            {
                if (Convert.ToInt32(CustomerId) > 0)
                {
                    var AccountsInfo = context.Accounts.Where(x => x.CustomerId == Convert.ToInt32(CustomerId)).ToList();
                    if (AccountsInfo.Count() >0)
                    {

                        context.Accounts.RemoveRange(AccountsInfo);
                        context.SaveChanges();
                        result = "Deleted Successfully";

                    }
                    else
                    {
                        result = "Customer Accounts does not exist";
                    }
                }
            }
            

            return result;
        }


    }
}
