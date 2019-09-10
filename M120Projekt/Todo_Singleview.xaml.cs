using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class Todo_Singleview : Window
    {
        private enum modes { Create, Read, Update };
        private modes mode = modes.Create;

        public Todo_Singleview()
        {
            InitializeComponent();
            /* Aufruf diverse APIDemo Methoden
            APIDemo.TodoCreate();
            APIDemo.TodoCreateShort();
            APIDemo.TodoRead();
            APIDemo.TodoUpdate();
            APIDemo.TodoRead();
            // APIDemo.TodoDelete();
            */
            changeMode(modes.Create);
        }

        private void changeMode(modes mode)
        {
            switch (mode)
            {
                case modes.Create:
                    buttonSave.Visibility = Visibility.Visible;
                    buttonDelete.Visibility = Visibility.Collapsed;
                    buttonEdit.Visibility = Visibility.Collapsed;
                    description.IsEnabled = true;
                    deadline.IsEnabled = true;
                    priority.IsEnabled = true;
                    radioRed.IsEnabled = true;
                    radioGreen.IsEnabled = true;
                    radioBlue.IsEnabled = true;
                    done.IsEnabled = true;
                    labelTitle.Content = "Todo Erstellen";
                    priorityPlaceholder.Content = "Priorität auswählen";
                    break;
                case modes.Read:
                    buttonDelete.Visibility = Visibility.Visible;
                    buttonEdit.Visibility = Visibility.Visible;
                    buttonSave.Visibility = Visibility.Collapsed;
                    description.IsEnabled = false;
                    deadline.IsEnabled = false;
                    priority.IsEnabled = false;
                    radioRed.IsEnabled = false;
                    radioGreen.IsEnabled = false;
                    radioBlue.IsEnabled = false;
                    done.IsEnabled = false;
                    labelTitle.Content = "Todo";
                    alertLabel.Content = "";
                    priorityPlaceholder.Content = "";
                    description.BorderBrush = System.Windows.Media.Brushes.Black;
                    break;
                case modes.Update:
                    buttonSave.Visibility = Visibility.Visible;
                    buttonDelete.Visibility = Visibility.Collapsed;
                    buttonEdit.Visibility = Visibility.Collapsed;
                    description.IsEnabled = true;
                    deadline.IsEnabled = true;
                    priority.IsEnabled = true;
                    radioRed.IsEnabled = true;
                    radioGreen.IsEnabled = true;
                    radioBlue.IsEnabled = true;
                    done.IsEnabled = true;
                    labelTitle.Content = "Todo Berarbeiten";
                    priorityPlaceholder.Content = "Priorität auswählen";
                    break;
            }
            this.mode = mode;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (description.Text == "")
            {
                alertLabel.Content = "Beschreibung darf nicht leer sein!";
                description.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                changeMode(modes.Read);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            changeMode(modes.Update);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            const string message = "Sind sie sicher das sie dieses Todo löschen wollen?";
            const string caption = "Löschen Bestätigen";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {

            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (mode != modes.Read)
            {
                const string message = "Sie haben ungespeicherte Änderungen sind sie sicher das sie Zurück wollen?";
                const string caption = "Nicht gespeicherte Änderungen";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (mode == modes.Update)
                    {
                        changeMode(modes.Read);
                    }
                }
            }
        }
    }
}
