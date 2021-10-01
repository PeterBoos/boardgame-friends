using AutoMapper;
using BGF.App.Core.Entities;
using BGF.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public class CompanyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            var companies = _context.Companies.ToList();
            return companies;
        }

        public async Task AddUserToCompany(Guid companyId, Guid userId)
        {
            var company = _context.Companies.SingleOrDefault(e => e.Id == companyId);
            var user = _context.Users.SingleOrDefault(e => e.Id == userId.ToString());

            user.Company = company;
            await _context.SaveChangesAsync();
        }
    }
}
