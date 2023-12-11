using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repositories
{
    public class AddressTypeRepository(BioSecurityContext context) : GenericRepository<Addresstype>(context), IAddressType
    {
        private readonly BioSecurityContext _context = context;
    }
}