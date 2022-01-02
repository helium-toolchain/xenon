using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.Launcher.Properties.Account
{
	public interface IAccount
	{
		public String Alias();
		public void Login();
		public void Use();
		public Int32 Uses();
		public DateTime LastUse();
		public Guid Uuid();
	}
}
