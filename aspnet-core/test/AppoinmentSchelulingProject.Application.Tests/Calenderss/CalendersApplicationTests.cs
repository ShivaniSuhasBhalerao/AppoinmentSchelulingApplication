using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AppoinmentSchelulingProject.Calenderss
{
    public class CalenderssAppServiceTests : AppoinmentSchelulingProjectApplicationTestBase
    {
        private readonly ICalenderssAppService _calenderssAppService;
        private readonly IRepository<Calenders, Guid> _calendersRepository;

        public CalenderssAppServiceTests()
        {
            _calenderssAppService = GetRequiredService<ICalenderssAppService>();
            _calendersRepository = GetRequiredService<IRepository<Calenders, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _calenderssAppService.GetListAsync(new GetCalenderssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("8c5d8816-5292-4861-9b37-6bbc272b3f91")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("87f03efd-69c1-4b67-a334-9cc81f679692")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _calenderssAppService.GetAsync(Guid.Parse("8c5d8816-5292-4861-9b37-6bbc272b3f91"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("8c5d8816-5292-4861-9b37-6bbc272b3f91"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CalendersCreateDto
            {
                Date = new DateTime(2012, 9, 19)
            };

            // Act
            var serviceResult = await _calenderssAppService.CreateAsync(input);

            // Assert
            var result = await _calendersRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Date.ShouldBe(new DateTime(2012, 9, 19));
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CalendersUpdateDto()
            {
                Date = new DateTime(2005, 2, 11)
            };

            // Act
            var serviceResult = await _calenderssAppService.UpdateAsync(Guid.Parse("8c5d8816-5292-4861-9b37-6bbc272b3f91"), input);

            // Assert
            var result = await _calendersRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Date.ShouldBe(new DateTime(2005, 2, 11));
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _calenderssAppService.DeleteAsync(Guid.Parse("8c5d8816-5292-4861-9b37-6bbc272b3f91"));

            // Assert
            var result = await _calendersRepository.FindAsync(c => c.Id == Guid.Parse("8c5d8816-5292-4861-9b37-6bbc272b3f91"));

            result.ShouldBeNull();
        }
    }
}