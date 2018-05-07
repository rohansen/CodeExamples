using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Text_Analytics_API
{
    public class SentimentRequest
    {
        public SentimentRequest()
        {
            Documents = new List<Document>();
        }
        [SerializeAs(Name = "documents")]
        public List<Document> Documents { get; set; }
    }
}
