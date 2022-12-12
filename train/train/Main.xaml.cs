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

namespace train
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        public static User user;
        public Main()
        {
            InitializeComponent();
            log.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var l = z4_train_MihailovaEntities.getContext().User.Where(a => a.Login == log.Text);
            if (l.Count() < 1)
            {
                MessageBox.Show("Пользователь не существует");
                return;
            }
            var u = l.First();
            if (u.Password == pas.Password)
            {
                user = u;
                new Main_task().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пароль неправильный");
            }
            
           
        }

        private void pas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(null, null);

            }
        }
    }
}
