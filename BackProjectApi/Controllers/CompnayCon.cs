using BackProjectApi.Interfaces;
using BackProjectApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompnayCon : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CompnayCon(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }


        [HttpGet("GetCompany")]
        public async Task<IActionResult> GetCompany()
        {
            var Data = await unitOfWork.CompanyInterface.GetCompanies();
            return Ok(Data);
        }

        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCompany(Company company)
        {
            unitOfWork.CompanyInterface.AddCompany(company);
            await unitOfWork.SaveAscy();
            return Ok(company);
        }
    }
}
