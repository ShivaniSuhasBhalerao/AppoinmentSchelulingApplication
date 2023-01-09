using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AppoinmentSchelulingProject.Customers;
using AppoinmentSchelulingProject.EntityFrameworkCore;
using Xunit;

namespace AppoinmentSchelulingProject.Customers
{
    public class CustomerRepositoryTests : AppoinmentSchelulingProjectEntityFrameworkCoreTestBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRepositoryTests()
        {
            _customerRepository = GetRequiredService<ICustomerRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _customerRepository.GetListAsync(
                    name: "bcc8a0702e194d7b8",
                    address: "cbc4746f43a544eeaa0e8",
                    mobileNumber: "46e664f1bec446c19910309a13f43b9bc376d5864e2b4fa5a8b3eb46d90aff554327cdc5feff4aaa",
                    verificationStatus: true
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("fa5cd9b1-2f33-45b0-9ad3-fc79bb77b814"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _customerRepository.GetCountAsync(
                    name: "4b350ec7b2e04091",
                    address: "b6feabb4e34d454c9e6fb5bfbdbee44e271c7458173a456caca87a3d776d7f2b52a761241f1e46c7966942c4e0b4a2d8",
                    mobileNumber: "39bedb09060745e3bbd76ee14c1276013201e6f907254df69532d7400602bc37cd9f27",
                    verificationStatus: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}