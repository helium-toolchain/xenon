using System;

using Xenon.InstallerLoader.Metadata;

namespace Xenon.InstallerLoader
{
    /// <summary>
    /// Base interface for any installer. Each installer must have one class implementing this interface.
    /// </summary>
	public interface IInstaller
	{
        /// <summary>
        /// Called when the installer is loaded.
        /// </summary>
        public void Initialize();

        /// <summary>
        /// Called when the launcher is shut down, in case files need to be closed etc.
        /// </summary>
        public void Disable();

		/// <summary>
		/// Return all versions supported by this installer.
		/// </summary>
		public String[] ListVersions();

		/// <summary>
		/// String ID of the installer. Should match the ID in the installer.json file.
		/// </summary>
		public String Id { get; }

		/// <summary>
		/// Version of the installer. Should match the version in the installer.json file.
		/// </summary>
		public Version Version { get; }

		/// <summary>
		/// Installer environment. Must match the environment in the installer.json file.
		/// </summary>
		public InstallerEnvironment Environment { get; }
	}
}
