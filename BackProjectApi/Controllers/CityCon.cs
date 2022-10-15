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
    public class CityCon : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CityCon(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            var Data= await unitOfWork.cityInteface.GetCities();
            return Ok(Data);
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity(City city)
        {
            unitOfWork.cityInteface.addCity(city);
            await unitOfWork.SaveAscy();
            return Ok(city);
        }

        [HttpDelete("DeleteCity/{id}")]
        public async Task<IActionResult> DeleteCity(string id)
        {
            int i = Convert.ToInt32(id);
            unitOfWork.cityInteface.DeletCity(i);
            await unitOfWork.SaveAscy();
            return Ok(id);
        }
    }
}
