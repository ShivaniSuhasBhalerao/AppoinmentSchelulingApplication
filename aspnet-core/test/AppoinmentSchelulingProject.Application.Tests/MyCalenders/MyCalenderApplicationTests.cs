using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AppoinmentSchelulingProject.MyCalenders
{
    public class MyCalendersAppServiceTests : AppoinmentSchelulingProjectApplicationTestBase
    {
        private readonly IMyCalendersAppService _myCalendersAppService;
        private readonly IRepository<MyCalender, Guid> _myCalenderRepository;

        public MyCalendersAppServiceTests()
        {
            _myCalendersAppService = GetRequiredService<IMyCalendersAppService>();
            _myCalenderRepository = GetRequiredService<IRepository<MyCalender, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _myCalendersAppService.GetListAsync(new GetMyCalendersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("ba092789-a327-4942-a5b7-e5a0f54adf58")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("0e59e5a5-a0e6-425a-9c36-30436bcc345d")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _myCalendersAppService.GetAsync(Guid.Parse("ba092789-a327-4942-a5b7-e5a0f54adf58"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ba092789-a327-4942-a5b7-e5a0f54adf58"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new MyCalenderCreateDto
            {
                AppointmentDate = new DateTime(2021, 5, 11)
            };

            // Act
            var serviceResult = await _myCalendersAppService.CreateAsync(input);

            // Assert
            var result = await _myCalenderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.AppointmentDate.ShouldBe(new DateTime(2021, 5, 11));
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new MyCalenderUpdateDto()
            {
                AppointmentDate = new DateTime(2020, 9, 16)
            };

            // Act
            var serviceResult = await _myCalendersAppService.UpdateAsync(Guid.Parse("ba092789-a327-4942-a5b7-e5a0f54adf58"), input);

            // Assert
            var result = await _myCalenderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.AppointmentDate.ShouldBe(new DateTime(2020, 9, 16));
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _myCalendersAppService.DeleteAsync(Guid.Parse("ba092789-a327-4942-a5b7-e5a0f54adf58"));

            // Assert
            var result = await _myCalenderRepository.FindAsync(c => c.Id == Guid.Parse("ba092789-a327-4942-a5b7-e5a0f54adf58"));

            result.ShouldBeNull();
        }
    }
}