using BusinessLayer.Abstract;
using CurrencyConverterUI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BusinessLayer.Concrete
{
    public class ConverterManager : IConverterService
    {
        public Uri BasePath { get; set; } = new Uri("https://localhost:44376");
        public List<Currency> Currencies { get; set; }

        public double ConvertCurrencies(string currentCurrency, string targetCurrency, double amount)
        {
            string content = "";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BasePath;
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/converter/convertcurrencies?currentCurrency=" + currentCurrency + "&targetCurrency=" + targetCurrency + "&amount=" + amount + "").Result;

                List<Currency> currencies = new List<Currency>();

                if (response.IsSuccessStatusCode)
                {
                    content = response.Content.ReadAsStringAsync().Result;
                }
            }
            return Convert.ToDouble(content);
        }

        public List<Currency> GetCurrencies()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BasePath;
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/converter/getcurrencytypes").Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    Currencies = JsonConvert.DeserializeObject<List<Currency>>(content);
                }
            }

            return Currencies;
        }
    }
}