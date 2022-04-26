using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbCrud_Sample.Business.Abstract;
using MongoDbCrud_Sample.DataAccess.Context;
using MongoDbCrud_Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbCrud_Sample.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        public readonly IMongoDatabase _mongoDb;
        public StudentManager(IOptions<DbSetting> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _mongoDb = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Student> studentCollections =>
           _mongoDb.GetCollection<Student>("StudentCollection");

        public void Create(Student entity)
        {
            studentCollections.InsertOne(entity);
        }

        public void Delete(string name)
        {
            var filter = Builders<Student>.Filter.Eq(i => i.NameSurname, name);
            studentCollections.DeleteOne(filter);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return studentCollections.Find(i => true).ToList();
        }

        public Student GetStudentById(string studentId)
        {
            return studentCollections.Find(i => i.Id == studentId).FirstOrDefault();
        }

        public Student GetStudentByName(string name)
        {
            return studentCollections.Find(i => i.NameSurname == name).FirstOrDefault();
        }

        public void Update(string id, Student entity)
        {
            var filter = Builders<Student>.Filter.Eq(i => i.Id, id);
            var update = Builders<Student>.Update
               .Set("NameSurname", entity.NameSurname)
               .Set("StudentNumber", entity.StudentNumber)
               .Set("Age", entity.Age);
            studentCollections.UpdateOne(filter, update);
        }
    }
}
