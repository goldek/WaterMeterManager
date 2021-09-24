using System;
using System.Linq;
using System.Threading.Tasks;
using WaterMeterManager.Domain.Entities;
using WaterMeterManager.Domain.Enums;
using WaterMeterManager.Infrastructure.Persistence;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Buildings.Any())
            {
                context.Buildings.Add(new Building
                {
                    BuildingId = 1,
                    City = "Kraków",
                    Street = "Długa",
                    Number = "22",
                    Apartments =
                    {
                        new Apartment{BuildingId = 1, Number = "1", Area = 46.8,
                            Meters =
                            {
                                new Meter{MeterId = 1, SerialNumber = "1231231", Type = MeterType.HotWater},
                                new Meter{MeterId = 2,SerialNumber = "3331232", Type = MeterType.ColdWater}
                            } },
                        new Apartment{BuildingId = 1, Number = "2", Area = 36.2,
                            Meters =
                            {
                                new Meter{MeterId = 3,SerialNumber = "1231223", Type = MeterType.HotWater},
                                new Meter{MeterId = 4,SerialNumber = "3331224", Type = MeterType.ColdWater}
                            } },
                        new Apartment{BuildingId = 1, Number = "3", Area = 82.7,
                            Meters =
                            {
                                new Meter{MeterId = 5,SerialNumber = "1231289", Type = MeterType.HotWater},
                                new Meter{MeterId = 6,SerialNumber = "3331981", Type = MeterType.ColdWater}
                            } },
                        new Apartment{BuildingId = 1, Number = "4", Area = 53.1,
                            Meters =
                            {
                                new Meter{MeterId = 7,SerialNumber = "1231274", Type = MeterType.ColdWater},
                                new Meter{MeterId = 8,SerialNumber = "4321981", Type = MeterType.HotWater}
                            } },
                        new Apartment{BuildingId = 1, Number = "5", Area = 123.1,
                            Meters =
                            {
                                new Meter{MeterId = 9,SerialNumber = "5431274", Type = MeterType.ColdWater},
                                new Meter{MeterId = 10,SerialNumber = "6721981", Type = MeterType.ColdWater}
                            } },
                    }
                });

                if (!context.MeterReadingValues.Any())
                {
                    Random random = new Random();
                    for (int i = 1; i <= 10; i++)
                    {
                        int readValue = random.Next(0, 15);
                        context.MeterReadingValues.Add(
                            new MeterReadingValue
                            {
                                MeterId = i,
                                ReadingDate = DateTime.Today,
                                ReadValue = readValue
                            });
                        context.Meters.Find(i).LastReadingValue = readValue;
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}