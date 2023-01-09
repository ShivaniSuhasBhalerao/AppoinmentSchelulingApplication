using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AppoinmentSchelulingProject.Calenders
{
    public class CalendersAppServiceTests : AppoinmentSchelulingProjectApplicationTestBase
    {
        private readonly ICalendersAppService _calendersAppService;
        private readonly IRepository<Calender, Guid> _calenderRepository;

        public CalendersAppServiceTests()
        {
            _calendersAppService = GetRequiredService<ICalendersAppService>();
            _calenderRepository = GetRequiredService<IRepository<Calender, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _calendersAppService.GetListAsync(new GetCalendersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("916413dc-00e7-4217-9c62-6dc8c80b6e95")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("fcd21957-f77b-4b14-ab9f-a6bab160ddce")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _calendersAppService.GetAsync(Guid.Parse("916413dc-00e7-4217-9c62-6dc8c80b6e95"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("916413dc-00e7-4217-9c62-6dc8c80b6e95"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CalenderCreateDto
            {
                Date = new DateTime(2013, 9, 23)
            };

            // Act
            var serviceResult = await _calendersAppService.CreateAsync(input);

            // Assert
            var result = await _calenderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Date.ShouldBe(new DateTime(2013, 9, 23));
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CalenderUpdateDto()
            {
                Date = new DateTime(2005, 3, 10)
            };

            // Act
            var serviceResult = await _calendersAppService.UpdateAsync(Guid.Parse("916413dc-00e7-4217-9c62-6dc8c80b6e95"), input);

            // Assert
            var result = await _calenderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Date.ShouldBe(new DateTime(2005, 3, 10));
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _calendersAppService.DeleteAsync(Guid.Parse("916413dc-00e7-4217-9c62-6dc8c80b6e95"));

            // Assert
            var result = await _calenderRepository.FindAsync(c => c.Id == Guid.Parse("916413dc-00e7-4217-9c62-6dc8c80b6e95"));

            result.ShouldBeNull();
        }
    }
}