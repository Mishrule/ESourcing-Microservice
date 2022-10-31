using ESourcing.Sourcing.Entities;
using ESourcing.Sourcing.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESourcing.Sourcing.Data.Interface;
using MongoDB.Driver;

namespace ESourcing.Sourcing.Repositories
{
	public class BidRepository : IBidRepository
	{
		private readonly ISourcingContext _context;

		public BidRepository(ISourcingContext context)
		{
			_context = context;
		}

		public async Task<List<Bid>> GetBidsByAuctionId(string id)
		{
			FilterDefinition<Bid> filter = Builders<Bid>.Filter.Eq(b => b.AuctionId, id);
			List<Bid> bids = await _context.Bids.Find(filter).ToListAsync();
			bids = bids.OrderByDescending(b => b.CreatedAt).GroupBy(b => b.SellerUserName).Select(b => new Bid
			{
				AuctionId = b.FirstOrDefault().AuctionId,
				Price = b.FirstOrDefault().Price,
				CreatedAt = b.FirstOrDefault().CreatedAt,
				SellerUserName = b.FirstOrDefault().SellerUserName,
				ProductId = b.FirstOrDefault().ProductId,
				Id = b.FirstOrDefault().Id
			}).ToList();

			return bids;
		}

		public async Task<Bid> GetWinnerBid(string id)
		{
			List<Bid> bids = await GetBidsByAuctionId(id);
			return bids.FirstOrDefault();
		}

		public async Task SendBid(Bid bid)
		{
			await _context.Bids.InsertOneAsync(bid);
		}
	}
}
