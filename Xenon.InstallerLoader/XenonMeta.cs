using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Xenon.InstallerLoader
{
	/// <summary>
	/// Xenon launcher metadata for each installation; contains startup arguments to be passed to the game
	/// as well as files to be checked by the launcher.
	/// </summary>
	public class XenonMeta
	{
		/// <summary>
		/// Startup arguments for the game. 
		/// </summary>
		[JsonPropertyName("arguments")]
		public String[] Arguments { get; set; }

		/// <summary>
		/// Relative file paths to be checked by the launcher. If the file does not exist, abort.
		/// </summary>
		[JsonPropertyName("files")]
		public String[] Files { get; set; }

		/// <summary>
		/// Java version to be used if the user has not specified one.
		/// </summary>
		[JsonPropertyName("java")]
		public String DefaultJavaVersion { get; set; }
	}
}
