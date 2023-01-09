using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AppoinmentSchelulingProject.Customers
{
    public class CustomersAppServiceTests : AppoinmentSchelulingProjectApplicationTestBase
    {
        private readonly ICustomersAppService _customersAppService;
        private readonly IRepository<Customer, Guid> _customerRepository;

        public CustomersAppServiceTests()
        {
            _customersAppService = GetRequiredService<ICustomersAppService>();
            _customerRepository = GetRequiredService<IRepository<Customer, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _customersAppService.GetListAsync(new GetCustomersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("fa5cd9b1-2f33-45b0-9ad3-fc79bb77b814")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("503853c9-f4bc-492d-bbdd-70e0a9c2f5c2")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _customersAppService.GetAsync(Guid.Parse("fa5cd9b1-2f33-45b0-9ad3-fc79bb77b814"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("fa5cd9b1-2f33-45b0-9ad3-fc79bb77b814"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CustomerCreateDto
            {
                Name = "df0966dd9ee747f7ad244ec2df0e142bd74d2ba3bca94ae1b56e6ce39357cbd",
                Address = "0ec44b",
                MobileNumber = "034d7c5362fa41e492c4c8ab80802870e2bac08343794a1180f31ce21a85ff7f6648f2dcc00740f4a052f5a1674e32ba",
                AppointmentDate = new DateTime(2017, 2, 24),
                VerificationStatus = true
            };

            // Act
            var serviceResult = await _customersAppService.CreateAsync(input);

            // Assert
            var result = await _customerRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("df0966dd9ee747f7ad244ec2df0e142bd74d2ba3bca94ae1b56e6ce39357cbd");
            result.Address.ShouldBe("0ec44b");
            result.MobileNumber.ShouldBe("034d7c5362fa41e492c4c8ab80802870e2bac08343794a1180f31ce21a85ff7f6648f2dcc00740f4a052f5a1674e32ba");
            result.AppointmentDate.ShouldBe(new DateTime(2017, 2, 24));
            result.VerificationStatus.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CustomerUpdateDto()
            {
                Name = "d7eeb194e1e",
                Address = "55f6d561b2aa48b38cfe959d6cbebe08b8c125875adf4e2",
                MobileNumber = "28e347b0763947a9b165cb325fa6c2a405c1dee5bd304346a1e1e9e8b8a6763b4aef41d9f2fa49bdad922a5267d",
                AppointmentDate = new DateTime(2013, 3, 1),
                VerificationStatus = true
            };

            // Act
            var serviceResult = await _customersAppService.UpdateAsync(Guid.Parse("fa5cd9b1-2f33-45b0-9ad3-fc79bb77b814"), input);

            // Assert
            var result = await _customerRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("d7eeb194e1e");
            result.Address.ShouldBe("55f6d561b2aa48b38cfe959d6cbebe08b8c125875adf4e2");
            result.MobileNumber.ShouldBe("28e347b0763947a9b165cb325fa6c2a405c1dee5bd304346a1e1e9e8b8a6763b4aef41d9f2fa49bdad922a5267d");
            result.AppointmentDate.ShouldBe(new DateTime(2013, 3, 1));
            result.VerificationStatus.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _customersAppService.DeleteAsync(Guid.Parse("fa5cd9b1-2f33-45b0-9ad3-fc79bb77b814"));

            // Assert
            var result = await _customerRepository.FindAsync(c => c.Id == Guid.Parse("fa5cd9b1-2f33-45b0-9ad3-fc79bb77b814"));

            result.ShouldBeNull();
        }
    }
}