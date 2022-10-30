using CryptoInterface;
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
using CryptoInformation.Views;

namespace CryptoInformation
{
    public partial class MainWindow : Window
    {
        private ICryptoServices ?_cryptoServices;
        public MainWindow(ICryptoServices cryptoServices)
        {
            _cryptoServices = cryptoServices;
            InitializeComponent();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Content = new Search();
        }
    }
}
