using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AppoinmentSchelulingProject.Calenders;

namespace AppoinmentSchelulingProject.Calenders
{
    public class CalendersDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICalenderRepository _calenderRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CalendersDataSeedContributor(ICalenderRepository calenderRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _calenderRepository = calenderRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _calenderRepository.InsertAsync(new Calender
            (
                id: Guid.Parse("916413dc-00e7-4217-9c62-6dc8c80b6e95"),
                date: new DateTime(2007, 4, 9)
            ));

            await _calenderRepository.InsertAsync(new Calender
            (
                id: Guid.Parse("fcd21957-f77b-4b14-ab9f-a6bab160ddce"),
                date: new DateTime(2006, 10, 15)
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}