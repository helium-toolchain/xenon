using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

using Xenon.InstallerLoader.Metadata;

namespace Xenon.InstallerLoader
{
    public class InstallerLoader
    {
        private readonly Dictionary<String, IInstaller> __installers = new();
		private readonly Dictionary<String, Version> __installerVersions = new();
		private readonly Dictionary<String, IInstallHandler> __installHandlers = new();

		public void LoadInstallers()
		{
			String[] installers = Directory.GetFiles("./installers", "*.dll");
			String[] installerJsons = Directory.GetFiles("./installers", "*.json");

			if(installers.Length != installerJsons.Length)
			{
				throw new InvalidOperationException($"Cannot load installers: inequal amounts of installer files and installer metadata files found.");
			}

			ResolveDependencies(installerJsons);

			foreach(String v in installers)
			{
				Assembly installerAssembly = Assembly.LoadFile(v);
				Type[] installer = installerAssembly.GetExportedTypes().Where(type => typeof(IInstaller).IsAssignableFrom(type) &&
					type.IsClass && !type.IsAbstract).ToArray();
				Type[] handler = installerAssembly.GetExportedTypes().Where(type => typeof(IInstallHandler).IsAssignableFrom(type) &&
					type.IsClass && !type.IsAbstract).ToArray();
			}
		}

		private void ResolveDependencies(String[] jsons)
		{
			List<InstallerData> data = new();

			foreach(String v in jsons)
			{
				data.Add(JsonSerializer.Deserialize<InstallerData>(v));
			}
		}
    }
}
