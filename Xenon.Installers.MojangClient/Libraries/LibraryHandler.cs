using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using Xenon.Installers.Mojang.Commons.VersionJson;

namespace Xenon.Installers.MojangClient.Libraries
{
	public class LibraryHandler
	{
		[SuppressMessage("Design", "CA1822")]
		public void DownloadLibraries(VersionMain version, String installDirectory)
		{
			foreach(Library l in version.Libraries)
			{
				_ = Task.Run(async () => { await new LibraryWorker().DownloadLibrary(l, installDirectory); });
			}
		}
	}
}
