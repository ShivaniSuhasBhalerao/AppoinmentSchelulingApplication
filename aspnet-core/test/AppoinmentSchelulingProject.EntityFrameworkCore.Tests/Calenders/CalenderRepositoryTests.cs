using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AppoinmentSchelulingProject.Calenders;
using AppoinmentSchelulingProject.EntityFrameworkCore;
using Xunit;

namespace AppoinmentSchelulingProject.Calenders
{
    public class CalenderRepositoryTests : AppoinmentSchelulingProjectEntityFrameworkCoreTestBase
    {
        private readonly ICalenderRepository _calenderRepository;

        public CalenderRepositoryTests()
        {
            _calenderRepository = GetRequiredService<ICalenderRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _calenderRepository.GetListAsync(

                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("916413dc-00e7-4217-9c62-6dc8c80b6e95"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _calenderRepository.GetCountAsync(

                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}