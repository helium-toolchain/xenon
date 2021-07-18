using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.InstallerLoader
{
    /// <summary>
    /// Base interface for each installer's install handler. Every installer must implement this.
    /// </summary>
    public interface IInstallHandler
    {
        public void Install(String version);

		public void PatchVersionMeta(String version); // only required if this is a client installer - it will not get called for server installers
    }
}
