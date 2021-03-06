﻿using BlockChainWeb.Models.Person;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BlockChainWeb.Models {
	public class BlockChain {

		#region Variables
		[BsonId]
		public int Id { get; set; }
		public string Subject { get; set; }
		public List<Block> Chain { set; get; }
		#endregion

		public BlockChain ( string subject ) {
			InitializeChain(subject);
		}


		public void InitializeChain ( string subject ) {
			Subject = subject;
			Chain = new List<Block>();
			AddGenesisBlock();
		}

		public Block CreateGenesisBlock () {
			Teacher teacher = new Teacher("","",null,"","","");
			Valuation valuation = new Valuation(teacher, 0,"");
			Block block = new Block(DateTime.Now, null, valuation);
			return block;
		}

		public void AddGenesisBlock () {
			Chain.Add(CreateGenesisBlock());
		}

		public Block GetLatestBlock () {
			return Chain[Chain.Count - 1];
		}


		public void AddBlock ( Block block ) {
			Block latestBlock = GetLatestBlock();
			block.Index = latestBlock.Index + 1;
			block.PreviousHash = latestBlock.Hash;
			block.Hash = block.CalculateHash();
			Chain.Add(block);
		}

		public bool IsValid () {
			for(int i = 1; i < Chain.Count; i++) {
				Block currentBlock = Chain[i];
				Block previousBlock = Chain[i - 1];

				if(currentBlock.Hash != currentBlock.CalculateHash()) {
					return false;
				}

				if(currentBlock.PreviousHash != previousBlock.Hash) {
					return false;
				}
			}
			return true;
		}

		public float GetValuation () {
			float valuation = 0;

			foreach(Block block in Chain) {
				valuation += block.Valuation.Amount;
			}

			return valuation;
		}
	}
}