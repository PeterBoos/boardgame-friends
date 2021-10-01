using BGF.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Models.User
{
    public class CompanyViewModel
    {
        public Company CurrentCompany { get; set; }

        public List<Company> AllCompanies { get; set; }
    }
}
