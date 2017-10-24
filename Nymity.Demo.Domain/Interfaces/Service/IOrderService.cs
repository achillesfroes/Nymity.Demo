using Nymity.Demo.Domain.DTO;
using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Domain.Interfaces.Service
{
    public interface IOrderService
    {
        List<OrderDTO> GetOrders(int page);

        List<OrderDetail> GetOrderDetailsByOrderId(int orderId);
    }
}
