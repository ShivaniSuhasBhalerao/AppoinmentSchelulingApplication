using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AppoinmentSchelulingProject.Customers
{
    public class CustomerCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool VerificationStatus { get; set; }
    }
}