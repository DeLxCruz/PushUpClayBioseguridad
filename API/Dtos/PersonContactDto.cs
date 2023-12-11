using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonContactDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        public int ContactTypeId { get; set; }
    }
}