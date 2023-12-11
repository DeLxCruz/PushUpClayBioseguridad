using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace APP.Repositories
{
    public class ContactTypeRepository(BioSecurityContext context) : GenericRepository<Contacttype>(context), IContactType
    {
        private readonly BioSecurityContext _context = context;
    }
}