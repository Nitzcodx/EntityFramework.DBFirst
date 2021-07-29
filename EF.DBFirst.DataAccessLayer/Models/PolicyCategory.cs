using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class PolicyCategory
    {
        public string PolicyType { get; set; }
        public string PolicyCategoryId { get; set; }
        public string PolicyCategoryName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public virtual Policy PolicyTypeNavigation { get; set; }
    }
}
