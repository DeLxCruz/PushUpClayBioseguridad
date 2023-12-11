using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Shift : BaseEntity
{

    public string Name { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
