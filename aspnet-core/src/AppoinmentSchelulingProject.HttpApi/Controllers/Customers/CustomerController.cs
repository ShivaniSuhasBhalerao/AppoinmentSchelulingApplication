using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using AppoinmentSchelulingProject.Customers;

namespace AppoinmentSchelulingProject.Controllers.Customers
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Customer")]
    [Route("api/app/customers")]

    public class CustomerController : AbpController
    {
        private readonly ICustomersAppService _customersAppService;
        private readonly ITwilioSmsSender _ismssender;
        

        public CustomerController(ICustomersAppService customersAppService, ITwilioSmsSender ismssender)
        {
            _customersAppService = customersAppService;
            _ismssender = ismssender;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CustomerDto>> GetListAsync(GetCustomersInput input)
        {
            return _customersAppService.GetListAsync(input);
        }
        [HttpGet("Calender")]
        public virtual async Task<ListResultDto<CustomerDto>> GetAllCalenderAsync(GetCustomersInput input)
        {
            var a= await  _customersAppService.GetAllCalenderAsync(input);
            return a;
        }

        [HttpGet("Upcoming")]
        //[Route("api/accounts/Action")]
        public virtual async Task<PagedResultDto<CustomerDto>> UpcomingAppointment(GetCustomersInput input)
        {
            var abc= await _customersAppService.UpcomingAppointment(input);
            return abc;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CustomerDto> GetAsync(Guid id)
        {
            return _customersAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CustomerDto> CreateAsync(CustomerCreateDto input)
        {
            return _customersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CustomerDto> UpdateAsync(Guid id, CustomerUpdateDto input)
        {
            return _customersAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _customersAppService.DeleteAsync(id);
        }
        //[HttpPost]

        //[Route("{Id}")]
        [HttpGet("messagesend")]
        public virtual async Task SmsSender()
        {

            try
            {
               //await _ismssender.AutoDeleteAsync();
                await _ismssender.getCustomerdataAsync();
                //await _ismssender.UpcomingAppointment();
                //        //var objj = _mapper.Map<>(obj);
                // _ismssender.SendSmsAsync();
                //return null;
            }
            catch (Exception ex)
            {
                //return ex.Message.ToString;
            }
        }



        [HttpGet("autodelete")]
 
        public virtual async Task<ActionResult<PagedResultDto<CustomerDto>>> autodelete()
        {
            try
            {
              var delete=  await _ismssender.AutoDeleteAsync();
                return delete;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Deletedata")]

        public virtual async Task<ActionResult<PagedResultDto<CustomerDto>>> deletedata()
        {
            try
            {
                var delete = await _ismssender.DeletedDataAsync();
                return delete;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}