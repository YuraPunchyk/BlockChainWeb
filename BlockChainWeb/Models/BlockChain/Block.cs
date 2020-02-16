using System;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainWeb.Models {
	public class Block {
		#region Variables
		public int Index { get; set; }
		public DateTime TimeStamp { get; set; }
		public string PreviousHash { get; set; }
		public string Hash { get; set; }
		public Valuation Valuation { get; set; }
		#endregion

		public Block ( DateTime timeStamp, string previousHash, Valuation valuation ) {
			Index = 0;
			TimeStamp = timeStamp;
			PreviousHash = previousHash;
			Valuation = valuation;
		}

		public string CalculateHash () {
			SHA256 sha256 = SHA256.Create();

			byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{JsonConvert.SerializeObject(Valuation)}");
			byte[] outputBytes = sha256.ComputeHash(inputBytes);

			return Convert.ToBase64String(outputBytes);
		}
	}
}
