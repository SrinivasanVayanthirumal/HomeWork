using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ApplicationCore.Models;

namespace Test.infrastructure.IRepository
{
    public interface IAccountsRepository
    {
        string SaveAccounts(int CustomerId, int AccountNumber, int AccountType, string BranchAddress, int InitialAmount);

        string SaveAccounts(Accounts Accountsdata);
        List<SPCustomerAccountsData> GetCustomerAccounts(int CustomerId);
        List<Accounts> GetAllAccounts();

        string DeleteAccountsInformation(string CustomerId);
    }
}