using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ApplicationCore.BusinessModels
{
    public class RemoteResult<T>
    {
        public T data { get; set; }
        public RemoteException exception { get; set; } = new RemoteException();
        public void SetError(Exception ex)
        {
            if (ex != null)
            {
                exception.message = ex.Message.ToString();
                exception.stackTrace = (ex.StackTrace ?? "").ToString();
            }
                
        }
    }
}
