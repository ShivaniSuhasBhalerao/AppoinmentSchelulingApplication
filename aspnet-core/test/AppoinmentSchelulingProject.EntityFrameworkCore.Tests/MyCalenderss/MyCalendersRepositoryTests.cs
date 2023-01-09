using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AppoinmentSchelulingProject.MyCalenderss;
using AppoinmentSchelulingProject.EntityFrameworkCore;
using Xunit;

namespace AppoinmentSchelulingProject.MyCalenderss
{
    public class MyCalendersRepositoryTests : AppoinmentSchelulingProjectEntityFrameworkCoreTestBase
    {
        private readonly IMyCalendersRepository _myCalendersRepository;

        public MyCalendersRepositoryTests()
        {
            _myCalendersRepository = GetRequiredService<IMyCalendersRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _myCalendersRepository.GetListAsync(

                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("2038be00-fdd8-451a-ad87-e78ad100ec23"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _myCalendersRepository.GetCountAsync(

                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}