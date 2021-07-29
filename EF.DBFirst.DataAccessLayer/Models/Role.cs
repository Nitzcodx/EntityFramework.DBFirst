using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class Role
    {
        public Role()
        {
            Credentials = new HashSet<Credential>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Credential> Credentials { get; set; }
    }
}
