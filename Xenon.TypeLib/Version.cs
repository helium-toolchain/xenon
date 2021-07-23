using System;

namespace Xenon.TypeLib
{
#pragma warning disable CS0660
#pragma warning disable CS0661
	public struct Version
#pragma warning restore CS0660
#pragma warning restore CS0661
	{
		public UInt16 Major { get; set; }
		public UInt16 Minor { get; set; }
		public UInt16 Hotfix { get; set; }

		public Version(UInt16 Major = 0, UInt16 Minor = 0, UInt16 Hotfix = 0)
		{
			this.Major = Major;
			this.Minor = Minor;
			this.Hotfix = Hotfix;
		}

		public static Boolean operator ==(Version left, Version right)
		{
			return left.Major == right.Major
				&& left.Minor == right.Minor
				&& left.Hotfix == right.Hotfix;
		}

		public static Boolean operator !=(Version left, Version right)
		{
			return !(left == right);
		}

		public static Boolean operator >(Version left, Version right)
		{
			if(left.Major != right.Major)
			{
				return left.Major > right.Major;
			}
			if(left.Minor != right.Minor)
			{
				return left.Minor > right.Minor;
			}
			if(left.Hotfix != right.Hotfix)
			{
				return left.Hotfix > right.Hotfix;
			}

			// they are equal
			return false;
		}

		public static Boolean operator <(Version left, Version right)
		{
			if(left.Major != right.Major)
			{
				return left.Major < right.Major;
			}
			if(left.Minor != right.Minor)
			{
				return left.Minor < right.Minor;
			}
			if(left.Hotfix != right.Hotfix)
			{
				return left.Hotfix < right.Hotfix;
			}

			// they are equal
			return false;
		}

		public static Boolean operator >=(Version left, Version right)
		{
			if(left.Major != right.Major)
			{
				return left.Major > right.Major;
			}
			if(left.Minor != right.Minor)
			{
				return left.Minor > right.Minor;
			}
			if(left.Hotfix != right.Hotfix)
			{
				return left.Hotfix > right.Hotfix;
			}

			// they are equal
			return true;
		}

		public static Boolean operator <=(Version left, Version right)
		{
			if(left.Major != right.Major)
			{
				return left.Major < right.Major;
			}
			if(left.Minor != right.Minor)
			{
				return left.Minor < right.Minor;
			}
			if(left.Hotfix != right.Hotfix)
			{
				return left.Hotfix < right.Hotfix;
			}

			// they are equal
			return true;
		}
	}
}
