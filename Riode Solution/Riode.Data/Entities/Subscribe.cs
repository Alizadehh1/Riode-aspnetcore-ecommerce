using Riode.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.Entities
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; }
        public bool EmailSended { get; set; } = false;
        public DateTime? AppliedDate { get; set; }
    }
}
