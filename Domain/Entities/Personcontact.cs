using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Personcontact : BaseEntity
{

    public int? PersonId { get; set; }

    public int? ContactTypeId { get; set; }

    public virtual Contacttype ContactType { get; set; }

    public virtual Person Person { get; set; }
}
