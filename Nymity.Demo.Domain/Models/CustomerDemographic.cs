using System.Collections.Generic;

namespace Nymity.Demo.Domain.Models
{
    public class CustomerDemographic
    {
        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public CustomerDemographic()
        {
            Customers = new List<Customer>();
        }
    }
}
