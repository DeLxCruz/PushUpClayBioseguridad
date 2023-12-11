using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Personaddress : BaseEntity
{

    public string Address { get; set; }

    public int? PersonId { get; set; }

    public int? AddressTypeId { get; set; }

    public virtual Addresstype AddressType { get; set; }

    public virtual Person Person { get; set; }
}
