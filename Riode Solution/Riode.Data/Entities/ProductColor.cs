﻿using Riode.WebUI.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.WebUI.Models.Entities
{
    public class ProductColor : BaseEntity
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}