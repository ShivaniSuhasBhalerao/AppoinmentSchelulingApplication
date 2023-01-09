using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AppoinmentSchelulingProject.Customers
{
    public class CustomerUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool VerificationStatus { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}