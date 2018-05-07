using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.Collections.Generic;

namespace Microsoft_Text_Analytics_API
{
    public class Document
    {
        [SerializeAs(Name = "document")]
        public string Language { get; set; }
        [SerializeAs(Name = "id")]
        public string Id { get; set; }
        [SerializeAs(Name = "text")]
        public string Text { get; set; }

        [SerializeAs(Name = "score")]
        public double Score { get; set; }
        [SerializeAs(Name = "detectedLanguages")]
        [DeserializeAs(Name = "detectedLanguages")]
        public List<Language> DetectedLanguages { get; set; }

    }
}