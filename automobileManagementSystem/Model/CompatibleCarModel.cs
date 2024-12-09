using System;
using System.Collections.Generic;

namespace automobileManagementSystem.Model;

public partial class CompatibleCarModel
{
    public int CompatibilityId { get; set; }

    public int PartId { get; set; }

    public int CarModelId { get; set; }

    public virtual CarModel CarModel { get; set; } = null!;

    public virtual AutoPart Part { get; set; } = null!;
}
