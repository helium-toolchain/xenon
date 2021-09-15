using System;
using System.Linq;

using Xenon.InstallerLoader.Metadata;

namespace Xenon.InstallerLoader
{
	/// <summary>
	/// API class for all functions of this assembly. Designed for internal Xenon use only.
	/// </summary>
	public class Loader
	{
		private readonly InstallerLoader __loader;

		public Loader()
		{
			this.__loader = new();
		}

		/// <summary>
		/// Loads all installers present in the folder.
		/// </summary>
		public void LoadInstallers()
		{
			this.__loader.LoadInstallers();

			foreach(IInstaller v in this.__loader.__installers.Values)
			{
				v.Initialize();
			}
		}

		/// <summary>
		/// Unloads all installers present in the folder.
		/// </summary>
		public void UnloadInstallers()
		{
			foreach(IInstaller v in this.__loader.__installers.Values)
			{
				v.Disable();
			}
		}

		/// <summary>
		/// Gets all installer IDs.
		/// </summary>
		public String[] GetInstallers()
			=> this.__loader.__installers.Keys.ToArray();

		/// <summary>
		/// Gets the installer data for one specific installer.
		/// </summary>
		public InstallerData GetInstallerData(String installerId)
			=> this.__loader.__installerData[installerId];

		/// <summary>
		/// Gets an installer instance for one specific installer.
		/// </summary>
		public IInstaller GetInstaller(String installerId)
			=> this.__loader.__installers[installerId];

		/// <summary>
		/// Gets an install handler instance for one specific installer.
		/// </summary>
		public IInstallHandler GetInstallHandler(String installerId)
			=> this.__loader.__installHandlers[installerId];

		/// <summary>
		/// Gets one specific installer's version.
		/// </summary>
		public Xenon.TypeLib.Version GetInstallerVersion(String installerId)
			=> this.__loader.__installerVersions[installerId];

		/// <summary>
		/// Gets all supported tags for one specific installer.
		/// </summary>
		public String[] GetTags(String installerId)
			=> this.__loader.__installers[installerId].ListTags();

		/// <summary>
		/// Gets all supported versions for one specific installer, filtered by the specified tags.
		/// </summary>
		public String[] GetVersions(String installerId, params String[] tags)
			=> this.__loader.__installers[installerId].ListVersions(tags);

		/// <summary>
		/// Installs the specified version of the specified installer.
		/// </summary>
		public void Install(String installerId, String version, String installDirectory)
		{
			IInstallHandler handler = this.__loader.__installHandlers[installerId];
			handler.Install(version, installDirectory);

			if(this.__loader.__installerData[installerId].Environment == InstallerEnvironment.Client)
			{
				handler.PatchVersionMeta(version, installDirectory);
			}
		}

		/// <summary>
		/// Patches the version metadata file of the specified version, using the specified installer.
		/// </summary>
		public void PatchVersionMeta(String installerId, String version, String installDirectory)
		{
			if(this.__loader.__installerData[installerId].Environment == InstallerEnvironment.Server)
			{
				throw new ArgumentException("The specified installer is a server installer and cannot patch a version metadata file.");
			}

			IInstallHandler handler = this.__loader.__installHandlers[installerId];
			handler.PatchVersionMeta(version, installDirectory);
		}
	}
}
