using AutoMapper;
using BGF.App.Core.Entities;
using BGF.App.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public class CompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            var companies = _context.Companies.ToList();
            return companies;
        }

        public async Task AddUserToCompany(Guid companyId, string username)
        {
            var company = _context.Companies.SingleOrDefault(e => e.Id == companyId);
            var user = _context.Users.SingleOrDefault(e => e.UserName == username);

            user.Company = company;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Company>> Search(string searchTerm)
        {
            var companies = await _context.Companies
                .Where(e => e.Name.Contains(searchTerm))
                .ToListAsync();

            return companies;
        }
    }
}
