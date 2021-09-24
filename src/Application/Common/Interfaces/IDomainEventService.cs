using System.Threading.Tasks;
using WaterMeterManager.Domain.Common;

namespace WaterMeterManager.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}