using Ninject.Activation;
using Ninject.Modules;
using Nymity.Demo.Domain.Interfaces.Repository;
using Nymity.Demo.Domain.Interfaces.Service;
using Nymity.Demo.Infra.Data.Context;
using Nymity.Demo.Infra.Data.Repository;
using Nymity.Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.IoC
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderDetailRepository>().To<OrderDetailRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<DemoContext>().To<DemoContext>();
        }
    }
}
