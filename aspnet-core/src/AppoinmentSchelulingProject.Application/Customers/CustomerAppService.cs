using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using AppoinmentSchelulingProject.Permissions;
using AppoinmentSchelulingProject.Customers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppoinmentSchelulingProject.Customers
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AppoinmentSchelulingProjectPermissions.Customers.Default)]
    public class CustomersAppService : ApplicationService, ICustomersAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerManager _customerManager;


        public CustomersAppService(ICustomerRepository customerRepository, CustomerManager customerManager)
        {
            _customerRepository = customerRepository;
            _customerManager = customerManager;
        }

        public virtual async Task<PagedResultDto<CustomerDto>> GetListAsync(GetCustomersInput input)
        {
            var totalCount = await _customerRepository.GetCountAsync(input.FilterText, input.Name, input.Address, input.MobileNumber, input.AppointmentDateMin, input.AppointmentDateMax, input.VerificationStatus);
            var items = await _customerRepository.GetListAsync(input.FilterText, input.Name, input.Address, input.MobileNumber, input.AppointmentDateMin, input.AppointmentDateMax, input.VerificationStatus, input.Sorting, input.MaxResultCount, input.SkipCount);
            var autodelete = (from a in items
                              where a.AppointmentDate.Date == DateTime.Now.AddDays(-1).Date
                              select a).AsEnumerable().ToList();
            if (autodelete.Count != 0)
            {

                foreach (var item in autodelete)
                {
                    await _customerRepository.DeleteAsync(item.Id);

                }

            }


            return new PagedResultDto<CustomerDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(items)
            };
        }

        public virtual async Task<ListResultDto<CustomerDto>> GetAllCalenderAsync(GetCustomersInput input)
        {
            //var totalCount = await _customerRepository.GetCountAsync(input.FilterText, input.Name, input.Address, input.MobileNumber, input.AppointmentDateMin, input.AppointmentDateMax, input.VerificationStatus);
            var items = await _customerRepository.GetListAsync(input.FilterText, input.Name, input.Address, input.MobileNumber, input.AppointmentDateMin, input.AppointmentDateMax, input.VerificationStatus, input.Sorting, input.MaxResultCount, input.SkipCount);
            var autodelete = (from a in items
                              where a.AppointmentDate.Date == DateTime.Now.AddDays(-1).Date
                              select a).AsEnumerable().ToList();
            if (autodelete.Count != 0)
            {

                foreach (var item in autodelete)
                {
                    await _customerRepository.DeleteAsync(item.Id);
                }

            }

            return new ListResultDto<CustomerDto>
            {

                Items = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(items)
            };
        }
        public virtual async Task<CustomerDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Customer, CustomerDto>(await _customerRepository.GetAsync(id));
        }

        [Authorize(AppoinmentSchelulingProjectPermissions.Customers.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        [Authorize(AppoinmentSchelulingProjectPermissions.Customers.Create)]
        public virtual async Task<CustomerDto> CreateAsync(CustomerCreateDto input)
        {
            
            var customer = await _customerManager.CreateAsync(
            input.Name, input.Address, input.MobileNumber, input.AppointmentDate, input.VerificationStatus
            );

            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }

        [Authorize(AppoinmentSchelulingProjectPermissions.Customers.Edit)]
        public virtual async Task<CustomerDto> UpdateAsync(Guid id, CustomerUpdateDto input)
        {

            var customer = await _customerManager.UpdateAsync(
            id,
            input.Name, input.Address, input.MobileNumber, input.AppointmentDate, input.VerificationStatus, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }




        public virtual async Task<PagedResultDto<CustomerDto>> UpcomingAppointment(GetCustomersInput input)
        {

            //var totalCount = await _customerRepository.GetCountAsync(input.FilterText, input.Name, input.Address, input.MobileNumber, input.AppointmentDateMin, input.AppointmentDateMax, input.VerificationStatus);
            //var items = await _customerRepository.GetListAsync(input.FilterText, input.Name, input.Address, input.MobileNumber, input.AppointmentDateMin, input.AppointmentDateMax, input.VerificationStatus, input.Sorting, input.MaxResultCount, input.SkipCount);

            //return new PagedResultDto<CustomerDto>
            //{
            //    TotalCount = totalCount,
            //    Items = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(items)
            //};
            IQueryable<Customer> queryable = await _customerRepository.GetQueryableAsync();

            var customer = (from b in queryable
                            where b.AppointmentDate.Date == DateTime.Now.AddDays(+1).Date
                            select b).ToList();
            return new PagedResultDto<CustomerDto>
            {

                Items = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customer)
            };

       var OccupiedTables = Table.Where(r => r.Status == "Occupied").Count()



    }
}