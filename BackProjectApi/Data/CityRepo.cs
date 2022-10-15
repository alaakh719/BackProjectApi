using BackProjectApi.Interfaces;
using BackProjectApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Data
{
    public class CityRepo : ICityInteface<City>
    {
        private readonly ApplicationDbContext db;
        public CityRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void addCity(City entity)
        {
            db.Cities.AddAsync(entity);
        }

        public void DeletCity(int id)
        {
            var city = db.Cities.Find(id);
            db.Cities.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await db.Cities.ToListAsync();
        }

    
    }
}
