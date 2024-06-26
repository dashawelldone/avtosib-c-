using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Avtosib.Services;
// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Avtosib
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            var password = Password.Password;
            var frm = Window.Current.Content as Frame;

            if (string.IsNullOrEmpty(Number.Text))
            {
                Error.Text = "Введите номер телефона";
                return;
            }
            else if (string.IsNullOrEmpty(Password.Password))
            {
                Error.Text = "Введите пароль";
                return;
            }
            else
            {
                Error.Text = "";
            }

            try
            {
                var profileStatus = await Auth.SignIn(Number.Text, password);

                if (profileStatus)
                {
                    frm.Navigate(typeof(AdminPage));
                }
                else
                {
                    frm.Navigate(typeof(MainWindow));
                }
            }
            catch (Exception)
            {
                Error.Text = "";
            }

            
        }

        private void Button_Reg(object sender, RoutedEventArgs e)
        {

            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(RegistrationPage));
        }

    }
}


