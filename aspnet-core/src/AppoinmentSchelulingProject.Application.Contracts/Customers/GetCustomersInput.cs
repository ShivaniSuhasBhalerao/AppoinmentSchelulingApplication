using Volo.Abp.Application.Dtos;
using System;

namespace AppoinmentSchelulingProject.Customers
{
    public class GetCustomersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? AppointmentDateMin { get; set; }
        public DateTime? AppointmentDateMax { get; set; }
        public bool? VerificationStatus { get; set; }

        public GetCustomersInput()
        {

        }
    }
}