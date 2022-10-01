using Lagersoftware.View;
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

namespace Lagersoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainMenu MainMenu { get; set; }
        public NewArtikel NewArtikel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainMenu = new MainMenu();
            MainMenu.OnNewArtikel += MainMenu_OnNewArtikel;
            PageFrame.Navigate(MainMenu);
            

        }

        private void MainMenu_OnNewArtikel(object? sender, EventArgs e)
        {
            NewArtikel = new NewArtikel();
            PageFrame.Navigate(NewArtikel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(MainMenu);
        }
    }
}
