using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace BlockChainWeb.DbContext
{
    public class BaseDbContext
    {
        public string ConnectionString { get; set; }

        public BaseDbContext(string connectionString)
        {
            ConnectionString = connectionString;
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
    }
}
