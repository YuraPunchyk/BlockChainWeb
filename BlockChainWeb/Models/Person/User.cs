using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models.Person
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string  Email { get; set; }
        public string UserRole { get; set;}
       

        public User(string id, string email,string fullname,string userRole)
        {
            FullName = fullname;
            Id = id;
            Email = email;
            UserRole = userRole;
        }
    }
}
