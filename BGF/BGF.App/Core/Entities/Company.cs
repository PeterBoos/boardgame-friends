using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Core.Entities
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public List<User> Members { get; set; }
    }
}
