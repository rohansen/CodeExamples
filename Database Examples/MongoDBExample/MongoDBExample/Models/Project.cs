using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDBExample.Models
{
    class Project
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
