using DataProvider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TeamScaleTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            RecordsModel recModel;
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54196/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/records?Id="+id);
                if (Res.IsSuccessStatusCode)
                {
                    var jsonRes = Res.Content.ReadAsStringAsync().Result;
                    recModel = JsonConvert.DeserializeObject<RecordsModel>(jsonRes);
                    return View(recModel);
                }

                return View();
            }
           
        }
    }
}
