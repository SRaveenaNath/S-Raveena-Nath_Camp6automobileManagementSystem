﻿using System;
using System.Collections.Generic;

namespace automobileManagementSystem.Model;

public partial class AutoPart
{
    public int PartId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal SalePrice { get; set; }

    public int CompanyId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ManufacturingCompany Company { get; set; } = null!;

    public virtual ICollection<CompatibleCarModel> CompatibleCarModels { get; set; } = new List<CompatibleCarModel>();
}
