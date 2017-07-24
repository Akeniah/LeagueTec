﻿using Aimtec;
using Aimtec.SDK.Damage;

namespace Adept_AIO.Champions.Riven.Core
{
    internal class Dmg
    {
        public static double Damage(Obj_AI_Base target)
        {
            if (target == null)
            {
                return 0;
            }

            var dmg = ObjectManager.GetLocalPlayer().GetAutoAttackDamage(target);

            if (SpellConfig.W.Ready)
            {
                dmg += ObjectManager.GetLocalPlayer().GetSpellDamage(target, SpellSlot.W);
            }

            if (SpellConfig.Q.Ready)
            {
                var count = 4 - Extensions.CurrentQCount;
                dmg += (ObjectManager.GetLocalPlayer().GetSpellDamage(target, SpellSlot.Q) + dmg) * count;
            }

            if (SpellConfig.R.Ready)
            {
                dmg += ObjectManager.GetLocalPlayer().GetSpellDamage(target, SpellSlot.R);
            }
            return dmg;
        }
    }
}
