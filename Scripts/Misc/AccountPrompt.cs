using System;
using Server;
using Server.Accounting;

namespace Server.Misc
{
	public class AccountPrompt
	{
		public static void Initialize()
		{
			if ( Accounts.Count == 0 && !Core.Service )
			{
				string username = Environment.GetEnvironmentVariable ("UOMASTER");
				string password = Environment.GetEnvironmentVariable ("UOPASS");
				Account a = new Account( username, password );
				a.AccessLevel = AccessLevel.Owner;
			}
		}
	}
}