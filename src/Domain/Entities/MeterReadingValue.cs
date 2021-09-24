using System;
using WaterMeterManager.Domain.Common;

namespace WaterMeterManager.Domain.Entities
{
    public class MeterReadingValue : AuditableEntity
    {
        public int MeterReadingValueId { get; set; }
        public int MeterId { get; set; }
        public virtual Meter Meter { get; set; }
        public int ReadValue { get; set; }
        public DateTime ReadingDate { get; set; }
    }
}