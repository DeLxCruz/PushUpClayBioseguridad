using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAddressType AddressTypes { get; }
        ICity Cities { get; }
        IClient Clients { get; }
        IContactType ContactTypes { get; }
        IContract Contracts { get; }
        IContractType ContractTypes { get; }
        ICountry Countries { get; }
        IEmployee Employees { get; }
        IPerson Persons { get; }
        IPersonAddress PersonAddresses { get; }
        IPersonCategory PersonCategories { get; }
        IPersonContact PersonContacts { get; }
        IPersonType PersonTypes { get; }
        IRol Rols { get; }
        ISchedule Schedules { get; }
        IShift Shifts { get; }
        IState States { get; }
        Task<int> SaveAsync();
    }
}