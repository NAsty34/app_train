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
    /// Логика взаимодействия для Edit_pol.xaml
    /// </summary>
    public partial class Edit_pol : Window
    {
        public User user;
        public Edit_pol()
        {
            InitializeComponent();
            greyd.ItemsSource = z4_train_MihailovaEntities.getContext().Executor.Select(e => e.Grade).ToList();
            men.ItemsSource = z4_train_MihailovaEntities.getContext().Manager.Select(e => e.User).ToList();
            til.Text = "Добавление пользователя";
        }

        public void Init(User user)
        {
            til.Text = "Редактирование пользователя";
            this.user = user;
           
            sec_name.Text = user.FirstName;
            fir_name.Text = user.MiddleName.ToString();
            patr.Text = user.LastName.ToString();
            greyd.SelectedItem = user.Executor.Grade.ToString();
            men.SelectedItem = user.Manager.User.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //user.FirstName = sec_name.Text;
            //user.MiddleName = fir_name.Text;
            //user.LastName = patr.Text;
            MessageBox.Show("Изменения сохранены");
        }
    }
}
