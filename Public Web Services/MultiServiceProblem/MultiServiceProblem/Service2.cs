using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiServiceProblem.Models;

namespace MultiServiceProblem
{
    public class Service2 : IService2
    {
        public Pet GetAll()
        {
            Pet p = new Pet();
            return p;

        }
    }
}
