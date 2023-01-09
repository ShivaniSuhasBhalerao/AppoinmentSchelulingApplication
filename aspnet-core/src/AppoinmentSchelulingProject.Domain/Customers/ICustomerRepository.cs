using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AppoinmentSchelulingProject.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        Task<List<Customer>> GetListAsync(
            string filterText = null,
            string name = null,
            string address = null,
            string mobileNumber = null,
            DateTime? appointmentDateMin = null,
            DateTime? appointmentDateMax = null,
            bool? verificationStatus = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string address = null,
            string mobileNumber = null,
            DateTime? appointmentDateMin = null,
            DateTime? appointmentDateMax = null,
            bool? verificationStatus = null,
            CancellationToken cancellationToken = default);
    }
}