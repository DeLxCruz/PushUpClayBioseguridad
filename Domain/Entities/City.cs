using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class City : BaseEntity
{

    public string Name { get; set; }

    public int? StateId { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual State State { get; set; }
}
