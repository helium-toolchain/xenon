using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xenon.Installers.Mojang.Commons.Launchermeta;

namespace Xenon.Installers.Mojang.Commons
{
	public static class MojangHelper
	{
		private static LauncherMain __launchermetaMain;

		public static LauncherMain LaunchermetaMain
		{
			get
			{
				if(__launchermetaMain == null)
					__launchermetaMain = new LaunchermetaDownload().Download().Result;
				return __launchermetaMain;
			}
			internal set
			{
				__launchermetaMain = value;
			}
		}
	}
}
