using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using System;
using System.IO;

using Xenon.Launcher.Properties;

namespace Xenon.Launcher
{
	public class Xenon : Window
	{
		public Xenon()
		{
			this.InitializeComponent();
			DataContext = new Login();
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
		public void Login_OnClick(Object sender, RoutedEventArgs args)

		{
			Login Login = DataContext as Login;
			Authenticate Account = new Authenticate();

			Account.ObtainAccessToken(Login.Username, Login.Password);

			String Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			String OxygenPath = Path + ".\\.oxygen";

			Directory.CreateDirectory(OxygenPath);
			File.WriteAllText(OxygenPath + ".\\launcher_accounts.json", Account.AccessToken);
		}
		public void Play_OnClick(Object sender, RoutedEventArgs args)

		{
			//Process.Start();
		}
	}
}
