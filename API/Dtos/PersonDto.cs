using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string PersonId { get; set; }

        public string Name { get; set; }

        public DateOnly RegistrationDate { get; set; }

        public int PersonTypeId { get; set; }

        public int PersonCategoryId { get; set; }

        public int CityId { get; set; }

        public int UserId { get; set; }
    }
}