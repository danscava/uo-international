using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a llama corpse" )]
	public class RidableLlama : BaseMount
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
		public RidableLlama() : this( "a ridable llama" )
		{
		}

		[Constructable]
		public RidableLlama( string name ) : base( name, 0xDC, 0x3EA6, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x3F3;

			SetStr( 21, 49 );
			SetDex( 56, 75 );
			SetInt( 16, 30 );

			SetHits( 33, 44 );
			SetMana( 0 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10, 15 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 19.2, 29.0 );
			SetSkill( SkillName.Wrestling, 19.2, 29.0 );

			Fame = 300;
			Karma = 0;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 29.1;
			MinTameSkill = 30.0;
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

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public RidableLlama( Serial serial ) : base( serial )
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