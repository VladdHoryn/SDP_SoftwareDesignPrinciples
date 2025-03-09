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

namespace Ex_1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Button_click(object sender, RoutedEventArgs e)
    {
        char[] text = TextBox.Text.ToCharArray();
        for (int i = 0; i < text.Length; ++i)
        {
            char a = 'b';
            if (text[i] >= 'a' && text[i] <= 'z')
            {
                text[i] = (char)((int)text[i] - 32);
            }
            else
            if (text[i] >= 'A' && text[i] <= 'Z')
            {
                text[i] = (char)((int)text[i] + 32);
            }
        }

        string result = new string(text);
        Label.Content = result;
    }
}