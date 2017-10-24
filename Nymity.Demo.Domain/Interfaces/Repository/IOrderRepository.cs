using Nymity.Demo.Domain.Collections;
using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        PaggedCollection<Order> GetAllPagged(int page);
    }
}
