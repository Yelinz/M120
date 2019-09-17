using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Todo_Singleview.xaml
    /// </summary>
    public partial class Todo_Singleview : Window
    {
        public enum Modes { Create, Read, Update };
        private Modes mode = Modes.Create;
        private Data.Todos todo;

        public Todo_Singleview(Modes mode, Data.Todos todo)
        {
            InitializeComponent();
            this.todo = todo;
            ChangeMode(mode);
            FillFields(todo);
        }

        private void ChangeMode(Modes mode)
        {
            if (mode == Modes.Read) 
            {
                buttonSave.Visibility = Visibility.Collapsed;
                buttonEdit.Visibility = Visibility.Visible;
                buttonDelete.Visibility = Visibility.Visible;
                description.IsEnabled = false;
                deadline.IsEnabled = false;
                priority.IsEnabled = false;
                radioRed.IsEnabled = false;
                radioGreen.IsEnabled = false;
                radioBlue.IsEnabled = false;
                done.IsEnabled = false;
                labelTitle.Content = "Todo";
                priorityPlaceholder.Content = "";
                description.BorderBrush = System.Windows.Media.Brushes.Black;
            } else
            {
                buttonSave.Visibility = Visibility.Visible;
                buttonEdit.Visibility = Visibility.Collapsed;
                buttonDelete.Visibility = Visibility.Collapsed;
                description.IsEnabled = true;
                deadline.IsEnabled = true;
                priority.IsEnabled = true;
                radioRed.IsEnabled = true;
                radioGreen.IsEnabled = true;
                radioBlue.IsEnabled = true;
                done.IsEnabled = true;
                priorityPlaceholder.Content = "Priorität auswählen";

                if (mode == Modes.Create)
                {
                    labelTitle.Content = "Todo Erstellen";
                } else if (mode == Modes.Update)
                {
                    labelTitle.Content = "Todo Berarbeiten";
                }
            }

            messageLabel.Content = "";
            this.mode = mode;
        }

        private void FillFields(Data.Todos todo)
        {
            description.Text = todo.Description;
            deadline.Text = todo.ExpiryDate.ToString();
            priority.SelectedIndex = todo.Priority;
            done.IsChecked = todo.Done;
            switch (todo.Colour)
            {
                case "Red":
                    radioRed.IsChecked = true;
                    break;
                case "Green":
                    radioGreen.IsChecked = true;
                    break;
                case "Blue":
                    radioBlue.IsChecked = true;
                    break;
            }
        }

        private void SetAlertMessage(string message)
        {
            messageLabel.Content = message;
            messageLabel.Foreground = System.Windows.Media.Brushes.Red;
        }

        private void SetSuccessMessage(string message)
        {
            messageLabel.Content = message;
            messageLabel.Foreground = System.Windows.Media.Brushes.Green;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (description.Text == "")
            {
                SetAlertMessage("Beschreibung darf nicht leer sein!");
                description.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                todo.Description = description.Text;
                todo.Priority = priority.SelectedIndex;
                todo.Done = done.IsChecked ?? false;
                if (deadline.Text != "")
                {
                    todo.ExpiryDate = DateTime.Parse(deadline.Text);
                }
                else
                {
                    todo.ExpiryDate = null;
                }
                if (radioRed.IsChecked == true)
                {
                    todo.Colour = "Red";
                }
                else if (radioGreen.IsChecked == true)
                {
                    todo.Colour = "Green";
                }
                else if (radioBlue.IsChecked == true)
                {
                    todo.Colour = "Blue";
                }

                if (mode == Modes.Create)
                {
                    todo.Create();
                } else if (mode == Modes.Update)
                {
                    todo.Update();
                }

                ChangeMode(Modes.Read);
                SetSuccessMessage("Todo wurde erfolgreich gespeichert");
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            ChangeMode(Modes.Update);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            const string message = "Sind sie sicher das sie dieses Todo löschen wollen?";
            const string caption = "Löschen Bestätigen";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                todo.Delete();
                SetSuccessMessage("Todo wurde erfolgreich gelöscht");
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (mode != Modes.Read)
            {
                const string message = "Sie haben ungespeicherte Änderungen sind sie sicher das sie Zurück wollen?";
                const string caption = "Nicht gespeicherte Änderungen";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (mode == Modes.Update)
                    {
                        ChangeMode(Modes.Read);
                    } else
                    {
                        this.Close();
                    }
                }
            } else
            {
                this.Close();
            }
        }
    }
}
