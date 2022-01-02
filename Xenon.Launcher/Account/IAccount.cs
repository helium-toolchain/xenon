using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.Launcher.Properties.Account
{
	public interface IAccount
	{
		public String Alias { get; }
		public Int32 Uses { get; }
		public DateTime LastUse { get; }
		public Guid Uuid { get; }
		public void Login();
		public void Use();
	}
}
