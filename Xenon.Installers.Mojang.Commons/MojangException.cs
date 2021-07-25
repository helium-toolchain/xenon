using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		*/
	}
}
