using System;

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
	}
}
