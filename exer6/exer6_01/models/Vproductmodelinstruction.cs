using System;
using System.Collections.Generic;

namespace exer6_01.models;

public partial class Vproductmodelinstruction
{
    public int? Productmodelid { get; set; }

    public string? Name { get; set; }

    public string? Instructions { get; set; }

    public int? LocationId { get; set; }

    public decimal? SetupHours { get; set; }

    public decimal? MachineHours { get; set; }

    public decimal? LaborHours { get; set; }

    public int? LotSize { get; set; }

    public string? Step { get; set; }

    public Guid? Rowguid { get; set; }

    public DateTime? Modifieddate { get; set; }
}
