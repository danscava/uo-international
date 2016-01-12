using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBSpecials : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public SBSpecials()
		{
		}
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( RewardBlackDyeTub ), 350000, 999, 0xFAB, 0x0001 ) );

				Add( new GenericBuyInfo( typeof( FurnitureDyeTub ), 700000, 999, 0xFAB, 0x0001 ) );

				Add( new GenericBuyInfo( typeof( LeatherDyeTub ), 700000, 999, 0xFAB, 0x0001 ) );

				Add( new GenericBuyInfo( typeof( MetallicClothDyetub ), 1500000, 999, 0xFAB, 0x0001 ) );

				Add( new GenericBuyInfo( typeof( MetallicLeatherDyeTub ), 1500000, 999, 0xFAB, 0x0001 ) );
			}
		}
		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Kasa ), 15 );
				Add( typeof( LeatherJingasa ), 5 );
				Add( typeof( ClothNinjaHood ), 16 );
			}
		}
	}
}
