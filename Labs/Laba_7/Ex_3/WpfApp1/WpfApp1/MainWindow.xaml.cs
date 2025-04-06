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

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
    {
        private UrbanConstruction urbanConstruction;

        public MainWindow()
        {
            InitializeComponent();
            urbanConstruction = new UrbanConstruction();
        }

        // Обробники подій для підказок
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Tag != null && textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }

        // Додавання нового об'єкта будівництва
        private void AddConstruction(object sender, RoutedEventArgs e)
        {
            try
            {
                Construction newConstruction = new Construction
                {
                    NameConstructionCompany = NameConstructionCompanyTextBox.Text,
                    ConstructionName = ConstructionNameTextBox.Text,
                    Area = int.Parse(AreaTextBox.Text),
                    DateConstructionStart = new Date(),
                    DateConstructionEnd = new Date()
                };

                // Преобразуємо дати
                newConstruction.DateConstructionStart.ConvertToDate(StartDateTextBox.Text);
                newConstruction.DateConstructionEnd.ConvertToDate(EndDateTextBox.Text);
                
                // Встановлюємо стан
                if (StateComboBox.SelectedItem != null)
                {
                    var selectedItem = (ComboBoxItem)StateComboBox.SelectedItem;
                    string state = selectedItem.Tag.ToString();

                    newConstruction.State = state switch
                    {
                        "InProgress" => ConstructioState.InProgress,
                        "Done" => ConstructioState.Done,
                        "Freezed" => ConstructioState.Freezed,
                        _ => ConstructioState.InProgress,
                    };
                }

                // Додаємо об'єкт до списку
                urbanConstruction.Constructions.Add(newConstruction);
                ResultTextBox.AppendText("Об'єкт додано успішно!\n");
            }
            catch (Exception ex)
            {
                ResultTextBox.AppendText($"Помилка: {ex.Message}\n");
            }
        }

        // Вивести всі об'єкти будівництва
        private void ShowAllConstructions(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Clear();
            foreach (var construction in urbanConstruction.Constructions)
            {
                ResultTextBox.AppendText(construction.ShowInfo() + "\n\n");
            }
        }

        // Вивести об'єкти, терміни яких закінчуються цього року
        private void ShowConstructionsThisYear(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Clear();
            Date currentDate = new Date();
            currentDate.Year = DateTime.Now.Year;

            string result = urbanConstruction.GetDoneThisYear(currentDate);
            ResultTextBox.AppendText(result);
        }

        // Вивести об'єкти, терміни яких закінчуються в 4-му кварталі
        private void ShowConstructions4thQuarter(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Clear();
            Date currentDate = new Date();
            currentDate.Year = DateTime.Now.Year;

            string result = urbanConstruction.GetInfoFor4thquarter(currentDate);
            ResultTextBox.AppendText(result);
        }

        // Вивести об'єкт з мінімальним терміном виконання
        private void ShowMinTermConstruction(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Clear();
            string result = urbanConstruction.GetWithMinTerm();
            ResultTextBox.AppendText(result);
        }

        // Вивести прострочені об'єкти
        private void ShowOverdueConstructions(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Clear();
            Date currentDate = new Date();
            currentDate.Year = DateTime.Now.Year;

            string result = urbanConstruction.GetOverdueDeadLine(currentDate);
            ResultTextBox.AppendText(result);
        }
    }