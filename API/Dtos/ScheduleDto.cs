using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public int ContractId { get; set; }

        public int ShiftId { get; set; }

        public int EmployeeId { get; set; }
    }
}