﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contracttype : BaseEntity
{

    public string Description { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
