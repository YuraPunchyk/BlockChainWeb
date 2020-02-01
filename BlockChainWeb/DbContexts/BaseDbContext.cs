using BlockChainWeb.Models.Person;
using MongoDB.Bson;
using MongoDB.Driver;
using NHibernate.Engine;
using System;
using System.Collections.Generic;

namespace BlockChainWeb.DbContexts
{
    public class BaseDbContext
    {
        public string ConnectionString { get; set; }
        private IMongoClient _client = null;
        public BaseDbContext(string connectionString)
        {
            ConnectionString = connectionString;
            _client = GetConnection();
        }

        public IMongoClient GetConnection()
        {
            try
            {
                var url = new MongoUrl(ConnectionString);
                return new MongoClient(url);
            }
            catch(ArgumentException e)
            {
                e.GetBaseException();
            }
            return null;
        }

        public Login Register(string id,string password)
        {
            FilterDefinition<Login> filter = Builders<Login>.Filter.Eq(x=>x.Id,id);
            filter &= Builders<Login>.Filter.Eq(x=>x.Password,password);
            var database = _client.GetDatabase(EnumName.DataBase.DbName);
            var collection = database.GetCollection<Login>(EnumName.Collection.LoginsCollection);
            var login = collection.Find(filter).ToList();
            if(login.Count==1)
            {
                return new Login
                {
                    Id = login[0].Id,
                    Password = login[0].Password,
                    IsAdmin = login[0].IsAdmin,
                    IsStudent = login[0].IsStudent,
                    IsTeacher = login[0].IsTeacher,
                    IsLogin = true
                };
            }
            
            return null;
        }
        public void UpdateLogin(Login login)
        {
            var filter = Builders<Login>.Filter.Eq(x => x.Id, login.Id);
            filter &= Builders<Login>.Filter.Eq(x => x.Password, login.Password);
            var database = _client.GetDatabase(EnumName.DataBase.DbName);
            var collection = database.GetCollection<Login>(EnumName.Collection.LoginsCollection);
            var data = Builders<Login>.Update.Set(x=>x.IsLogin,login.IsLogin);
            collection.UpdateOne(filter, data);
        }
        public void SetUser(Login login)
        {
            var database = _client.GetDatabase(EnumName.DataBase.DbName);
            var collection = database.GetCollection<Login>(EnumName.Collection.LoginsCollection);
            collection.InsertOne(login);
        }
       

        public List<Student> GetStudentsByGroup(int group)
        {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(x => x.Group, group);
            var database = _client.GetDatabase(EnumName.DataBase.DbName);
            var collection = database.GetCollection<Student>(EnumName.Collection.StudentCollection);
            var students = collection.Find(filter).ToList();
            return students;
        }

        public List<Student> GetStudentsByCourese(int courese)
        {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(x => x.Course, courese);
            var database = _client.GetDatabase(EnumName.DataBase.DbName);
            var collection = database.GetCollection<Student>(EnumName.Collection.StudentCollection);
            var students = collection.Find(filter).ToList();
            return students;
        }

        public Student GetStudentById(string id)
        {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(x => x.Id, id);
            var database = _client.GetDatabase(EnumName.DataBase.DbName);
            var collection = database.GetCollection<Student>(EnumName.Collection.StudentCollection);
            var student = collection.Find(filter).ToList();
            if (student.Count == 1)
            {
                return new Student(student[0].FullName,student[0].Faculty,student[0].Cathedra,student[0].Course,student[0].Group,
                    student[0].Id,student[0].Email,student[0].Subjects);
            }
            return null;
        }

        public Teacher GetTeacherById(string id)
        {
            FilterDefinition<Teacher> filter = Builders<Teacher>.Filter.Eq(x => x.Id, id);
            var database = _client.GetDatabase(EnumName.DataBase.DbName);
            var collection = database.GetCollection<Teacher>(EnumName.Collection.TeacherCollection);
            var teacher = collection.Find(filter).ToList();
            if (teacher.Count == 1)
            {
                return new Teacher(teacher[0].FullName, teacher[0].Faculty,teacher[0].Subjects, teacher[0].Cathedra,
                    teacher[0].Id, teacher[0].Email);
            }
            return null;
        }
    }
}
