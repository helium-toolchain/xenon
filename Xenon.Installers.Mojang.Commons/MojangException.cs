using System;

namespace Xenon.Installers.Mojang.Commons
{
	public class MojangException : Exception
	{
		public MojangException(String message, Int32 executionSegment) : base(message)
		{
			ExecutionSegment = executionSegment;
		}

		public Int32 ExecutionSegment { get; set; }

		/*
		 * 0 - fetching launchermeta data
		 * 1 - parsing launchermeta data
		 * 2 - fetching version.json
		 * 3 - parsing version.json
		 * 4 - fetching assets index
		*/
	}
}
