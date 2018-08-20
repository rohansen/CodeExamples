using SecureService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.Controllers
{
    public interface IAuthorizeUserController<T> : IController<T> where T : User
    {
        T Login(string username, string password);
    }
}
