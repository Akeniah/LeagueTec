﻿using System.Linq;
using Adept_AIO.Champions.Yasuo.Core;
using Adept_AIO.SDK.Junk;
using Aimtec.SDK.Extensions;
using GameObjects = Adept_AIO.SDK.Junk.GameObjects;

namespace Adept_AIO.Champions.Yasuo.Update.OrbwalkingEvents
{
    internal class JungleClear
    {
        public static void OnPostAttack()
        {
            if (SpellConfig.E.Ready && MenuConfig.JungleClear["E"].Enabled)
            {
                var minion = GameObjects.Jungle.FirstOrDefault(x => x.IsValid && x.Distance(Global.Player) <= SpellConfig.E.Range && !x.HasBuff("YasuoDashWrapper"));

                if (minion == null)
                {
                    return;
                }

                SpellConfig.E.CastOnUnit(minion);
            }

            if (!SpellConfig.Q.Ready) return;
            {
                var minion = GameObjects.Jungle.FirstOrDefault(x => x.Distance(Global.Player) <= SpellConfig.Q.Range && x.Health > 7);
                if (minion == null)
                {
                    return;
                }

                if (Extension.CurrentMode == Mode.Tornado && !MenuConfig.JungleClear["Q3"].Enabled ||
                    Extension.CurrentMode == Mode.Normal && !MenuConfig.JungleClear["Q"].Enabled)
                {
                    return;
                }
            
                SpellConfig.Q.Cast(minion);
            }
        }
    }
}
