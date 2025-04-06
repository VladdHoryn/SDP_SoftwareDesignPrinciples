using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowText(object sender, RoutedEventArgs e)
    {
        City city1 = new City("Kyiv", 839.0, 2804000);
        City city2 = new City("Lviv", 182.0, 720000);
        City city3 = new City("Odesa", 236.0, 1000000);
        
        city1.AddCity(city1);
        city1.AddCity(city2);
        city1.AddCity(city3);
        string line = "";
        foreach (var city in city1)
        {
           line += $"City: {((City)city1).Name}, Population: {((City)city).Population}\n";
        }
        TextBox.Text = city1.GetCities();
    }
}