using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AppoinmentSchelulingProject.Customers;

namespace AppoinmentSchelulingProject.Customers
{
    public class CustomersDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CustomersDataSeedContributor(ICustomerRepository customerRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _customerRepository = customerRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _customerRepository.InsertAsync(new Customer
            (
                id: Guid.Parse("fa5cd9b1-2f33-45b0-9ad3-fc79bb77b814"),
                name: "bcc8a0702e194d7b8",
                address: "cbc4746f43a544eeaa0e8",
                mobileNumber: "46e664f1bec446c19910309a13f43b9bc376d5864e2b4fa5a8b3eb46d90aff554327cdc5feff4aaa",
                appointmentDate: new DateTime(2015, 4, 11),
                verificationStatus: true
            ));

            await _customerRepository.InsertAsync(new Customer
            (
                id: Guid.Parse("503853c9-f4bc-492d-bbdd-70e0a9c2f5c2"),
                name: "4b350ec7b2e04091",
                address: "b6feabb4e34d454c9e6fb5bfbdbee44e271c7458173a456caca87a3d776d7f2b52a761241f1e46c7966942c4e0b4a2d8",
                mobileNumber: "39bedb09060745e3bbd76ee14c1276013201e6f907254df69532d7400602bc37cd9f27",
                appointmentDate: new DateTime(2004, 1, 16),
                verificationStatus: true
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}