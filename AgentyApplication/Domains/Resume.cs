using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyApplication.Domains
{
    public class Resume
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Location { get; set; }

        public string[] Skills { get; set; }

        public string Experience { get; set; }
    }
}
