using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        public string Director
        {
            get { return director; }
            set { director = value; }
        }
        public decimal PricePerShare
        {
            get { return pricePerShare; }
            set { pricePerShare = value; }
        }
        public int TotalNumberOfShares
        {
            get { return totalNumberOfShares; }
            set { totalNumberOfShares = value; }
        }
        public decimal MarketCapitalization => this.PricePerShare * this.TotalNumberOfShares;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Company: {this.CompanyName}");
            sb.AppendLine($"Director: {this.Director}");
            sb.AppendLine($"Price per share: ${this.PricePerShare}");
            sb.AppendLine($"Market capitalization: ${this.MarketCapitalization:f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
