using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "an ostard corpse" )]
	public class MidOstard : BaseMount
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
		public MidOstard() : this( "a mid ostard" )
		{
		}

		[Constructable]
		public MidOstard( string name ) : base( name, 0xD2, 0x3EA3, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x270;

			SetStr( 94, 170 );
			SetDex( 80, 110 );
			SetInt( 6, 10 );

			SetHits( 155, 177 );
			SetMana( 0 );
			Hue = Utility.RandomAnimalHue();
			SetDamage( 12, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Fire, 5, 15 );

			SetSkill( SkillName.MagicResist, 77.1, 88.0 );
			SetSkill( SkillName.Tactics, 77.3, 98.0 );
			SetSkill( SkillName.Wrestling, 77.3, 98.0 );

			Fame = 450;
			Karma = 0;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 69.1;
			MinLoreSkill = 69.1;
		}

		public override void OnThink()
		{
			if ( Controlled == true )
			{               
				if ( this.S1 == true )
				{
					this.S1 = false;
					this.Tamable = true;
					this.ControlSlots = 0;
					this.MinTameSkill = 0;
				}
			}
		}

		public override int Meat{ get{ return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Ostard; } }

		public MidOstard( Serial serial ) : base( serial )
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
		}
	}
}