

using BlockChainWeb.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BlockChainWeb.DbContext
{
    public class DbContext:BaseDbContext
    {
        private IMongoClient _client = null;
        public DbContext(string connectionString):base(connectionString)
        {

        }

       

    }
}
