using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationTest
{
    public class InSecureService : IInSecureService
    {
        public string DoSomethingInsecure(string s)
        {
            return "Did something insecure: " + s;
        }
    }
}
