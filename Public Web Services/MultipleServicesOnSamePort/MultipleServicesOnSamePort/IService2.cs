using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MultipleServicesOnSamePort
{
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        void DoStuff(int i);
    }
}
