using BGF.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public class BggService
    {
        private readonly ApplicationDbContext _dbContext;
        public BggService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task UpdateUsersBggGamesList()
        {
            
        }
    }
}
