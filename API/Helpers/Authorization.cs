using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            Client,
            Emloyee
        }

        public const Roles rol_default = Roles.Client;
    }
}