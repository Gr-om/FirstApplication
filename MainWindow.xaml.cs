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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Users
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_button_click(object sender, RoutedEventArgs e)
        {
            TextBox input = input_user;
            if (input.Text.Length == 0)
            {
                MessageBox.Show("Поле не может быть пустым", "Ошибка");
                return;
            }
            Regex re = new Regex(@"\d");
            MatchCollection matches = re.Matches(input.Text);
            if (matches.Count > 0)
            {
                MessageBox.Show("Поле не может содержать цифры", "Ошибка");
                input.Text = "";
                return;
            }
            Random random = new Random();
            int id = random.Next(100, 1000000);
            string text = input.Text + ", id: " + id;
            list_users.Items.Add(text);
            input.Text = "";
        }
        private void Clear_button_click(object sender, RoutedEventArgs e)
        {
            list_users.Items.Clear();
        }
        private void Add_button_Key(object sender, KeyEventArgs e) 
        {
            if (e.Key == Key.Enter)
            {
                Add_button_click(sender, (RoutedEventArgs) e);
            }
        }
        private void Delete_user_list_box_key(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (list_users.SelectedItem == null)
                {
                    return;
                } 
                else
                {
                    string? value = list_users.SelectedItem.ToString();
                    list_users.Items.Remove(value);
                }
            }
        }
    }
}
