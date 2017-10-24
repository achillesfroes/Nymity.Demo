using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nymity.Demo.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Nymity.Demo.Domain.Models;
using Nymity.Demo.Domain.Collections;
using Nymity.Demo.Domain.DTO;

namespace Nymity.Demo.Service.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        private OrderService orderService;
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderDetailRepository;

        [TestInitialize]
        public void Init()
        {
            orderRepository = Substitute.For<IOrderRepository>();
            orderDetailRepository = Substitute.For<IOrderDetailRepository>();
            orderService = new OrderService(orderRepository, orderDetailRepository);
        }

        [TestMethod]
        public void CheckTotalCountTest()
        {
            #region Arrange
            PaggedCollection<Order> paddegOrders = CreatePaggedCollection();
            #endregion

            #region MockResult
            orderRepository.GetAllPagged(1).Returns(paddegOrders);
            #endregion

            #region Act
            PaggedCollection<OrderDTO> result = orderService.GetOrders(1);
            #endregion

            #region Asset
            Assert.IsTrue(result.List.Count == 10);
            #endregion
        }

        private PaggedCollection<Order> CreatePaggedCollection()
        {
            List<Order> orders = new List<Order>();

            for (int i = 1; i <= 10; i++)
            {
                orders.Add(new Order()
                {
                    OrderId = i,
                    Customer = new Customer()
                    {
                        CompanyName = "Company " + i,
                        ContactName = "Contact " + i
                    },
                    Shipper = new Shipper()
                    {
                        CompanyName = "Shipper " + i
                    },
                    Employee = new Employee() { FirstName = "FirstName " + i, LastName = "LastName " + i }
                });
            }

            PaggedCollection<Order> paddegOrders = new PaggedCollection<Order>(orders);

            return paddegOrders;
        }
    }
}