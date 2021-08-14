using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverterUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConverterService _converterService;
        public HomeController(IConverterService converterService)
        {
           _converterService = converterService;
        }

        public IActionResult Index()
        {
            var result = _converterService.GetCurrencies();

            List<string> items = result.Select(i => i.CurrencyType).ToList();
            ViewBag.CurrencyList = new SelectList(items, "CurrencyType");

            return View();
        }

        [HttpPost]
        public IActionResult Convert(string currentCurrency, string targetCurrency, double amount)
        {
            var result = _converterService.ConvertCurrencies(currentCurrency, targetCurrency, amount);
            return View();
        }

    }
}



