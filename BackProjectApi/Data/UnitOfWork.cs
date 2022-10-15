using BackProjectApi.Interfaces;
using BackProjectApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;

        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;

        }
        public ICityInteface<City> cityInteface => new CityRepo(db);

        public ICompanyInterface CompanyInterface => new companyRepo(db);

        public async  Task<bool> SaveAscy()
        {
            return await db.SaveChangesAsync() > 0;
        }
    }
}
