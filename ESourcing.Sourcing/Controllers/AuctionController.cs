﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESourcing.Sourcing.Entities;
using ESourcing.Sourcing.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ILogger = DnsClient.Internal.ILogger;
using LoggerExtensions = DnsClient.Internal.LoggerExtensions;

namespace ESourcing.Sourcing.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class AuctionController : ControllerBase
	{
		private readonly IAuctionRepository _auctionRepository;
		private readonly ILogger<AuctionController> _logger;

		public AuctionController(IAuctionRepository auctionRepository, ILogger<AuctionController> logger)
		{
			_auctionRepository = auctionRepository;
			_logger = logger;
		}


		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Auction>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Auction>>> GetAuctions()
		{
			var auctions = await _auctionRepository.GetAuctions();
			return Ok(auctions);
		}

		[HttpGet("{id:length(24)}", Name = "GetAuction")]
		[ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<ActionResult<Auction>> GetAuction(string id)
		{
			var auctions = await _auctionRepository.GetAuction(id);
			if (auctions == null)
			{
				_logger.LogError( $"Auction with id: {id} was not found in database");
				return NotFound();
			}
			return Ok(auctions);
		}

		[HttpPost]
		[ProducesResponseType(typeof(Auction), (int)HttpStatusCode.Created)]
		public async Task<ActionResult<Auction>> CreateAuction([FromBody] Auction auction)
		{
			 await _auctionRepository.Create(auction);
			return CreatedAtRoute("GetAuction", new {id=auction.Id}, auction);
		}

		[HttpPut]
		[ProducesResponseType(typeof(Auction), (int)HttpStatusCode.Created)]
		public async Task<ActionResult<Auction>> UpdateAuction([FromBody] Auction auction)
		{
			
			return Ok(await _auctionRepository.Update(auction));
		}

		[HttpDelete("{id:length(24)}")]
		[ProducesResponseType(typeof(Auction), (int)HttpStatusCode.Created)]
		public async Task<ActionResult<Auction>>DeleteAuctionById(string id)
		{

			return Ok(await _auctionRepository.Delete(id));
		}

	}
}
