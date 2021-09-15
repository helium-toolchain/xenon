using System;

namespace Xenon.TypeLib
{
	public static class VersionConvert
	{
		public static String ToString(Version value)
			=> $"{value.Major}.{value.Minor}.{value.Hotfix}";

		public static Version ToVersion(String value)
		{
			String[] sv = value.Split('.');

			if(sv.Length != 3)
			{
				throw new ArgumentException("Versions must have three numbers");
			}

			return new TypeLib.Version
			{
				Major = Convert.ToUInt16(sv[0]),
				Minor = Convert.ToUInt16(sv[1]),
				Hotfix = Convert.ToUInt16(sv[2])
			};
		}
	}
}
