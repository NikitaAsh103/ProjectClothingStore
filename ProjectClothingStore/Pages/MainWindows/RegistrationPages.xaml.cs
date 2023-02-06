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
using ProjectClothingStore.ClassHelper;
using ProjectClothingStore.Windows;
using ProjectClothingStore.DB;

namespace ProjectClothingStore.Pages.MainWindows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPages.xaml
    /// </summary>
    public partial class RegistrationPages : Page
    {
        public RegistrationPages()
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EFclass.Contexts.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "GenderName";
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Поле Логин должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(TbEmail.Text))
            {
                MessageBox.Show("Поле Логин должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Поле Логин должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(TbFirsName.Text))
            {
                MessageBox.Show("Поле Логин должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(TbPatronymic.Text))
            {
                MessageBox.Show("Поле Логин должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(TbPhoneNumber.Text))
            {
                MessageBox.Show("Поле Логин должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(CmbGender.Text))
            {
                MessageBox.Show("Поле Пола должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(DPDateOfBirthday.Text))
            {
                MessageBox.Show("Поле Даты Рождения должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Поле Пароль должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            


            EFclass.Contexts.User.Add(new User()
            {
                Login = TbLogin.Text,
                Password = PbPassword.Password,
                LastName = TbLastName.Text, 
                FirstName = TbFirsName.Text,
                Patronymic= TbPatronymic.Text,  
                Email= TbEmail.Text,    
                PhoneNumber=TbPhoneNumber.Text, 
                Birthday = DPDateOfBirthday.SelectedDate.Value,
                IDGender = (CmbGender.SelectedItem as Gender).IDGender,
            });

            EFclass.Contexts.SaveChanges();
            MessageBox.Show("OK");

        }

        private void TbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text== "Введите Логин")
            {
                TbLogin.Text = "";
            }
        }

        private void TbLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text=="")
            {
                TbLogin.Text = "Введите Логин";
            }
        }
    }
}
