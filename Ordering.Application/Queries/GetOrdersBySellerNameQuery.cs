using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Ordering.Application.Response;

namespace Ordering.Application.Queries
{
	public class GetOrdersBySellerNameQuery: IRequest<IEnumerable<OrderResponse>>
	{
		public string UserName { get; set; }

		public GetOrdersBySellerNameQuery(string userName)
		{
			UserName = userName;
		}
	}
}
