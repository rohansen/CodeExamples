using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleServicesOnSamePort
{
    public partial class Service1 : IService2
    {
        public void DoStuff(int i)
        {
            //did stuff
        }
    }
}
