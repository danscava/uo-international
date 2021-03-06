using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a nightmare corpse" )]
	public class Nightmare : BaseMount
	{
		public int m_Stage;   

		public bool m_S1;
		public bool m_S2;

		public bool S1
		{
			get{ return m_S1; }
			set{ m_S1 = value; }
		}
		public bool S2
		{
			get{ return m_S2; }
			set{ m_S2 = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Stage
		{
			get{ return m_Stage; }
			set{ m_Stage = value; }
		}

		[Constructable]
		public Nightmare() : this( "a nightmare" )
		{
		}

		[Constructable]
		public Nightmare( string name ) : base( name, 0x74, 0x3EA7, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = Core.AOS ? 0xA8 : 0x16A;

			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );

			SetHits( 333, 366 );

			SetDamage( 24, 44 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.EvalInt, 10.4, 50.0 );
			SetSkill( SkillName.Magery, 10.4, 50.0 );
			SetSkill( SkillName.MagicResist, 85.3, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 80.5, 92.5 );

			Fame = 14000;
			Karma = -14000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 93.1;
			MinLoreSkill = 93.1;

			switch ( Utility.Random( 3 ) )
			{
				case 0:
				{
					BodyValue = 116;
					ItemID = 16039;
					break;
				}
				case 1:
				{
					BodyValue = 178;
					ItemID = 16041;
					break;
				}
				case 2:
				{
					BodyValue = 179;
					ItemID = 16055;
					break;
				}
			}

			PackItem( new SulfurousAsh( Utility.RandomMinMax( 3, 5 ) ) );
		}
		public override void OnThink()
		{
			if ( Controlled == true )
			{               
				if ( this.S1 == true )
				{
					this.S1 = false;
					this.Tamable = true;
					this.ControlSlots = 2;
					this.MinTameSkill = 0;
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public Nightmare( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (bool)m_S1 );
			writer.Write( (bool)m_S2 );
			writer.Write( (int) m_Stage );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			bool m_S1 = reader.ReadBool ();
			bool m_S2 = reader.ReadBool ();
			int m_Stage = reader.ReadInt ();
			int version = reader.ReadInt();

			if ( Core.AOS && BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;
			else if ( !Core.AOS && BaseSoundID == 0xA8 )
				BaseSoundID = 0x16A;
		}
	}
}