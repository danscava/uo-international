using System;
using Server;

namespace Server.Items
{
	[Flipable( 0x2684, 0x2683 )]
	public class MageRobe : BaseOuterTorso
	{    
		public override int ArmorBase{ get{ return 5; } }

		[Constructable]
		public MageRobe() : this( 0x455 )
		{
			Name = "a mage's robe";
			Hue = 0;
			LootType = LootType.Regular;
			Weight = 3.0;

		}

		public MageRobe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
