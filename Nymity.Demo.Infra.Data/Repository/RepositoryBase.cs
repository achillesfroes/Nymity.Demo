using Nymity.Demo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Infra.Data.Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected DemoContext Context { get; set; }

        protected DbQuery<T> DbQuery
        {
            get
            {
                return Context.Set<T>().AsQueryable() as DbQuery<T>;
            }
        }

        public RepositoryBase(DemoContext demoContext)
        {
            Context = demoContext;
        }
    }
}
