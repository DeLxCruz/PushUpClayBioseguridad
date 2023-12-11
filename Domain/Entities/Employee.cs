using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Employee : BaseEntity
{

    public int? PersonId { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Person Person { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
