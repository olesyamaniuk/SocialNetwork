using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDTO
{
    public class CommentDTO
    {
        [BsonElement("CommentId")]
        public int CommentId { get; set; }
        [BsonElement("AuthorId")]
        public int AuthorId { get; set; }
        [BsonElement("Comment")]
        public string CommentText { get; set; }
    }
}
