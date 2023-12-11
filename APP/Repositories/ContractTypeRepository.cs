using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace APP.Repositories
{
    public class ContractTypeRepository(BioSecurityContext context) : GenericRepository<Contracttype>(context), IContractType
    {
        private readonly BioSecurityContext _context = context;
    }
}