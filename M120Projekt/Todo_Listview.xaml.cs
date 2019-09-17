using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Todo_Listview.xaml
    /// </summary>
    public partial class Todo_Listview : Window
    {
        public Todo_Listview()
        {
            InitializeComponent();

            todoList.ItemsSource = Data.Todos.ReadAll();
        }

        private void TodoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (todoList.SelectedItem != null) 
            {
                new Todo_Singleview(Todo_Singleview.Modes.Update, (Data.Todos)todoList.SelectedItem).Show();
            }
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            new Todo_Singleview(Todo_Singleview.Modes.Create, new Data.Todos()).Show();
        }
    }
}
