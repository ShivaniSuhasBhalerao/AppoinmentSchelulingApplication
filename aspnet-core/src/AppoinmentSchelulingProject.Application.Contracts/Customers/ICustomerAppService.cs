using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AppoinmentSchelulingProject.Customers
{
    public interface ICustomersAppService : IApplicationService
    {
        Task<PagedResultDto<CustomerDto>> GetListAsync(GetCustomersInput input);

        Task<ListResultDto<CustomerDto>> GetAllCalenderAsync(GetCustomersInput input);

        Task<CustomerDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CustomerDto> CreateAsync(CustomerCreateDto input);

        Task<CustomerDto> UpdateAsync(Guid id, CustomerUpdateDto input);

        Task<PagedResultDto<CustomerDto>> UpcomingAppointment(GetCustomersInput input);


    }
}