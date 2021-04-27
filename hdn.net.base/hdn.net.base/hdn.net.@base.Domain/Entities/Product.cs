﻿using hdn.net._base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace hdn.net._base.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
