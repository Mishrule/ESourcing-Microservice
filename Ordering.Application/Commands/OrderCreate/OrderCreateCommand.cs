﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Ordering.Application.Response;

namespace Ordering.Application.Commands.OrderCreate
{
	public class OrderCreateCommand :IRequest<OrderResponse>
	{
		public string AuctionId { get; set; }
		public string SellerUserName { get; set; }
		public string ProductId { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime CreateAt { get; set; }
	}
}