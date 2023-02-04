using CableTV.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CableTV.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        Uri baseAdd = new Uri("http://localhost:44237/api");

        HttpClient client;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
            client = new HttpClient();
            client.BaseAddress = baseAdd;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<JsonResult> GetAllProvider()
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Provider/").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }

        public async Task<JsonResult> GetAllSubscription(int provider_id)
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Subscription/" + provider_id).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(CableEntity CE)
        {
            string[] files = CE.image_path.Split('\\');
            CE.image_path = "Photo/" + files[files.Length - 1];
            string data = JsonConvert.SerializeObject(CE);
            HttpResponseMessage response;
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            response = client.PutAsync(client.BaseAddress + "/Cable/" + CE.registration_id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile MyUploader)
        {
            if (MyUploader != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "File");
                string filePath = Path.Combine(uploadsFolder, MyUploader.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    MyUploader.CopyTo(fileStream);
                }
                return new ObjectResult(new { status = "success" });
            }
            return new ObjectResult(new { status = "fail" });

        }
        public async Task<JsonResult> Edit(int registration_id)
        {
            CableEntity schlst = new CableEntity();
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Cable/" + registration_id).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                //schlst = JsonConvert.DeserializeObject<CableEntity>(data);
            }
            //var jsonres = JsonConvert.SerializeObject(schlst);
            return Json(data);
        }

        public async Task<JsonResult> ViewAll()
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Cable/").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }

    }
}
