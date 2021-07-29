using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class BranchDetail
    {
        public BranchDetail()
        {
            ChildCareerPolicies = new HashSet<ChildCareerPolicy>();
            PolicyStatuses = new HashSet<PolicyStatus>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? BranchManagerId { get; set; }

        public virtual Credential BranchManager { get; set; }
        public virtual ICollection<ChildCareerPolicy> ChildCareerPolicies { get; set; }
        public virtual ICollection<PolicyStatus> PolicyStatuses { get; set; }
    }
}
