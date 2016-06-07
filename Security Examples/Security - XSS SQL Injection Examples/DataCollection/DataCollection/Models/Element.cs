using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCollection.Models
{
    public class Element
    {

        public int ElementId { get; set; }
        public string ElementTagName { get; set; }
        public string ElementType { get; set; }
        public string NameAttribute { get; set; }
        public string IdAttribute { get; set; }
        public string ClassAttribute { get; set; }
        
    }
}