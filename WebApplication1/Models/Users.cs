using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Users
    {
        public Users()
        {
            Worksite = new HashSet<Worksite>();
        }

        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Active { get; set; }

        public virtual ICollection<Worksite> Worksite { get; set; }
    }
}
