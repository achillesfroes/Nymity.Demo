using Nymity.Demo.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nymity.Demo.Domain.Models;
using Nymity.Demo.Infra.Data.Context;
using System.Data.Entity.Infrastructure;
using Nymity.Demo.Domain.Collections;

namespace Nymity.Demo.Infra.Data.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(DemoContext demoContext) : base(demoContext) { }

        public PaggedCollection<Order> GetAllPagged(int page)
        {
            PaggedCollection<Order> ordersPagged = new PaggedCollection<Order>();

            ordersPagged.TotalCount = DbQuery.Count();

            IQueryable<Order> query = DbQuery.Include("Customer").Include("Shipper").Include("Employee").OrderBy(o => o.OrderDate).Skip(page * 10).Take(10);

            ordersPagged.List = query.ToList();

            return ordersPagged;
        }
    }
}
