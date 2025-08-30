using Noita.SaveToolMancer.Controllers;
using System.Collections.Generic;
using System.Windows;

namespace Noita.SaveToolMancer.Views
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_saveGame_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<bool, string> result = SaveController.BackupSaveGame();
            PresentOpResult(result);
        }

        private void btn_restoreSave_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<bool, string> result = SaveController.RestoreSaveGame();
            PresentOpResult(result);
        }

        private void btn_openGameFolder_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<bool, string> result = SaveController.OpenGameFolder();

            if (!result.Key)
            {
                PresentOpResult(result);
            }
        }

        private void PresentOpResult(KeyValuePair<bool, string> opResult)
        {
            if (opResult.Key) // success
            {
                MessageBox.Show(
                    opResult.Value,                 // message text
                    "Success",                      // caption
                    MessageBoxButton.OK,           // buttons
                    MessageBoxImage.Information      // icon
                );
            }
            else // failure
            {
                MessageBox.Show(
                    opResult.Value,                 
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}
