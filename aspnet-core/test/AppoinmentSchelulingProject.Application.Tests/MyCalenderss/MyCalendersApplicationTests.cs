using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AppoinmentSchelulingProject.MyCalenderss
{
    public class MyCalenderssAppServiceTests : AppoinmentSchelulingProjectApplicationTestBase
    {
        private readonly IMyCalenderssAppService _myCalenderssAppService;
        private readonly IRepository<MyCalenders, Guid> _myCalendersRepository;

        public MyCalenderssAppServiceTests()
        {
            _myCalenderssAppService = GetRequiredService<IMyCalenderssAppService>();
            _myCalendersRepository = GetRequiredService<IRepository<MyCalenders, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _myCalenderssAppService.GetListAsync(new GetMyCalenderssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("2038be00-fdd8-451a-ad87-e78ad100ec23")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("184f0973-2cf5-4704-9d6d-571c5c41b439")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _myCalenderssAppService.GetAsync(Guid.Parse("2038be00-fdd8-451a-ad87-e78ad100ec23"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("2038be00-fdd8-451a-ad87-e78ad100ec23"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new MyCalendersCreateDto
            {
                Date = new DateTime(2012, 4, 15)
            };

            // Act
            var serviceResult = await _myCalenderssAppService.CreateAsync(input);

            // Assert
            var result = await _myCalendersRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Date.ShouldBe(new DateTime(2012, 4, 15));
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new MyCalendersUpdateDto()
            {
                Date = new DateTime(2007, 8, 18)
            };

            // Act
            var serviceResult = await _myCalenderssAppService.UpdateAsync(Guid.Parse("2038be00-fdd8-451a-ad87-e78ad100ec23"), input);

            // Assert
            var result = await _myCalendersRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Date.ShouldBe(new DateTime(2007, 8, 18));
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _myCalenderssAppService.DeleteAsync(Guid.Parse("2038be00-fdd8-451a-ad87-e78ad100ec23"));

            // Assert
            var result = await _myCalendersRepository.FindAsync(c => c.Id == Guid.Parse("2038be00-fdd8-451a-ad87-e78ad100ec23"));

            result.ShouldBeNull();
        }
    }
}