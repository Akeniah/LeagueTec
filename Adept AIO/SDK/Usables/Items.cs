﻿using System;
using System.Linq;
using Adept_AIO.SDK.Extensions;
using Adept_AIO.SDK.Methods;
using Aimtec;

namespace Adept_AIO.SDK.Usables
{
    internal class Items
    {
        private static readonly string[] Tiamats = {"ItemTiamatCleave", "ItemTitanicHydraCleave", "ItemTiamatCleave"};
        public static float TiamatCastTime;

        public static void CastTiamat()
        {
            SpellSlot? slot = null;
          
            foreach (var tiamat in Tiamats)
            {
                if (CanUseItem(tiamat))
                {
                    slot = GetItemSlot(tiamat);
                }
            }

            if (slot == null)
            {
                return;
            }

            Global.Player.SpellBook.CastSpell((SpellSlot) slot);
            TiamatCastTime = Game.TickCount;
        }

        public static void CastItem(string itemName, Vector3 position = new Vector3())
        {
            var slot = GetItemSlot(itemName);

            if (!CanUseItem(itemName))
            {
                return;
            }

            if(Global.Player.ChampionName == "LeeSin")
            DebugConsole.Print("DEBUG: [Success] CASTING WARD.", ConsoleColor.Green);
         
            if (position.IsZero)
            {
                Global.Player.SpellBook.CastSpell(slot);
            }
            else
            {
                Global.Player.SpellBook.CastSpell(slot, position);
            }
        }

        public static bool CanUseItem(string itemName)
        {
            var slot = GetItemSlot(itemName);
        
            if (slot != SpellSlot.Unknown)
            {
                return Global.Player.SpellBook.GetSpellState(slot) == SpellState.Ready;
            }
            return false;
        }

        private static SpellSlot GetItemSlot(string itemName)
        {   
            var slot = Global.Player.Inventory.Slots.FirstOrDefault(x => x.ItemName == itemName);

            return slot?.SpellSlot ?? SpellSlot.Unknown;
        }
    }
}
