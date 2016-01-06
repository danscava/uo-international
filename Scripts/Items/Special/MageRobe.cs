using System;
using Server;

namespace Server.Items
{
	[Flipable( 0x2684, 0x2683 )]
	public class MageRobe : BaseOuterTorso
	{  
		[Constructable]
		public MageRobe() : this( 0x455 )
		{
		}

		[Constructable]
		public MageRobe( int hue ) : base( 0x2684, hue )
		{
			Name = "a mage's robe";
			Hue = 0;
			LootType = LootType.Regular;
			Weight = 3.0;
			Layer = Layer.OuterTorso;
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
