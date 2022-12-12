using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

namespace train
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
            show_user.ItemsSource = z4_train_MihailovaEntities.getContext().Executor.ToList();
            var g = z4_train_MihailovaEntities.getContext().Executor;

            foreach (var a in g)
            {

                a.Task.GroupBy(e => e.Status).Select(e => new { Name = e.Key, Count = e.Count() });
            }
            show_user.ItemsSource = g.ToList();
        }

        private void show_user_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e == null) return;
            var a = ((FrameworkElement)e.OriginalSource).DataContext as User;
            var m = new Edit_pol();
            m.Init(a);
            m.Show();
        }

       
    }
}
