using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Text_Analytics_API
{
    public class Language
    {
        [SerializeAs(Name="name")]
        public string Name { get; set; }
        [SerializeAs(Name = "iso6391Name")]
        public string ISO6391Name { get; set; }
        [SerializeAs(Name = "score")]
        public double Score { get; set; }
    }
}
