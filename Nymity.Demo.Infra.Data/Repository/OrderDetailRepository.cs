using Nymity.Demo.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nymity.Demo.Domain.Models;
using Nymity.Demo.Infra.Data.Context;

namespace Nymity.Demo.Infra.Data.Repository
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DemoContext demoContext) : base(demoContext) { }

        public List<OrderDetail> GetByOrder(int id)
        {
            IQueryable<OrderDetail> orderDatailQuery = DbQuery.Include("Product").Where(od => od.OrderId == id);

            return orderDatailQuery.ToList();
        }
    }
}
