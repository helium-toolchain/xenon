using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Xenon.Launcher.Properties;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Diagnostics;

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
            this.FindControl<Button>("Play");
        }
        public void Login_OnClick(object sender, RoutedEventArgs args)

        {
            var Login = this.DataContext as Login;
            var Account = new Authenticate();

            Account.ObtainAccessToken(Login.Username, Login.Password);

            String Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String OxygenPath = Path + ".\\.oxygen";

            Directory.CreateDirectory(OxygenPath);
            File.WriteAllText(OxygenPath + ".\\launcher_accounts.json", Account.AccessToken);
        }
        public void Play_OnClick(object sender, RoutedEventArgs args)

        {
            //Process.Start();
        }
    }
}
