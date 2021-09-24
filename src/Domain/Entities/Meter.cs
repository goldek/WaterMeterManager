using System.Text.Json.Serialization;
using WaterMeterManager.Domain.Common;
using WaterMeterManager.Domain.Enums;

namespace WaterMeterManager.Domain.Entities
{
    public class Meter : AuditableEntity
    {

        public int MeterId { get; set; }
        public string SerialNumber { get; set; }
        public MeterType Type { get; set; }
        public int LastReadingValue { get; set; }
        public int ApartmentId { get; set; }
        [JsonIgnore]
        public virtual Apartment Apartment { get; set; }

    }
}