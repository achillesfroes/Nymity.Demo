using System.Collections.Generic;

namespace Nymity.Demo.Domain.Models
{
    public class Territory
    {
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Region Region { get; set; }

        public Territory()
        {
            Employees = new List<Employee>();
        }
    }
}
