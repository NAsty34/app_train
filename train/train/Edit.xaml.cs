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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Task task;
        public Edit()
        {
            InitializeComponent();
            var a = z4_train_MihailovaEntities.getContext().Task;
            FIO_Is.ItemsSource = z4_train_MihailovaEntities.getContext().Executor.Where(e => e.ManagerID == Main.user.ID).Select(e => e.User).ToList();
            statys.Items.Add("запланирована");
            statys.Items.Add("исполняется");
            statys.Items.Add("выполнена");
            statys.Items.Add("отменена");
            xar.Items.Add("анализ и проектирование");
            xar.Items.Add("установка оборудования");
            xar.Items.Add("техническое обслуживание и сопровождение");
            til.Text = "Добавление задачи";
        }

        public void Init(Task task)
        {
            til.Text = "Редактирование задачи";
            this.task = task;
            naz.Text = task.Title;
            dir.Text = task.Description;
            srok_is.Text = task.CreateDateTime.ToString();
            dat_vip.Text = task.Deadline.ToString();
            slog.Text = task.Difficulty.ToString();
            vremy.Text = task.Time.ToString();
            FIO_Is.SelectedItem = task.Executor.User;
            statys.SelectedItem = task.Status;
            xar.SelectedItem = task.WorkType;
        }



        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (task == null)
            {
                task = new Task();
            }

            task.Title = naz.Text;
            task.Description = dir.Text;
            try
            {
                DateTime.Parse(srok_is.Text);
            }
            catch
            {
                MessageBox.Show("Поле срок исполнения должно быть датой");
                return;
            }
            task.CreateDateTime = DateTime.Parse(srok_is.Text);
           
            try
            {
                DateTime.Parse(dat_vip.Text);
            }
            catch
            {
                MessageBox.Show("Поле время выполнения задачи должно быть датой");
                return;
            }
            task.Deadline = DateTime.Parse(dat_vip.Text);
            
            task.Difficulty = double.Parse(slog.Text);
            task.Time = int.Parse(vremy.Text);
            task.Executor = ((User)FIO_Is.SelectedItem).Executor;

            task.Status = statys.Text;
            task.WorkType = xar.Text;

            if (task.ID < 1)
            {
                z4_train_MihailovaEntities.getContext().Task.Add(task);
            }
            z4_train_MihailovaEntities.getContext().SaveChanges();
            MessageBox.Show("Изменения сохранены");

            Close();
           
        }
    }
}
