using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AppoinmentSchelulingProject.MyCalenders;
using AppoinmentSchelulingProject.EntityFrameworkCore;
using Xunit;

namespace AppoinmentSchelulingProject.MyCalenders
{
    public class MyCalenderRepositoryTests : AppoinmentSchelulingProjectEntityFrameworkCoreTestBase
    {
        private readonly IMyCalenderRepository _myCalenderRepository;

        public MyCalenderRepositoryTests()
        {
            _myCalenderRepository = GetRequiredService<IMyCalenderRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _myCalenderRepository.GetListAsync(

                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("ba092789-a327-4942-a5b7-e5a0f54adf58"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _myCalenderRepository.GetCountAsync(

                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}