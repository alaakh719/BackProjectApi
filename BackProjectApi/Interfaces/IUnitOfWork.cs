using BackProjectApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Interfaces
{
   public interface IUnitOfWork
    {
        ICityInteface<City> cityInteface { get; }

        ICompanyInterface CompanyInterface { get; }
        Task<bool> SaveAscy();
    }
}
