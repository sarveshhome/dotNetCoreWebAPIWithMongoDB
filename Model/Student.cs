using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DotNetCoreWebAPIWithMongoDB.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public int Age { get; set; }
    }

}