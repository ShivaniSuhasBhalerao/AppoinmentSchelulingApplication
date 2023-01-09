using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AppoinmentSchelulingProject.Customers
{
    public interface ITwilioSmsSender
    {
        void SendSmsAsync(string to);

        Task<CustomerDto> getCustomerdataAsync();
        Task<PagedResultDto<CustomerDto>> AutoDeleteAsync();

        Task<PagedResultDto<CustomerDto>> DeletedDataAsync();
        void StartTimerAsync();
        void AutodeleteTimerAsync();


        // Task<PagedResultDto<CustomerDto>> UpcomingAppointment(GetCustomersInput input);
    }
}
