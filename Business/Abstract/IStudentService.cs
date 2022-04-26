using MongoDB.Driver;
using MongoDbCrud_Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbCrud_Sample.Business.Abstract
{
    public interface IStudentService
    {
        IMongoCollection<Student> studentCollections { get; }
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(string studentId);
        Student GetStudentByName(string name);
        void Create(Student entity);
        void Update(string id, Student entity);
        void Delete(string name);
    }
}
