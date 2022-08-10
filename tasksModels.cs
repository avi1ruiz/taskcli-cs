using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace taskCLI.Models;
class Tasks {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set;}

        [BsonElement("title")]
        public string? title { get; set; }

        [BsonElement("description")]
        public string? description { get; set; }

}