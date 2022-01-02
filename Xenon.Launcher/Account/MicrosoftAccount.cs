using System;

namespace Xenon.Launcher.Properties.Account
{
	public class MicrosoftAccount : IAccount
	{
		private String username;
		private String accessToken;
		private String refreshToken;

		public Guid Uuid { get; private set; }
		public Int32 Uses { get; private set; }
		public DateTime LastUse { get; private set; }
		public String Alias 
		{ 
			get => this.username; 
			private set => this.username = value; 
		}

		public MicrosoftAccount(String name, String token, String refresh, Guid uuid)
		{
			this.username = name;
			this.accessToken = token;
			this.refreshToken = refresh;
			this.Uuid = uuid;
		}

		public void Login()
		{
			throw new NotImplementedException();
		}

		public void SyncRefresh()
		{
			throw new NotImplementedException();
		}

		public void Use()
		{
			Uses++;
			LastUse = DateTime.Now;
		}
	}
}
