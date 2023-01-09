using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using AppoinmentSchelulingProject.EntityFrameworkCore;

namespace AppoinmentSchelulingProject.Customers
{
    public class EfCoreCustomerRepository : EfCoreRepository<AppoinmentSchelulingProjectDbContext, Customer, Guid>, ICustomerRepository
    {
        public EfCoreCustomerRepository(IDbContextProvider<AppoinmentSchelulingProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Customer>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, address, mobileNumber, appointmentDateMin, appointmentDateMax, verificationStatus);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CustomerConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string address = null,
            string mobileNumber = null,
            DateTime? appointmentDateMin = null,
            DateTime? appointmentDateMax = null,
            bool? verificationStatus = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, address, mobileNumber, appointmentDateMin, appointmentDateMax, verificationStatus);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Customer> ApplyFilter(
            IQueryable<Customer> query,
            string filterText,
            string name = null,
            string address = null,
            string mobileNumber = null,
            DateTime? appointmentDateMin = null,
            DateTime? appointmentDateMax = null,
            bool? verificationStatus = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.Address.Contains(filterText) || e.MobileNumber.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address))
                    .WhereIf(!string.IsNullOrWhiteSpace(mobileNumber), e => e.MobileNumber.Contains(mobileNumber))
                    .WhereIf(appointmentDateMin.HasValue, e => e.AppointmentDate >= appointmentDateMin.Value)
                    .WhereIf(appointmentDateMax.HasValue, e => e.AppointmentDate <= appointmentDateMax.Value)
                    .WhereIf(verificationStatus.HasValue, e => e.VerificationStatus == verificationStatus);
        }
    }
}