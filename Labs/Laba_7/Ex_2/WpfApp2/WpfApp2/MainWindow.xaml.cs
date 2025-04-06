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


namespace WpfApp2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private SHOP shop = new SHOP();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddProduct_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var name = NameBox.Text;
            var type = TypeBox.Text;
            var quantity = int.Parse(QuantityBox.Text);
            var cost = int.Parse(CostBox.Text);

            var sklad = new SKLAD
            {
                Name = name,
                Type = type,
                Quantity = quantity,
                Cost = cost
            };

            shop.Add(sklad);
            OutputText.Text = "Product added successfully!";
        }
        catch
        {
            OutputText.Text = "Error: Please check your input.";
        }
    }

    private void ShowAll_Click(object sender, RoutedEventArgs e)
    {
        OutputText.Text = shop.GetInfo();
    }

    private void SearchProduct_Click(object sender, RoutedEventArgs e)
    {
        string name = SearchBox.Text;
        OutputText.Text = shop.GetByName(name);
    }
}