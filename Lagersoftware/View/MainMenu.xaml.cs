
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

namespace Lagersoftware.View
{
    /// <summary>
    /// Interaktionslogik für MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {

        public event EventHandler? OnNewArtikel;
        public event EventHandler? OnDeleteArtikel;
        public event EventHandler? OnBookArtikel;
        public event EventHandler? OnUnbookArtikel;
        public event EventHandler? OnAllArtikel;
        public event EventHandler? OnSearchArtikel;



        protected virtual void RaiseOnNewArtikel ()
        {
            OnNewArtikel?.Invoke (this, EventArgs.Empty);
        }

        protected virtual void RaiseOnDeleteArtikel()
        {
            OnDeleteArtikel?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void RaiseOnBookArtikel()
        {
            OnBookArtikel?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void RaiseOnUnbookArtikel()
        {
            OnUnbookArtikel?.Invoke(this, EventArgs.Empty);

        }
        protected virtual void RaiseOnAllArtikel()
        {
            OnAllArtikel?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void RaiseOnSearchArtikel()
        {
            OnSearchArtikel?.Invoke(this, EventArgs.Empty);
        }
        public MainMenu()
        {
            InitializeComponent();
       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseOnNewArtikel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RaiseOnDeleteArtikel();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RaiseOnBookArtikel();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RaiseOnUnbookArtikel();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RaiseOnAllArtikel();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            RaiseOnSearchArtikel();
        }
    }
}
