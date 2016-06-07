using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Models
{
    public class Command
    {
        public string CommandText { get;set;}
        public string[] Arguments { get; set; }
    }
}
