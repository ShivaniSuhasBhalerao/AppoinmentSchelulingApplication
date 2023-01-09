using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AppoinmentSchelulingProject.MyCalenders;

namespace AppoinmentSchelulingProject.MyCalenders
{
    public class MyCalendersDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IMyCalenderRepository _myCalenderRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MyCalendersDataSeedContributor(IMyCalenderRepository myCalenderRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _myCalenderRepository = myCalenderRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _myCalenderRepository.InsertAsync(new MyCalender
            (
                id: Guid.Parse("ba092789-a327-4942-a5b7-e5a0f54adf58"),
                appointmentDate: new DateTime(2013, 10, 13)
            ));

            await _myCalenderRepository.InsertAsync(new MyCalender
            (
                id: Guid.Parse("0e59e5a5-a0e6-425a-9c36-30436bcc345d"),
                appointmentDate: new DateTime(2017, 9, 12)
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}