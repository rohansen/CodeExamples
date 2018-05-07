using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Factories
{
    public class UserFactory : IFactory<IUser>
    {
        //If the input type is the same as the type<> definition for the interface in this class, return true(the factory can create objects of this type)
        public bool AppliesToFactory(Type t)
        {
            return typeof(IUser).Equals(t);
        }

        //Instantiate an object from the concrete class that implements the interface
        public IUser Create()
        {
            return new User();
        }
    }
}
