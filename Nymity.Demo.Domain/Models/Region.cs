using System.Collections.Generic;

namespace Nymity.Demo.Domain.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public ICollection<Territory> Territories { get; set; }

        public Region()
        {
            Territories = new List<Territory>();
        }
    }
}
