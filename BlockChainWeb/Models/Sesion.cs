using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models {
	public class Sesion {
		[BsonId]
		public Guid Guid { get; set; } 
		public string IdUer { get; set; }
	}
}