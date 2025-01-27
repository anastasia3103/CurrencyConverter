using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CurrencyConverter.Model
{
    public class CurrencyService
    {
        private const string JSON_PATH = "https://www.cbr-xml-daily.ru/daily_json.js";

        private double buyAmount;
        private double sellAmount;
        private Valute buyValute;
        private Valute sellValute;
        public Currency Currency { get; private set; }
        public List<Valute> Valutes { get; private set; }

        public async Task LoadCurrencyAsync(ListView listView)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(JSON_PATH);
                if (!string.IsNullOrEmpty(response))
                {
                    Currency = JsonConvert.DeserializeObject<Currency>(response);
                    Valutes = Currency.Valute.Values.ToList();

                    Valutes.Insert(0, new Valute()
                    {
                        ID = "R00001",
                        NumCode = "643",
                        CharCode = "RUB",
                        Nominal = 1,
                        Name = "Российский рубль",
                        Value = 1,
                        Previous = 1
                    });

                    listView.ItemsSource = Valutes;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void LoadValutes (ComboBox comboBox)
        {
            comboBox.ItemsSource = Valutes;
        }

        public string ConvertValute(double sellAmount, Valute sellValute, Valute buyValute)
        {
           this.sellAmount = sellAmount;
           this.sellValute = sellValute;
           this.buyValute = buyValute;


        }
    }
}
