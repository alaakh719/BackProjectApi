using BackProjectApi.Interfaces;
using BackProjectApi.Model;
using BackProjectApi.Model.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BackProjectApi.Controllers
{
    public class Home : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment hosting;
        public Home(IUnitOfWork unitOfWork,IHostingEnvironment hosting)
        {
            this.unitOfWork = unitOfWork;
            this.hosting = hosting;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //string Baseurl = " https://localhost:44366/";
            //var model = new List<Company>();
            //var Client = new HttpClient();
            //Client.BaseAddress = new Uri(Baseurl);
            //Client.DefaultRequestHeaders.Accept.Clear();
            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage Res = await Client.GetAsync("CompnayCon/GetCompany").ConfigureAwait(true);

            //if (Res.IsSuccessStatusCode)
            //{
            //    //Storing the response details recieved from web api
            //    var EmpResponse = Res.Content.ReadAsStringAsync().Result.ToString();
            //    var ResultVALUES = JToken.Parse(EmpResponse);

            //    foreach (var itme in ResultVALUES.SelectTokens("[*]"))
            //    {
            //        var Ido = (int)itme.SelectToken("id");
            //        var Nameo = (string)itme.SelectToken("nameAr");

            //        var logoo = (string)itme.SelectToken("logo");
            //        var Cityid = (int)itme.SelectToken("city.id");
            //        var CityName = (string)itme.SelectToken("city.name");
            //        var Cityobj = new City()
            //        {
            //            Id = Cityid,
            //            Name = CityName
            //        };
            //        var CompanyOb = new Company()
            //        {
            //          id= Ido,
            //          NameAr= Nameo,
            //          logo=logoo ,
            //          city= Cityobj, 
            //          Cityid= Cityid

            //        };
            //        model.Add(CompanyOb);
            //    }

            //    return View(model);
            //}

            var DATA = await unitOfWork.CompanyInterface.GetCompanies();
            return View(DATA);
        }

        [HttpGet]

        public async Task<IActionResult> addComapny()
        {
           
            //you can aslo use call API to bring it from view using new method to get city Name 
            ViewData["Cityid"] = new SelectList(await unitOfWork.cityInteface.GetCities(), "Id", "Name");

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> addComapny(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                string fullpath = string.Empty;
                if (model.file != null)
                {
                    string serverpath = Path.Combine(hosting.WebRootPath, "uploads");
                    path = model.file.FileName;
                    fullpath = Path.Combine(serverpath, path);
                    model.file.CopyTo(new FileStream(fullpath, FileMode.Create));
                }

                var company = new Company()
                {
                    NameAr = model.NameAr,
                    Cityid = model.Country,
                    logo = path
                };

                //Normal way Using unitOfWork
                //unitOfWork.CompanyInterface.AddCompany(company);
                //await unitOfWork.SaveAscy();
                //  return RedirectToAction(nameof(Index));


                //way Using API Calling
                string Baseurl = "https://localhost:44366/";
                var client = new HttpClient();
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(company),Encoding.UTF8, "application/json");
                HttpResponseMessage Response = await client.PostAsync("CompnayCon/AddCompany", content).ConfigureAwait(false);
                Response.EnsureSuccessStatusCode();

                if(Response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View();
           
        }
    }
}
