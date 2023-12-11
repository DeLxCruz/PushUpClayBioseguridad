using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contract : BaseEntity
{

    public int? ClientId { get; set; }

    public DateOnly? ContractDate { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? StateId { get; set; }

    public int? ContractTypeId { get; set; }

    public virtual Client Client { get; set; }

    public virtual Contracttype ContractType { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual State State { get; set; }
}
