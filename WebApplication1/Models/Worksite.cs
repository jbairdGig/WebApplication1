using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Worksite
    {
        public Worksite()
        {
            Wkprofile = new HashSet<Wkprofile>();
        }

        public int WorksiteId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Wkprofile> Wkprofile { get; set; }
    }
}
