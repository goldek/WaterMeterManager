using WaterMeterManager.Domain.Common;
using WaterMeterManager.Domain.Entities;

namespace Domain.Events
{
    public class MeterReadingValueChangedEvent : DomainEvent
    {
        public MeterReadingValueChangedEvent(Meter meter, MeterReadingValue meterReadingValue)
        {
            Meter = meter;
            MeterReadingValue = meterReadingValue;
        }

        public Meter Meter { get; }
        public MeterReadingValue MeterReadingValue { get; }
    }
}