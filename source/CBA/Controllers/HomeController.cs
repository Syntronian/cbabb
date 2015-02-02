using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CBA.Models.BuyBuddie;
using Newtonsoft.Json;

namespace CBA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string q)
        {
            if (string.IsNullOrEmpty(q))
                return View();

            ViewBag.Query = q;
            var model = new Search();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://buybuddie.com.au/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var task = client.GetAsync("api/v1/search?q=" + q).ContinueWith((taskwithresponse) =>
                    {
                        var response = taskwithresponse.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        model = JsonConvert.DeserializeObject<Search>(jsonString.Result);
                    });
                    task.Wait();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("Results", model);
        }
    }
}