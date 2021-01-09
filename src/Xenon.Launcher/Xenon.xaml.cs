using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Xenon.Launcher.Properties;
using Newtonsoft.Json;
using System.IO;
using System;

namespace Xenon.Launcher
{
    public class Xenon : Window
    {
        public Xenon()
        {
            InitializeComponent();
            this.DataContext = new Login();
#if DEBUG
            this.AttachDevTools();
#endif
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.FindControl<Button>("Login");
        }
        public void Login_OnClick(object sender, RoutedEventArgs args)

        {
            var Login = this.DataContext as Login;
            var Account = new Authenticate();

            Account.ObtainAccessToken(Login.Username, Login.Password);
            string AccessToken = Account.GetAccessToken();

            string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string OxygenPath = Path + "\\.oxygen";

            Directory.CreateDirectory(OxygenPath);
            File.WriteAllText(OxygenPath + "\\launcher_accounts.json", AccessToken);


        }
    }
}
