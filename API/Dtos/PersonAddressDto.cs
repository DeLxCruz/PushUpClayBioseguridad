using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonAddressDto
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public int PersonId { get; set; }

        public int AddressTypeId { get; set; }
    }
}