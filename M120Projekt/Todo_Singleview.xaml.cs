using System.Windows;
using System.Windows.Controls;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class Todo_Singleview : Window
    {
        public Todo_Singleview()
        {
            InitializeComponent();
            // Aufruf diverse APIDemo Methoden
            APIDemo.TodoCreate();
            APIDemo.TodoCreateShort();
            APIDemo.TodoRead();
            APIDemo.TodoUpdate();
            APIDemo.TodoRead();
            // APIDemo.TodoDelete();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            alertLabel.Content = $"Es wurde eingegeben: {description.Text}, {deadline.Text}, {priority.SelectedValue}, {done.IsChecked}";
        }
    }
}
