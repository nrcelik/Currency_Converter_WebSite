using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Globalization;
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

        public IActionResult Index(string message = "", string targetCurrency = "")
        {
            var result = _converterService.GetCurrencies();
            List<string> items = result.Select(i => i.CurrencyType).ToList();

            ViewBag.CurrencyList = new SelectList(items, "CurrencyType");
            ViewBag.Message = message;
            ViewBag.TargetCurrency = targetCurrency;

            return View();
        }

        [HttpPost]
        public IActionResult Convert(string currentCurrency, string targetCurrency, double amount)
        {
            var result = _converterService.ConvertCurrencies(currentCurrency, targetCurrency, amount);

            string message = result.ToString("0.00", CultureInfo.InvariantCulture);

            return RedirectToAction("Index", new { message = message, targetCurrency = targetCurrency });
        }
    }
}