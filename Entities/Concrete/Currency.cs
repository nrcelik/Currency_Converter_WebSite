using Entities.Abstract;

namespace CurrencyConverterUI.Entities
{
    public class Currency : IEntity
    {
        public string CurrencyType { get; set; }
    }
}