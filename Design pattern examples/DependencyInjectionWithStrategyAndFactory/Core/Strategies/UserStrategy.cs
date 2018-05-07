using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Factories;

namespace Core.Strategies
{
    public class UserStrategy : IStrategy<IUser>
    {
        public UserStrategy(IEnumerable<IFactory<IUser>> factories)
        {
            Factories = factories;
        }
        public IEnumerable<IFactory<IUser>> Factories { get; set; }

        public IUser Create(Type t)
        {
            //We get the first factory in the collection that can construct objects of the input type(In this example IUser)
            var fac = Factories.FirstOrDefault(x => x.AppliesToFactory(t));//AppliesToFactory is implemented in the concrete factory implementation
            //If no factory was found, throw an exception
            if (fac == null)
                throw new Exception("No factory can handle this type");
            //Otherwise, use that factory to create an instance of the type you asked for
            return fac.Create();
        }
    }
}
