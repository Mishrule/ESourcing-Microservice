﻿using ESourcing.Sourcing.Data.Interface;
using ESourcing.Sourcing.Entities;
using ESourcing.Sourcing.Settings;
using MongoDB.Driver;

namespace ESourcing.Sourcing.Data
{
	public class SourcingContext : ISourcingContext
	{
		public IMongoCollection<Auction> Auctions { get; }
		public IMongoCollection<Bid> Bids { get; }

		public SourcingContext(ISourcingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			Auctions = database.GetCollection<Auction>(nameof(Auction));
			Bids = database.GetCollection<Bid>(nameof(Bid));

			SourcingContextSeed.SeedData(Auctions);

		}
	}
}
