using BackProjectApi.Interfaces;
using BackProjectApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Data
{
    public class companyRepo : ICompanyInterface

    {
        private readonly ApplicationDbContext db;
        public companyRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddCompany(Company company)
        {
            db.Companies.AddAsync(company);
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await db.Companies.Include(c=>c.city).ToListAsync();
        }
    }
}
