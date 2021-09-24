using System.Collections.Generic;
using System.Text.Json.Serialization;
using WaterMeterManager.Domain.Common;

namespace WaterMeterManager.Domain.Entities
{
    public class Apartment : AuditableEntity
    {
        public int ApartmentId { get; set; }
        public string Number { get; set; }
        public double Area { get; set; }
        public virtual IList<Meter> Meters { get; set; } = new List<Meter>();
        public int BuildingId { get; set; }
        [JsonIgnore]
        public virtual Building Building { get; set; }
    }
}