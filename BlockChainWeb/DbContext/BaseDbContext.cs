using BlockChainWeb.Models.Person;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace BlockChainWeb.DbContext
{
    public class BaseDbContext
    {
        public string ConnectionString { get; set; }
        private IMongoClient _client = null;
        public BaseDbContext(string connectionString)
        {
            ConnectionString = connectionString;
            _client = GetConnection(EnumName.DataBase.DbName);
        }

        public IMongoClient GetConnection(string dbName)
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

        public void Insert()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        public List<Student> GetStudentsByGroup()
        {
            return null;
        }

        public List<Student> GetStudentsByCourese()
        {
            return null;
        }

        public Student GetStudentById(int id)
        {
            return null;
        }

        public Teacher GetTeacherById(int id)
        {
            return null;
        }
    }
}
