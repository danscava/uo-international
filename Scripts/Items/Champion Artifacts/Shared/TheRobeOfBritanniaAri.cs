using System;
using Server;

namespace Server.Items
{
	public class TheRobeOfBritanniaAri : BaseOuterTorso
	{
		public override int LabelNumber{ get{ return 1094931; } } // The Robe of Britannia "Ari" [Replica]

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		private int m_Bonus = 20;
		private SkillMod m_SkillMod;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Bonus
		{
			get
			{
				return m_Bonus;
			}
			set
			{
				InvalidateProperties();

				if ( m_Bonus == 0.0 )
				{
					if ( m_SkillMod != null )
						m_SkillMod.Remove();

					m_SkillMod = null;
				}
				else if ( m_SkillMod == null && Parent is Mobile )
				{
					m_SkillMod = new DefaultSkillMod( SkillName.EvalInt, true, m_Bonus );
					((Mobile)Parent).AddSkillMod( m_SkillMod );
				}
				else if ( m_SkillMod != null )
				{
					m_SkillMod.Value = m_Bonus;
				}
			}
		}

		public override void OnAdded(IEntity parent)
		{
			base.OnAdded( parent );

			if ( m_Bonus != 0 && parent is Mobile )
			{
				if ( m_SkillMod != null )
					m_SkillMod.Remove();

				m_SkillMod = new DefaultSkillMod( SkillName.EvalInt, true, m_Bonus );
				((Mobile)parent).AddSkillMod( m_SkillMod );
			}
		}

		public override void OnRemoved(IEntity parent)
		{
			base.OnRemoved( parent );

			if ( m_SkillMod != null )
				m_SkillMod.Remove();

			m_SkillMod = null;
		}
		public override int Hue {
			get {
				return 0x48b;
			}
			set {
				base.Hue = 0x48b ;
			}
		}
		[Constructable]
		public TheRobeOfBritanniaAri() : base( 0x2684 )
		{
			Name = "The Robe of Britannia \"Ari\" ";
			Hue = 0x48b;
			StrRequirement = 0;
		}

		public TheRobeOfBritanniaAri( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
