using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Interfaces
{
   public interface ICityInteface <TEntity>
    {
         Task<IEnumerable<TEntity>> GetCities();

        void addCity(TEntity entity);

        void DeletCity(int id);
    }
}
