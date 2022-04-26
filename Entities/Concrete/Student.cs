using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbCrud_Sample.Entities.Concrete
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int StudentNumber { get; set; }
        public string NameSurname { get; set; }
        public int Age { get; set; }        
    }
}
