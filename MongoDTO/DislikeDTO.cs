using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDTO
{
    public class DislikeDTO
    {
        [BsonElement("UserId")]
        public int UserId { get; set; }
    }
}
