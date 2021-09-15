using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xenon.Launcher.Properties
{
	internal class Login : INotifyPropertyChanged
	{
		private String _username;
		private String _password;

		public String Username
		{
			get => this._username;
			set
			{
				if(value != this._username)
				{
					this._username = value;
					this.OnPropertyChanged();
				}
			}
		}
		public String Password
		{
			get => this._password;
			set
			{
				if(value != this._password)
				{
					this._password = value;
					this.OnPropertyChanged();
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(
			[CallerMemberName]
			String propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
