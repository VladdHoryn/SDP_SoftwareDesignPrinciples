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
    private Factory factory;
    
    public MainWindow()
    {
        InitializeComponent();
        factory = new Factory();
    }
    
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        factory.Name = txtName.Text;
        factory.Location = txtLocation.Text;
        factory.Employees = int.TryParse(txtEmployees.Text, out int emp) ? emp : 10;
        factory.ProductionCapacity = int.TryParse(txtCapacity.Text, out int cap) ? cap : 1000;
        factory.Efficiency = 0.8;
        factory.IsOperational = true;
        factory.EstablishedYear = DateTime.Now.AddYears(-10);
        
        string filePath = "factory_data.txt";
        factory.SaveToFile(filePath);
        MessageBox.Show("Дані збережено у файл.");
    }

    private void Show_Click(object sender, RoutedEventArgs e)
    {
        txtOutput.Text = factory.GetFactoryInfo();
    }
}