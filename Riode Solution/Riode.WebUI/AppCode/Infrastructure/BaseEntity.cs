﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Infrastructure
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatedById { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public int? DeletedById { get; set; }
        public DateTime? DeletedDate { get; set; } = DateTime.UtcNow.AddHours(4);

    }
}
