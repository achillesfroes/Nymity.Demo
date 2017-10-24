using Ninject.Modules;
using Nymity.Demo.Domain.Interfaces.Service;
using Nymity.Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.IoC
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}
