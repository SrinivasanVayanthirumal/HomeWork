using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ApplicationCore.BusinessModels
{
    public class AccountsTypeEnum
    {
        public enum AccountsType
        {
            [Description("Saving")]
            Saving = 1,
            [Description("Checking")]
            Checking = 2
          
               
           
        }
    }
}
