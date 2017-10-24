using Nymity.Demo.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nymity.Demo.Domain.Models;
using Nymity.Demo.Domain.Interfaces.Repository;
using Nymity.Demo.Domain.DTO;
using Nymity.Demo.Domain.Collections;

namespace Nymity.Demo.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderService(IOrderRepository pIOrderRepository, IOrderDetailRepository pOrderDetailRepository)
        {
            orderRepository = pIOrderRepository;
            orderDetailRepository = pOrderDetailRepository;
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            List<OrderDetail> orderDetails = orderDetailRepository.GetByOrder(orderId);
            return orderDetails;
        }

        public PaggedCollection<OrderDTO> GetOrders(int page)
        {
            PaggedCollection<Order> ordersPagged = orderRepository.GetAllPagged(page);

            List<OrderDTO> ordersDTO = ordersPagged.List.Select(o => OrderDTO.ToDTO(o)).ToList();

            PaggedCollection<OrderDTO> ordersDTOPagged = new PaggedCollection<OrderDTO>();

            ordersDTOPagged.TotalCount = ordersPagged.TotalCount;
            ordersDTOPagged.List = ordersDTO;

            return ordersDTOPagged;
        }
    }
}
