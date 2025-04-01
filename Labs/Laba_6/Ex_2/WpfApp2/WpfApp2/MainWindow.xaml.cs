using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MaterialType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (MaterialType.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Content.ToString() == "Конспект")
                {
                    // Показати RadioButton для завершеності
                    FinishedLabel.Visibility = Visibility.Visible;
                    FinishedRadioButton.Visibility = Visibility.Visible;
                }
                else
                {
                    // Приховати RadioButton для завершеності
                    FinishedLabel.Visibility = Visibility.Collapsed;
                    FinishedRadioButton.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ShowInfoButton_Click(object sender, RoutedEventArgs e)
        {
            string materialType = (MaterialType.SelectedItem as ComboBoxItem)?.Content.ToString();
            string subject = SubjectInput.Text;
            int pages = int.TryParse(PagesInput.Text, out int p) ? p : 0;
            List<string> topics = new List<string>(TopicsInput.Text.Split(','));

            EducationalMaterial material;

            if (materialType == "Книга")
            {
                material = new Book { Subject = subject, Pages = pages, Topics = topics };
            }
            else
            {
                // Додаємо логіку для Compendium, включаючи isFinished
                material = new Compendium
                {
                    Subject = subject,
                    Pages = pages,
                    Topics = topics,
                    IsFinished = FinishedRadioButton.IsChecked == true
                };
            }

            // Показати інформацію про матеріал
            ResultText.Text = (material as Test).ShowInfoAboutTest();
        }
    }
}
