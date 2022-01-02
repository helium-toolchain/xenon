using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using System;


namespace Xenon.Launcher
{
	public partial class Xenon : Window
	{
		private Button MicrosoftBtn;
		private Button MojangBtn;
		private Button BackBtn;
		private Button LoginBtn;
		private TextBox UsernameBox;
		private TextBox PasswordBox;

		public Xenon()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
			MicrosoftBtn = this.FindControl<Button>("MicrosoftBtn");
			MojangBtn = this.FindControl<Button>("MojangBtn");
			BackBtn = this.FindControl<Button>("BackBtn");
			UsernameBox = this.FindControl<TextBox>("Username");
			PasswordBox = this.FindControl<TextBox>("Password");
			LoginBtn = this.FindControl<Button>("LoginBtn");
		}

		public void MojangButton(object sender, RoutedEventArgs args)
		{
			UsernameBox.IsVisible = true;
			PasswordBox.IsVisible = true;
			MicrosoftBtn.IsVisible = false;
			BackBtn.IsVisible = true;
			LoginBtn.IsVisible = true;
			MojangBtn.IsVisible = false;
		}

		public void MicrosoftButton(object sender, RoutedEventArgs args)
		{
			MojangBtn.IsVisible = false;
			BackBtn.IsVisible = true;
			LoginBtn.IsVisible = true;
			MicrosoftBtn.IsVisible = false;
		}

		public void BackButton(object sender, RoutedEventArgs args)
		{
			UsernameBox.IsVisible = false;
			PasswordBox.IsVisible = false;
			MojangBtn.IsVisible = true;
			MicrosoftBtn.IsVisible = true;
			BackBtn.IsVisible = false;
			LoginBtn.IsVisible = false;
		}

		public void LoginButton(object sender, RoutedEventArgs args)
		{
			LoginBtn.IsVisible = false;
		}
	}
}
