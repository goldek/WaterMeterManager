using System.Collections.Generic;
using WaterMeterManager.Domain.Common;

namespace WaterMeterManager.Domain.Entities
{
    public class Building : AuditableEntity
    {
        public int BuildingId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public virtual IList<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}