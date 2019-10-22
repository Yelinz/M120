using M120Projekt.controls;
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
    public partial class Todo_Listview : UserControl
    {
        Main_Window Container;
        public Todo_Listview(Main_Window _Container)
        {
            InitializeComponent();
            Container = _Container;

            ReloadTodoList();
        }

        private void TodoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (todoList.SelectedItem != null) 
            {
                Container.View.Content = new UserControl1(UserControl1.Modes.Update, (Data.Todos)todoList.SelectedItem, this, Container);
            }
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Container.View.Content = new UserControl1(UserControl1.Modes.Create, new Data.Todos(), this, Container);
        }

        public void ReloadTodoList()
        {
            todoList.ItemsSource = Data.Todos.ReadAll();
        }
    }
}
