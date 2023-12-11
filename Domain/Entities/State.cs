using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class State : BaseEntity
{

    public string Name { get; set; }

    public int? CountryId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Country Country { get; set; }
}
