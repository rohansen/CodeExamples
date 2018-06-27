using MultiServiceProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MultiServiceProblem
{
    [ServiceContract(Namespace = "My.goodol.Service2")]
    public interface IService2
    {
        [OperationContract]
        Pet GetAll();
    }
}
