using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace AppoinmentSchelulingProject.Customers
{
    public class CustomerManager : DomainService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CreateAsync(
        string name, string address, string mobileNumber, DateTime appointmentDate, bool verificationStatus)
        {
            var customer = new Customer(
             GuidGenerator.Create(),
             name, address, mobileNumber, appointmentDate, verificationStatus
             );

            return await _customerRepository.InsertAsync(customer);
        }

        public async Task<Customer> UpdateAsync(
            Guid id,
            string name, string address, string mobileNumber, DateTime appointmentDate, bool verificationStatus, [CanBeNull] string concurrencyStamp = null
        )
        {
            var queryable = await _customerRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var customer = await AsyncExecuter.FirstOrDefaultAsync(query);

            customer.Name = name;
            customer.Address = address;
            customer.MobileNumber = mobileNumber;
            customer.AppointmentDate = appointmentDate;
            customer.VerificationStatus = verificationStatus;

            customer.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _customerRepository.UpdateAsync(customer);
        }

    }
}