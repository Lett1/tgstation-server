﻿using System.Collections.Generic;
using TGServiceInterface;

namespace TGCommandLine
{
	abstract class InstanceRootCommand : RootCommand
	{
		public static IInterface currentInterface;
		public override ExitCode DoRun(IList<string> parameters)
		{
			if (currentInterface.InstanceName == null)
			{
				OutputProc("Missing instance!");
				return ExitCode.BadCommand;
			}
			else
			{
				var res = currentInterface.ConnectToInstance();
				if (!res.HasFlag(ConnectivityLevel.Connected))
				{
					OutputProc("Unable to connect to instance!");
					return ExitCode.ConnectionError;
				}
				else if (!res.HasFlag(ConnectivityLevel.Authenticated))
				{
					OutputProc("The current user is not authorized to use this instance!");
					return ExitCode.ConnectionError;
				}
			}
			return base.DoRun(parameters);
		}
	}
}
