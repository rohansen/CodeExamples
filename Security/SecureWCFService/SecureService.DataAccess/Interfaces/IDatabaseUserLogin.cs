using SecureService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.DataAccess.Interfaces
{
    public interface IDatabaseUserLogin<T> : IDatabaseCrud<T> where T : User
    {
        event Action<string> LoginAttempt;
        event Action<string> InvalidLoginAttempt;
        User Login(string username, string password);
    }
}
