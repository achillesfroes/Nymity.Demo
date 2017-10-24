using Nymity.Demo.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nymity.Demo.Domain.Models;
using Nymity.Demo.Infra.Data.Context;
using System.Data.Entity.Infrastructure;

namespace Nymity.Demo.Infra.Data.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(DemoContext demoContext) : base(demoContext) { }

        public List<Order> GetAllPagged(int page)
        {
            IQueryable<Order> query = DbQuery.Include("Customer").Include("Shipper").Include("Employee").OrderBy(o => o.OrderDate).Skip(page * 10).Take(10);

            return query.ToList();
        }
    }
}
