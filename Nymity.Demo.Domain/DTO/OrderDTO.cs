using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Domain.DTO
{
    public class OrderDTO
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string OrderDate { get; set; }
        public string ShipperName { get; set; }
        public string SellerName { get; set; }

        public static OrderDTO ToDTO(Order order)
        {
            OrderDTO orderDTO = new OrderDTO();
            orderDTO.CompanyName = order.Customer.CompanyName;
            orderDTO.ContactName = order.Customer.ContactName;
            orderDTO.ShipperName = order.Shipper.CompanyName;
            orderDTO.SellerName = $"{order.Employee.LastName},{order.Employee.FirstName}";
            orderDTO.OrderDate = order.OrderDate?.ToShortDateString() ?? null;

            return orderDTO;
        }
    }
}
