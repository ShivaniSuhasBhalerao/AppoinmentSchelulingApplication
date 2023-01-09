using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace AppoinmentSchelulingProject.Customers
{
    public class Customer : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string Address { get; set; }

        [NotNull]
        public virtual string MobileNumber { get; set; }

        public virtual DateTime AppointmentDate { get; set; }

        public virtual bool VerificationStatus { get; set; }

        public Customer()
        {

        }

        public Customer(Guid id, string name, string address, string mobileNumber, DateTime appointmentDate, bool verificationStatus)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.NotNull(mobileNumber, nameof(mobileNumber));
            Name = name;
            Address = address;
            MobileNumber = mobileNumber;
            AppointmentDate = appointmentDate;
            VerificationStatus = verificationStatus;
        }

    }
}