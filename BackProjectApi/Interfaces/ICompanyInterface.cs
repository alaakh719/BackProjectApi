using BackProjectApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Interfaces
{
   public interface ICompanyInterface
    {
        Task<IEnumerable<Company>> GetCompanies();
      
        void AddCompany(Company company);
    }
}
