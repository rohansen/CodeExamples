using SecureService.Domain;
using System.ServiceModel;

namespace SecureService.ServiceLibrary
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        bool Login(string username, string password);
        [OperationContract]
        User LoginABC();
    }
}