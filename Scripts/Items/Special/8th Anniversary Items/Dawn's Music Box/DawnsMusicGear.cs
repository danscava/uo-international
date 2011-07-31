﻿using System;
using Server.Targeting;

namespace Server.Items
{
	[Flipable( 0x1053, 0x1054 )]
	public class DawnsMusicGear : Item
	{
		public static DawnsMusicGear RandomCommon
		{
			get { return new DawnsMusicGear( DawnsMusicBox.RandomTrack( DawnsMusicRarity.Common ) ); }
		}

		public static DawnsMusicGear RandomUncommon
		{
			get { return new DawnsMusicGear( DawnsMusicBox.RandomTrack( DawnsMusicRarity.Uncommon ) ); }
		}

		public static DawnsMusicGear RandomRare
		{
			get { return new DawnsMusicGear( DawnsMusicBox.RandomTrack( DawnsMusicRarity.Rare ) ); }
		}

		private MusicName m_Music;

		[CommandProperty( AccessLevel.GameMaster )]
		public MusicName Music
		{
			get { return m_Music; }
			set { m_Music = value; }
		}

		[Constructable]
		public DawnsMusicGear() : this( DawnsMusicBox.RandomTrack( DawnsMusicRarity.Common ) )
		{
		}

		[Constructable]
		public DawnsMusicGear( MusicName music ) : base( 0x1053 )
		{
			m_Music = music;

			Weight = 1.0;
		}

		public DawnsMusicGear( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			DawnsMusicInfo info = DawnsMusicBox.GetInfo( m_Music );

			if ( info != null )
			{
				if ( info.Rarity == DawnsMusicRarity.Common )
					list.Add( 1075204 ); // Gear for Dawn's Music Box (Common)
				else if ( info.Rarity == DawnsMusicRarity.Uncommon )
					list.Add( 1075205 ); // Gear for Dawn's Music Box (Uncommon)
				else if ( info.Rarity == DawnsMusicRarity.Rare )
					list.Add( 1075206 ); // Gear for Dawn's Music Box (Rare)

				list.Add( info.Name );
			}
			else
				base.AddNameProperty( list );
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.Target = new InternalTarget( this );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}

		public class InternalTarget : Target
		{
			private DawnsMusicGear m_Gear;

			public InternalTarget( DawnsMusicGear gear ) : base( 2, false, TargetFlags.None )
			{
				m_Gear = gear;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Gear == null || m_Gear.Deleted )
					return;

				DawnsMusicBox box = targeted as DawnsMusicBox;

				if ( box != null )
				{
					if ( !box.Tracks.Contains( m_Gear.Music ) )
					{
						box.Tracks.Add( m_Gear.Music );
						box.InvalidateProperties();

						m_Gear.Delete();

						from.SendLocalizedMessage( 1071961 ); // This song has been added to the musicbox.
					}
					else
						from.SendLocalizedMessage( 1071962 ); // This song track is already in the musicbox.
				}
				else
					from.SendLocalizedMessage( 1071964 ); // Gears can only be put into a musicbox.
			}
		}
	}
}