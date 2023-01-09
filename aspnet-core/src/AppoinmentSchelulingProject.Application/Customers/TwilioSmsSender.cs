using AppoinmentSchelulingProject.EntityFrameworkCore;
using AppoinmentSchelulingProject.Permissions;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;

namespace AppoinmentSchelulingProject.Customers
{
    public class TwilioSmsSender : ApplicationService, ITwilioSmsSender
    {
        private readonly IConfiguration _configuration;
        //        // private readonly IMapper _mapper;
        private readonly IDataFilter _dataFilter;
        IRepository<Customer, Guid> _dbContextProvider;
        ICustomerRepository _icustomerRepository;
        AppoinmentSchelulingProjectDbContext _bd;



        //        //DbContextOptions<AppointmentSchedularProjectDbContext> options = new DbContextOptions<AppointmentSchedularProjectDbContext>();

        public TwilioSmsSender(IConfiguration configuration, IDataFilter dataFilter, ICustomerRepository icustomerRepository,

            AppoinmentSchelulingProjectDbContext bd,
            IRepository<Customer, Guid> dbContextProvider)
        {
            _dataFilter = dataFilter;
            _configuration = configuration;
            _dbContextProvider = dbContextProvider;
            _icustomerRepository = icustomerRepository;
            _bd = bd;
            //            //_mapper = Mapper;

        }

        public async Task<CustomerDto> getCustomerdataAsync()
        {
            IQueryable<Customer> queryable = await _dbContextProvider.GetQueryableAsync();
            //            //var context = new AppointmentSchedularProjectDbContext(options);
            var customer = (from b in queryable
                            where b.AppointmentDate.Date == DateTime.Now.AddDays(+1).Date
                            //where b.AppointmentDate== "2022 - 09 - 15 00:00:00.0000000"
                            select b).AsEnumerable().ToList();


            // select b).ToList();
            //            //var CustDto = _mapper.Map<AppointmentDto>(customer);
            //            var CustDto = ObjectMapper.Map<Appointment, AppointmentDto>(customer);

            foreach (var item in customer)
            {
                SendSmsAsync(item.MobileNumber);
            }
            return null;
        }

        public void StartTimerAsync()
        {
            Timer newTimer = new Timer();
            newTimer.Interval = 86400000;
            newTimer.Elapsed += DisplayTimeEvent;
            newTimer.AutoReset = true;
            newTimer.Enabled = true;
            newTimer.Start();
        }
        public  void AutodeleteTimerAsync()
        {
            Timer newTimer2 = new Timer();
            newTimer2.Interval = 60000;
            newTimer2.Elapsed +=  AutodeleteAsync;
            newTimer2.AutoReset = true;
            newTimer2.Enabled = true;
            newTimer2.Start();
        }

        public  void AutodeleteAsync(object source, ElapsedEventArgs s)
        {
            AutoDeleteAsync();
        }
        public  void DisplayTimeEvent(object source, ElapsedEventArgs s)
        {
            getCustomerdataAsync();
        
        }




        public void SendSmsAsync(string to)
        {
            var accountSid = _configuration["TwilioSmsSettings:AccountSId"];
            var authToken = _configuration["TwilioSmsSettings:AuthToken"];
            var phoneNumber = _configuration["TwilioSmsSettings:TwilioPhoneNumber"];
            TwilioClient.Init(accountSid, authToken);

            //var messageOptions = new CreateMessageOptions(
            //    new PhoneNumber("+9181xxxxxxxx"));
            //            var message = MessageResource.Create(messageOptions);
            //            var context = new AppointmentSchedularProjectDbContext(options);
            //            var customers = context.Appointments;
            //           foreach(var p in Appointments)
            //{

            //        }
            try
            {
                MessageResource response = MessageResource.Create(
                        body: "Appointment Confirmed",
                      from: phoneNumber,
                      //  to: "+918421721966"
                      to: to


                     );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //[Authorize(AppoinmentSchelulingProjectPermissions.Customers.Delete)]
        public async Task<PagedResultDto<CustomerDto>> AutoDeleteAsync()
        {

            IQueryable<Customer> queryable = await _dbContextProvider.GetQueryableAsync();
            var customer = (from b in queryable
                            where b.AppointmentDate.Date == DateTime.Now.AddDays(-1).Date
                            select b).AsEnumerable().ToList();



            foreach (var item in customer)
            {
                await _dbContextProvider.DeleteAsync(item.Id);

            }

            return new PagedResultDto<CustomerDto>
            {
                Items = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customer)
            };
        }


        public async Task<PagedResultDto<CustomerDto>> DeletedDataAsync()
        {


            //IQueryable<Customer> queryable = await _dbContextProvider.GetQueryableAsync();
            ////var queryable= _bd.Customers.ToList();
            //var customer = (from b in queryable
            //                where b.IsDeleted.Equals(1)
            //                select b).AsEnumerable().ToList();


            using (_dataFilter.Disable<ISoftDelete>())
            {
                IQueryable<Customer> queryable = await _dbContextProvider.GetQueryableAsync();
                //var queryable= _bd.Customers.ToList();
                var customer = (from b in queryable
                                where b.IsDeleted == true
                                select b).AsEnumerable().ToList();

                return new PagedResultDto<CustomerDto>
                {
                    Items = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customer)
                };
            }
        }


    }


}
