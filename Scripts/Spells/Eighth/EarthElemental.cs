using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Eighth
{
	public class EarthElementalSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Earth Elemental", "Kal Vas Xen Ylem",
				269,
				9020,
				false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		public override bool UseSphereSystem { get { return false; } }
        public override void SelectTarget()
        {
            Caster.Target = new InternalSphereTarget(this);
        }

        public override void OnSphereCast()
        {
            if (SpellTarget != null)
            {
                if (SpellTarget is IPoint3D)
                {
                    Target((IPoint3D)SpellTarget);
                }
                else
                {
                    Caster.SendAsciiMessage("Invalid Target");
                }
            }
            FinishSequence();
        }



	    public EarthElementalSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 2) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

        public void Target(IPoint3D p)
        {
            if (!Caster.CanSee(p))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (!CheckLineOfSight(p))
            {
                this.DoFizzle();
                Caster.SendAsciiMessage("Target is not in line of sight");
            }
            else if (CheckSequence())
            {
            }

            FinishSequence();
        }

	    public override void OnCast()
		{
			if ( CheckSequence() )
			{
				TimeSpan duration = TimeSpan.FromSeconds( (2 * Caster.Skills.Magery.Fixed) / 5 );

				if ( Core.AOS )
					SpellHelper.Summon( new SummonedEarthElemental(), Caster, 0x217, duration, false, false );
				else
					SpellHelper.Summon( new EarthElemental(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}

        private class InternalSphereTarget : Target
        {
            private EarthElementalSpell m_Owner;

            public InternalSphereTarget(EarthElementalSpell owner)
                : base(8, true, TargetFlags.Harmful)
            {
                m_Owner = owner;
                m_Owner.Caster.SendAsciiMessage("Select target...");
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is IPoint3D)
                {
                    m_Owner.SpellTarget = o;
                    m_Owner.CastSpell();
                }
                else
                {
                    m_Owner.Caster.SendAsciiMessage("Invalid target");
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                if (m_Owner.SpellTarget == null)
                {
                    m_Owner.Caster.SendAsciiMessage("Targeting cancelled.");
                }
            }
        }
	}
}