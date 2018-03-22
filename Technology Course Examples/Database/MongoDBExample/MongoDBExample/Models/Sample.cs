using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDBExample.Models
{
    public class Sample
    {
        public ObjectId Id { get; set; }
        public ArrayAmplification ArrayAmplification { get; set; }
        public Project Project { get; set; }

    }
}