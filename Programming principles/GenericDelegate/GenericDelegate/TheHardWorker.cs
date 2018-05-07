using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
    public class TheHardWorker<T> where T : IUser
    {
        public delegate void WorkDoneCallback(T entity);

        public void Create(T user, WorkDoneCallback callback)
        {
            //SAVING USER IN DATABASE!
            string UserNameSavedInDatabase = user.Name; //Can only be done on T, because T is(:) an IUser
            callback(user);
        }
    }
}
