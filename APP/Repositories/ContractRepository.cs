using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace APP.Repositories
{
    public class ContractRepository(BioSecurityContext context) : GenericRepository<Contract>(context), IContract
    {
        private readonly BioSecurityContext _context = context;
    }
}