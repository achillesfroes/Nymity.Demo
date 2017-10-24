using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Domain.Collections
{
    public class PaggedCollection<T> where T: class
    {
        public List<T> List { get; set; }

        public PaggedCollection()
        {
        }

        public PaggedCollection(List<T> list)
        {
            List = list;
            TotalCount = List.Count();
        }

        public int? TotalCount { get; set; }
    }
}
