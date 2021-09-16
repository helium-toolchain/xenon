using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using Xenon.Installers.Mojang.Commons.VersionJson;

namespace Xenon.Installers.MojangClient.Libraries
{
	public class LibraryWorker
	{
		public const String LibraryFolder = ".minecraft/libraries";
		private static readonly HttpClient httpClient;

		static LibraryWorker()
		{
			httpClient = new();
		}

		public async Task DownloadLibrary(Library library, String installPath)
		{
			if(library.Rules.Length != 0 && library.Rules[0].Action == "allow" && 
				(library.Rules[0].OperatingSystem.Name == "osx" || library.Rules[0].OperatingSystem.Name == "macos"))
			{
				return;
			}

			FileInfo downloadPath = new($"{installPath}/{LibraryFolder}/{library.Downloads.Artifact.Path}");
			if(!downloadPath.Directory.Exists)
			{
				downloadPath.Directory.Create();
			}

			HttpResponseMessage message = await httpClient.GetAsync(library.Downloads.Artifact.Url);

			await using Stream memoryStream = await message.Content.ReadAsStreamAsync();
			await using FileStream fileStream = downloadPath.Create();

			memoryStream.CopyTo(fileStream);
			fileStream.Flush();

			if(OperatingSystem.IsMacOS() || OperatingSystem.IsMacCatalyst())
			{
				return; // you just dont exist.
			}

			if(OperatingSystem.IsLinux() && library.Downloads.Classifiers?.LinuxNatives != null)
			{
				downloadPath = new($"{installPath}/{LibraryFolder}/{library.Downloads.Classifiers.LinuxNatives.Path}");

				message = await httpClient.GetAsync(library.Downloads.Classifiers.LinuxNatives.Url);

				await using Stream nativeMemoryStream = await message.Content.ReadAsStreamAsync();
				await using FileStream nativeFileStream = downloadPath.Create();

				memoryStream.CopyTo(fileStream);
				fileStream.Flush();

				return;
			}

			if(OperatingSystem.IsWindows() && library.Downloads.Classifiers?.WindowsNatives != null)
			{
				downloadPath = new($"{installPath}/{LibraryFolder}/{library.Downloads.Classifiers.WindowsNatives.Path}");

				message = await httpClient.GetAsync(library.Downloads.Classifiers.WindowsNatives.Url);

				await using Stream nativeMemoryStream = await message.Content.ReadAsStreamAsync();
				await using FileStream nativeFileStream = downloadPath.Create();

				memoryStream.CopyTo(fileStream);
				fileStream.Flush();

				return;
			}

			return; // sucks to be you, no natives for you. use windows or linux.
		}
	}
}
