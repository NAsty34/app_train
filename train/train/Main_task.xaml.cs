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

namespace train
{
    /// <summary>
    /// Логика взаимодействия для Main_task.xaml
    /// </summary>
    public partial class Main_task : Window
    {
        public Main_task()
        {
            InitializeComponent();

            var m = Main.user.Manager;
            if (m == null)
            {
                til.Text = "Задачи для исполнителя";
                show_task.ItemsSource = z4_train_MihailovaEntities.getContext().Task.Where(a => a.ExecutorID == Main.user.ID).ToList();
            }
            else
            {
                til.Text = "Задачи для менеджера";
                show_task.ItemsSource = z4_train_MihailovaEntities.getContext().Task.Where(a => a.Executor.ManagerID == Main.user.ID).ToList();
                Pol.Visibility = Visibility.Visible;
                add_z.Visibility = Visibility.Visible;
                
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Main().Show();
            Close();
        }


        private void show_task_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e == null) return;
            var a = ((FrameworkElement)e.OriginalSource).DataContext as Task;
            var w = new Edit();
            w.Init(a);
            w.ShowDialog();
            show_task.Items.Refresh();
            
        }

        private void add_z_Click(object sender, RoutedEventArgs e)
        {

            var w = new Edit();
            w.ShowDialog();
            show_task.ItemsSource = z4_train_MihailovaEntities.getContext().Task.Where(a => a.Executor.ManagerID == Main.user.ID).ToList(); 
        }

       

        private void rem_Click(object sender, RoutedEventArgs e)
        {
            var a = ((Button)sender).DataContext as Task;
            z4_train_MihailovaEntities.getContext().Task.Remove(a);
            z4_train_MihailovaEntities.getContext().SaveChanges();
            (show_task.ItemsSource as ICollection<Task>).Remove(a);
            show_task.Items.Refresh();
        }

        private void Pol_Click(object sender, RoutedEventArgs e)
        {
            new Users().Show();
        }
    }
}
