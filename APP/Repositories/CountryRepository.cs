using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repositories
{
    public class CountryRepository(BioSecurityContext context) : GenericRepository<Country>(context), ICountry
    {
        private readonly BioSecurityContext _context = context;
    }
}