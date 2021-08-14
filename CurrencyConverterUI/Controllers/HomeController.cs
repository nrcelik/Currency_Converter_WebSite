using CurrencyConverterUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace CurrencyConverterUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44376");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/converter/getcurrencytypes").Result;

                List<Currency> currencies = new List<Currency>();

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    currencies = JsonConvert.DeserializeObject<List<Currency>>(content);
                }

                    List<string> items = currencies.Select(i => i.CurrencyType).ToList();
                    ViewBag.CurrencyList = new SelectList(items, "CurrencyType");
                    
                return View();
            }
        }

        [HttpPost]
        public IActionResult Convert(string currentCurrency, string targetCurrency, double amount)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44376");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/converter/convertcurrencies?currentCurrency=" + currentCurrency + "&targetCurrency=" + targetCurrency + "&amount=" + amount + "").Result;

                List<Currency> currencies = new List<Currency>();

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                }
            }

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
