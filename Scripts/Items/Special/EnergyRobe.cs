using System;
using Server;

namespace Server.Items
{
	[Flipable( 0x2684, 0x2683 )]
	public class EnergyRobe : BaseOuterTorso
	{  
		public override int Hue {
			get {
				return 2605;
			}
			set {
				base.Hue = 2605 ;
			}
		}
		#region Stat Mods
		public void AddStatMods( Mobile m )
		{
			if ( m == null )
				return;

			string modName = this.Serial.ToString();

			StatMod strMod = new StatMod( StatType.Str, String.Format( "[Energy Robe] +Str {0}", modName ), +0, TimeSpan.Zero );
			StatMod dexMod = new StatMod( StatType.Dex, String.Format( "[Energy Robe] +Dex {0}", modName ), +0, TimeSpan.Zero );
			StatMod intMod = new StatMod( StatType.Int, String.Format( "[Energy Robe] +Int {0}", modName ), +10, TimeSpan.Zero );

			m.AddStatMod( strMod );
			m.AddStatMod( dexMod );
			m.AddStatMod( intMod );
		}

		public void RemoveStatMods( Mobile m )
		{
			if ( m == null )
				return;

			string modName = this.Serial.ToString();

			m.RemoveStatMod( String.Format( "[Energy Robe] +Str {0}", modName ) );
			m.RemoveStatMod( String.Format( "[Energy Robe] +Dex {0}", modName ) );
			m.RemoveStatMod( String.Format( "[Energy Robe] +Int {0}", modName ) );
		}

		public override void OnAdded( IEntity parent )
		{
			base.OnAdded( parent );
			AddStatMods( parent as Mobile );
		}

		public override void OnRemoved( IEntity parent )
		{
			base.OnRemoved( parent );
			RemoveStatMods( parent as Mobile );
		}

		#endregion
		[Constructable]
		public EnergyRobe() : this( 0x455 )
		{
		}

		[Constructable]
		public EnergyRobe( int hue ) : base( 0x2684, hue )
		{
			Name = "Energy Robe";
			Hue = 2605;
			LootType = LootType.Regular;
			Weight = 3.0;
			Layer = Layer.OuterTorso;
		}

		public EnergyRobe( Serial serial ) : base( serial )
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
