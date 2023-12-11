using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.UnitOfWork
{
    public class UnitOfWork(BioSecurityContext context) : IUnitOfWork, IDisposable
    {
        private IAddressType _addressTypes;
        private ICity _cities;
        private ICountry _countries;
        private IEmployee _employees;
        private IPerson _persons;
        private IPersonAddress _personAddresses;
        private IPersonCategory _personCategories;
        private IPersonContact _personContacts;
        private IPersonType _personTypes;
        private ISchedule _schedules;
        private IShift _shifts;
        private IState _states;
        private IClient _clients;
        private IContactType _contactTypes;
        private IContract _contracts;
        private IContractType _contractTypes;
        private IRol _rols;

        private readonly BioSecurityContext _context = context;

        public IAddressType AddressTypes
        {
            get
            {
                _addressTypes ??= new AddressTypeRepository(_context);
                return _addressTypes;
            }
        }

        public ICity Cities
        {
            get
            {
                _cities ??= new CityRepository(_context);
                return _cities;
            }
        }

        public ICountry Countries
        {
            get
            {
                _countries ??= new CountryRepository(_context);
                return _countries;
            }
        }

        public IEmployee Employees
        {
            get
            {
                _employees ??= new EmployeeRepository(_context);
                return _employees;
            }
        }

        public IPerson Persons
        {
            get
            {
                _persons ??= new PersonRepository(_context);
                return _persons;
            }
        }

        public IPersonAddress PersonAddresses
        {
            get
            {
                _personAddresses ??= (IPersonAddress)new PersonAddressRepository(_context);
                return _personAddresses;
            }
        }

        public IPersonCategory PersonCategories
        {
            get
            {
                _personCategories ??= new PersonCategoryRepository(_context);
                return _personCategories;
            }
        }

        public IPersonContact PersonContacts
        {
            get
            {
                _personContacts ??= new PersonContactRepository(_context);
                return _personContacts;
            }
        }

        public IPersonType PersonTypes
        {
            get
            {
                _personTypes ??= new PersonTypeRepository(_context);
                return _personTypes;
            }
        }

        public ISchedule Schedules
        {
            get
            {
                _schedules ??= new ScheduleRepository(_context);
                return _schedules;
            }
        }

        public IShift Shifts
        {
            get
            {
                _shifts ??= new ShiftRepository(_context);
                return _shifts;
            }
        }

        public IState States
        {
            get
            {
                _states ??= new StateRepository(_context);
                return _states;
            }
        }

        public IClient Clients
        {
            get
            {
                _clients ??= new ClientRepository(_context);
                return _clients;
            }
        }

        public IContactType ContactTypes
        {
            get
            {
                _contactTypes ??= new ContactTypeRepository(_context);
                return _contactTypes;
            }
        }

        public IContract Contracts
        {
            get
            {
                _contracts ??= new ContractRepository(_context);
                return _contracts;
            }
        }

        public IContractType ContractTypes
        {
            get
            {
                _contractTypes ??= new ContractTypeRepository(_context);
                return _contractTypes;
            }
        }

        public IRol Rols
        {
            get
            {
                _rols ??= new RolRepository(_context);
                return _rols;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}