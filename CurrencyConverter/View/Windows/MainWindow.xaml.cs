using CurrencyConverter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrencyService _currencyService;
        public MainWindow()
        {
            InitializeComponent();
            _currencyService = new CurrencyService();
        }

        private void SellCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PurchaseCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void UpdateCourseBtn_Click(object sender, RoutedEventArgs e)
        {
           await _currencyService.LoadCurrencyAsync(CurrencyLv);
            _currencyService.LoadValutes(SellCmb);
            _currencyService.LoadValutes(PurchaseCmb);
        }

        private void ConvertBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
