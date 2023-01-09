using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AppoinmentSchelulingProject.Calenderss;
using AppoinmentSchelulingProject.EntityFrameworkCore;
using Xunit;

namespace AppoinmentSchelulingProject.Calenderss
{
    public class CalendersRepositoryTests : AppoinmentSchelulingProjectEntityFrameworkCoreTestBase
    {
        private readonly ICalendersRepository _calendersRepository;

        public CalendersRepositoryTests()
        {
            _calendersRepository = GetRequiredService<ICalendersRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _calendersRepository.GetListAsync(

                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("8c5d8816-5292-4861-9b37-6bbc272b3f91"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _calendersRepository.GetCountAsync(

                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}