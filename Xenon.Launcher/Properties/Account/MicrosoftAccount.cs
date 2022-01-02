using System;

namespace Xenon.Launcher.Properties.Account
{
	public class MicrosoftAccount : IAccount
	{
		private String username;
		private String accessToken;
		private String refreshToken;
		private Guid uuid;
		public Int32 uses;
		public DateTime lastUse;

		public MicrosoftAccount(String name, String token, String refresh, Guid uuid)
		{
			this.username = name;
			this.accessToken = token;
			this.refreshToken = refresh;
			this.uuid = uuid;
		}

		public String Alias() => username;

		public void Login()
		{
			throw new NotImplementedException();
		}

		public void SyncRefresh()
		{
			throw new NotImplementedException();
		}

		public Int32 Uses() => uses;

		public DateTime LastUse() => lastUse;

		public void Use()
		{
			uses++;
			lastUse = DateTime.Now;
		}

		public Guid Uuid() => uuid;
	}
}
