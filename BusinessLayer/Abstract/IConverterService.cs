using CurrencyConverterUI.Entities;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IConverterService
    {
        Uri BasePath { get; set; }
        List<Currency> Currencies { get; set; }

        List<Currency> GetCurrencies();

        double ConvertCurrencies(string currentCurrency, string targetCurrency, double amount);
    }
}