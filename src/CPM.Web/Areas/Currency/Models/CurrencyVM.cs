using System;
using System.Collections.Generic;

namespace CPM.Web.Areas.Currency.Models
{
    public class CurrencyVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? MarketCap { get; set; }
        public string Description { get; set; }
        public List<PriceTickerVM> Prices { get; set; } = new List<PriceTickerVM>();
        public bool IsNew { get; set; }

        public List<FiatVM> FiatList { get; set; }
        public string DefaultFiatCurrency { get; set; }
    }

    public class PriceTickerVM
    {
        public string CryptoCode { get; set; }
        public string FiatCode { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal Change { get; set; }       
        public DateTime DateTime { get; set; }
        public List<PriceMarketVM> Markets { get; set; } = new List<PriceMarketVM>();
        public bool Success { get; set; }
        public string Error { get; set; }
    }

    public class PriceMarketVM
    {
        public string Market { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
    }

    public class FiatVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public int ImageId { get; set; }
        public int FlagId { get; set; }
    }

}
