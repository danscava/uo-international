using System;
using Server.Network;

namespace Server.Misc
{
	public class LoginStats
	{
		public static void Initialize()
		{
			// Register our event handler
			EventSink.Login += new LoginEventHandler( EventSink_Login );
		}

		private static void EventSink_Login( LoginEventArgs args )
		{
			int userCount = NetState.Instances.Count;
			int itemCount = World.Items.Count;
			int mobileCount = World.Mobiles.Count;
			userCount += 20;
			Mobile m = args.Mobile;

			m.SendMessage( "Welcome, {0}! There {1} currently {2} user{3} online in the world.",
				args.Mobile.Name,
				userCount == 1 ? "is" : "are",
				userCount, userCount == 1 ? "" : "s"
				//itemCount, itemCount == 1 ? "" : "s",
				//mobileCount, mobileCount == 1 ? "" : "s" 
			);
		}
	}
}