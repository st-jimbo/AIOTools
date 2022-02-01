﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AIOTools.Items
{
	public class AIOT7 : ModItem
	{
		private int mode = 1;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AIOT Mk.VII (Golem Tier)");
			Tooltip.SetDefault("Combination pickaxe, axe, and hammer\nRight click to switch modes");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.damage = 42;
			item.knockBack = 6.5f;
			item.useAnimation = 20;
			item.pick = 210;
			item.axe = 25;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Lime;
			SetUpItem();
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			// change mode
			if (player.altFunctionUse == 2)
			{
				if (mode == 0)
                {
					mode = 1; // hammer mode
				}
				else if (mode == 1)
                {
					mode = 0; // normal mode
				}
				SetUpItem();
				Main.PlaySound(SoundID.Item37, player.Center);
				return true;
			}
			return true;
		}

		private void SetUpItem()
		{
			switch(mode)
			{
				case 0: // HAMMERTIME
					item.useTime = 12;
					item.pick = 0;
					item.axe = 0;
					item.hammer = 90;
					break;

				case 1: // not hammertime
					item.useTime = 6;
					item.pick = 210;
					item.axe = 25;
					item.hammer = 0;
					break;
			}

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}