using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            ChildCareerPolicies = new HashSet<ChildCareerPolicy>();
            PolicyStatuses = new HashSet<PolicyStatus>();
            TransactionDetails = new HashSet<TransactionDetail>();
        }

        public int CustId { get; set; }
        public string Gender { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long PinNumber { get; set; }
        public int? CredentialId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Credential Credential { get; set; }
        public virtual ICollection<ChildCareerPolicy> ChildCareerPolicies { get; set; }
        public virtual ICollection<PolicyStatus> PolicyStatuses { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
