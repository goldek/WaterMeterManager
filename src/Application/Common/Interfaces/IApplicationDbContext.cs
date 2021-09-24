using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<MeterReadingValue> MeterReadingValues { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}