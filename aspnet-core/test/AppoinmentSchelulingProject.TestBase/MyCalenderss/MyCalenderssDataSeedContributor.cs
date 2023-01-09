using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AppoinmentSchelulingProject.MyCalenderss;

namespace AppoinmentSchelulingProject.MyCalenderss
{
    public class MyCalenderssDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IMyCalendersRepository _myCalendersRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MyCalenderssDataSeedContributor(IMyCalendersRepository myCalendersRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _myCalendersRepository = myCalendersRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _myCalendersRepository.InsertAsync(new MyCalenders
            (
                id: Guid.Parse("2038be00-fdd8-451a-ad87-e78ad100ec23"),
                date: new DateTime(2015, 4, 16)
            ));

            await _myCalendersRepository.InsertAsync(new MyCalenders
            (
                id: Guid.Parse("184f0973-2cf5-4704-9d6d-571c5c41b439"),
                date: new DateTime(2002, 3, 15)
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}