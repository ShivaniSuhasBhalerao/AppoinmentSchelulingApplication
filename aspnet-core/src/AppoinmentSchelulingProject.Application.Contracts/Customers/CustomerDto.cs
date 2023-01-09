using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace AppoinmentSchelulingProject.Customers
{
    public class CustomerDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool VerificationStatus { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}