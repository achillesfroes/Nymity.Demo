using Nymity.Demo.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nymity.Demo.Domain.Models;
using Nymity.Demo.Domain.Interfaces.Repository;
using Nymity.Demo.Domain.DTO;

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

        public List<OrderDTO> GetOrders(int page)
        {
            List<Order> orders = orderRepository.GetAllPagged(page);

            List<OrderDTO> ordersDTO = orders.Select(o => OrderDTO.ToDTO(o)).ToList();

            return ordersDTO;
        }
    }
}
