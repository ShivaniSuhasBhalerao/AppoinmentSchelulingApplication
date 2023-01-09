using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AppoinmentSchelulingProject.Calenderss;

namespace AppoinmentSchelulingProject.Calenderss
{
    public class CalenderssDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICalendersRepository _calendersRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CalenderssDataSeedContributor(ICalendersRepository calendersRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _calendersRepository = calendersRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _calendersRepository.InsertAsync(new Calenders
            (
                id: Guid.Parse("8c5d8816-5292-4861-9b37-6bbc272b3f91"),
                date: new DateTime(2011, 9, 21)
            ));

            await _calendersRepository.InsertAsync(new Calenders
            (
                id: Guid.Parse("87f03efd-69c1-4b67-a334-9cc81f679692"),
                date: new DateTime(2013, 11, 11)
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}