using System;

namespace Xenon.InstallerLoader
{
	/// <summary>
	/// Base interface for each installer's install handler. Every installer must implement this.
	/// </summary>
	public interface IInstallHandler
	{
		/// <summary>
		/// Installs the selected version: download files and assets, set up startup command, ...
		/// </summary>
		public void Install(String version, String installDirectory);

		/// <summary>
		/// For notchian-derived clients: patch the xenon-meta.json file to their needs.
		/// </summary>
		public void PatchVersionMeta(String version, String installDirectory); // only required if this is a client installer - it will not get called for server installers
	}
}
