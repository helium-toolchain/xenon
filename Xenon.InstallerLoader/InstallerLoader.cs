using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

using Xenon.InstallerLoader.Metadata;

namespace Xenon.InstallerLoader
{
	internal sealed class InstallerLoader
	{
		internal readonly Dictionary<String, IInstaller> __installers = new();
		internal readonly Dictionary<String, Xenon.TypeLib.Version> __installerVersions = new();
		internal readonly Dictionary<String, InstallerData> __installerData = new();
		internal readonly Dictionary<String, IInstallHandler> __installHandlers = new();

		private readonly List<InstallerData> __tempData = new();

		public event Action<String, String> MissingRecommendedInstallerEvent;
		public event Action<String, String> IncompatibleInstallerEvent;

		public void LoadInstallers()
		{
			String[] installerJsons = Directory.GetFiles("./installers", "*.json");

			ResolveDependencies(installerJsons);

			foreach(InstallerData i in __tempData)
			{
				String v = i.InstallerId;
				Assembly installerAssembly = Assembly.LoadFile($"./installers/{i.AssemblyFileName}");
				Type[] installer = installerAssembly.GetExportedTypes().Where(type => typeof(IInstaller).IsAssignableFrom(type) &&
					type.IsClass && !type.IsAbstract).ToArray();
				Type[] handler = installerAssembly.GetExportedTypes().Where(type => typeof(IInstallHandler).IsAssignableFrom(type) &&
					type.IsClass && !type.IsAbstract).ToArray();

				IInstaller ia = (IInstaller)Activator.CreateInstance(installer[0]);
				IInstallHandler ha = (IInstallHandler)Activator.CreateInstance(handler[0]);

				__installers.Add(ia.Id, ia);
				__installerVersions.Add(ia.Id, ia.Version);
				__installHandlers.Add(ia.Id, ha);
			}
		}

		private void ResolveDependencies(String[] jsons)
		{

			foreach(String v in jsons)
			{
				__tempData.Add(JsonSerializer.Deserialize<InstallerData>(v));

			}

			foreach(InstallerData v in __tempData)
			{
				__installerData.Add(v.InstallerId, v);
				Task.Run(() => 
				{ 
					ResolveDependency(v); 
				});
			}
		}

		private void ResolveDependency(InstallerData data)
		{
			// duplicate installer check
			if((from x in __tempData
				where x.InstallerId == data.InstallerId
				select x).Count() > 1)
			{
				throw new InvalidDataException($"Duplicate installer {data.InstallerId}");
			}

			// dependency check
			foreach(String x in data.Depends)
			{
				if(!__tempData.Any(xm =>
				{
					return xm.InstallerId == x;
				}))
				{
					throw new InvalidDataException($"Installer {data.InstallerId} is missing dependency {x}, aborting...");
				}
			}

			// incompatibility check
			foreach(String x in data.Incompatible)
			{
				if(__tempData.Any(xm =>
				{
					return xm.InstallerId == x;
				}))
				{
					IncompatibleInstallerEvent(data.InstallerId, x);
				}
			}

			// recommendation check
			foreach(String x in data.Recommends)
			{
				if(!__tempData.Any(xm =>
				{
					return xm.InstallerId == x;
				}))
				{
					MissingRecommendedInstallerEvent(data.InstallerId, x);
				}
			}
		}
	}
}
