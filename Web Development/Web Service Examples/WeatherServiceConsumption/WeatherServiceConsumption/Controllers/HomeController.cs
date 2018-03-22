using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherServiceConsumption.Models;

namespace WeatherServiceConsumption.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("http://api.openweathermap.org/data/2.5/");
            RestRequest req = new RestRequest("weather?q=Aalborg,dk&appid=YOUR_SECRET_API_KEY&units=metric");
            IRestResponse<WeatherInfo> response = client.Get<WeatherInfo>(req);
            WeatherInfo info = response.Data;
            if(info!=null)
                return View(info);
            ViewBag.Message = "An error has occured";
            return View();
        }
    }
}