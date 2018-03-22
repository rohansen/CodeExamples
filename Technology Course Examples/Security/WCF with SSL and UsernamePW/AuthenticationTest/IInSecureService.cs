using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationTest
{
    [ServiceContract]
    public interface IInSecureService
    {
        [OperationContract]
        string DoSomethingInsecure(string s);
    }
}
