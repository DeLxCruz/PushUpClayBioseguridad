using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace APP.Repositories
{
    public class PersonAddressRepository(BioSecurityContext context) : GenericRepository<Personaddress>(context)
    {
        private readonly BioSecurityContext _context = context;
    }
}