using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCollection.Models
{
    public class UserInputData
    {
        public int UserInputDataId { get; set; }
        public string SourceURL { get; set; }
        public string KeyStrokes { get; set; }
        public string MousePositions { get; set; }
        public DateTime CollectedDate { get; set; }
        public Element Element { get; set; }
    }
}