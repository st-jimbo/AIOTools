using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AIOTools.Items
{
	public class AIOT2 : ModItem
	{
		private int mode = 1;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AIOT Mk.II (Gold Tier)");
			Tooltip.SetDefault("Combination pickaxe, axe, and hammer\nRight click to switch modes");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 40;
			item.damage = 12;
			item.knockBack = 4.0f;
			item.useAnimation = 22;
			item.pick = 55;
			item.axe = 11;
			item.tileBoost = 1;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.value = Item.sellPrice(silver: 20);
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
					item.hammer = 55;
					break;

				case 1: // not hammertime
					item.useTime = 15;
					item.pick = 55;
					item.axe = 11;
					item.hammer = 0;
					break;
			}

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("AIOT1"));
			recipe.AddIngredient(ItemID.GoldBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("AIOT1"));
			recipe.AddIngredient(ItemID.PlatinumBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}