using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;

            this.Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio
        {
            get { return portfolio; }
            set { portfolio = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        public decimal MoneyToInvest
        {
            get { return moneyToInvest; }
            set { moneyToInvest = value; }
        }
        public string BrokerName
        {
            get { return brokerName; }
            set { brokerName = value; }
        }
        public int Count => this.Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000m && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.Portfolio.Any(s => s.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }

            Stock stockToRemove = this.Portfolio.First(s => s.CompanyName == companyName);
            if (sellPrice < stockToRemove.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            this.Portfolio.Remove(stockToRemove);
            this.MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            if (this.Portfolio.Any(s => s.CompanyName == companyName))
            {
                return this.Portfolio.FirstOrDefault(s => s.CompanyName == companyName);
            }

            return null;
        }

        public Stock FindBiggestCompany()
        {
            if (this.Portfolio.Count == 0)
            {
                return null;
            }

            return this.Portfolio.OrderByDescending(s => s.MarketCapitalization).First();
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var stock in this.Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
