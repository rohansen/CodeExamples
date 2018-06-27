using MultiServiceProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MultiServiceProblem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "My.goodol.Service1")]
    public interface IService1
    {
        [OperationContract]
        User GetAll();
    }
    
}
