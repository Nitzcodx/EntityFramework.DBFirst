using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class Credential
    {
        public Credential()
        {
            BranchDetails = new HashSet<BranchDetail>();
            Customers = new HashSet<Customer>();
        }

        public int CredentialId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? RoleId { get; set; }
        public string EmailId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<BranchDetail> BranchDetails { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
