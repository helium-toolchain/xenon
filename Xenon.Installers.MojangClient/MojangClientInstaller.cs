using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xenon.InstallerLoader;
using Xenon.InstallerLoader.Metadata;
using Xenon.Installers.Mojang.Commons.Launchermeta;

namespace Xenon.Installers.MojangClient
{
	public class MojangClientInstaller : IInstaller
	{
		public String Id => "mojangclient";

		public TypeLib.Version Version => new(0, 0, 1);

		public InstallerEnvironment Environment => InstallerEnvironment.Client;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Disable()
		{
			return;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Initialize()
		{
			MojangData.MojangHelper = new();
			Tags = new String[]
			{
				"release",
				"snapshot",
				"alpha",
				"beta",
				"experimental"
			};
		}

		public String[] ListTags()
			=> Tags;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public String[] ListVersions()
			=> (from x in MojangData.MojangHelper.LaunchermetaMain.Versions
				select x.VersionId).ToArray();

		public String[] ListVersions(params String[] tags)
		{
			String[] versions = Array.Empty<String>();

			foreach(String v in tags)
			{
				ReleaseType type = GetReleaseType(v);

				versions = versions.Concat(from x in MojangData.MojangHelper.LaunchermetaMain.Versions
										   where x.ReleaseType == type
										   select x.VersionId).ToArray();
			}
			return versions;
		}

		private String[] Tags;

		private static ReleaseType GetReleaseType(String @string)
			=> @string switch
			{
				"release" => ReleaseType.Release,
				"snapshot" => ReleaseType.Snapshot,
				"alpha" => ReleaseType.Alpha,
				"beta" => ReleaseType.Beta,
				"experimental" => ReleaseType.Experimental,
				_ => throw new ArgumentException("Unknown release type")
			};
	}
}
