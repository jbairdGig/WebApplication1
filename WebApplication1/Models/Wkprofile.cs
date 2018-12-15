using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Wkprofile
    {
        public int ProfileId { get; set; }
        public int? WorksiteId { get; set; }
        public string BackgroundPic { get; set; }

        public virtual Worksite Worksite { get; set; }
    }
}
