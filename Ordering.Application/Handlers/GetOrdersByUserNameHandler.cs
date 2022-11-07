using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Response;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Handlers
{
	public class GetOrdersByUserNameHandler: IRequestHandler<GetOrdersBySellerNameQuery, IEnumerable<OrderResponse>>
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;

		public GetOrdersByUserNameHandler(IOrderRepository orderRepository, IMapper mapper)
		{
			_orderRepository = orderRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<OrderResponse>> Handle(GetOrdersBySellerNameQuery request, CancellationToken cancellationToken)
		{
			var orderList = await _orderRepository.GetOrderBySellerUserName(request.UserName);
			var response = _mapper.Map<IEnumerable<OrderResponse>>(orderList);
			return response;
		}
	}
}
