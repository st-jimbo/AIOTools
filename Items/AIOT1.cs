using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AIOTools.Items
{
	public class AIOT1 : ModItem
	{
		private int mode = 1;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AIOT Mk.I (Copper Tier)");
			Tooltip.SetDefault("Combination pickaxe, axe, and hammer\nRight click to switch modes");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 40;
			item.damage = 8;
			item.knockBack = 3.5f;
			item.useAnimation = 24;
			item.pick = 40;
			item.axe = 8;
			item.tileBoost = 1;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.White;
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
					mode = 1; // normal mode
					CombatText.NewText(player.getRect(), Color.LightGreen, "Pickaxe and axe mode activated!");
				}
				else if (mode == 1)
                {
					mode = 0; // hammer mode
					CombatText.NewText(player.getRect(), Color.LightYellow, "Hammer mode activated!");
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
					item.useTime = 20;
					item.pick = 0;
					item.axe = 0;
					item.hammer = 35;
					break;

				case 1: // not hammertime
					item.useTime = 13;
					item.pick = 40;
					item.axe = 8;
					item.hammer = 0;
					break;
			}

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperPickaxe, 1);
			recipe.AddIngredient(ItemID.CopperAxe, 1);
			recipe.AddIngredient(ItemID.CopperHammer, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinPickaxe, 1);
			recipe.AddIngredient(ItemID.TinAxe, 1);
			recipe.AddIngredient(ItemID.TinHammer, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}