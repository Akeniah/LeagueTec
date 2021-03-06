﻿using System.Linq;
using Adept_AIO.Champions.Riven.Core;
using Aimtec;

namespace Adept_AIO.Champions.Riven.Update.Miscellaneous
{
    internal class SafetyMeasure
    {
        public static void OnProcessSpellCast(Obj_AI_Base sender, Obj_AI_BaseMissileClientDataEventArgs args)
        {
            if (!MenuConfig.Miscellaneous["Interrupt"].Enabled || sender == null)
            {
                return;
            }

            if (SpellConfig.E.Ready && (TargetedSpells.Contains(args.SpellData.Name) || DamageSpells.Contains(args.SpellData.Name)) && args.Target.IsMe)
            {
                SpellConfig.E.Cast(Game.CursorPos);
            }

            if (SpellConfig.W.Ready && SpellManager.InsideKiBurst(sender.ServerPosition, sender.BoundingRadius) && InterrupterSpell.Contains(args.SpellData.Name))
            {
                SpellConfig.W.Cast();
            }
        }

        private static readonly string[] DamageSpells =
        {
            "MonkeyKingSpinToWin", "KatarinaRTrigger", "HungeringStrike",
            "TwitchEParticle", "RengarPassiveBuffDashAADummy",
            "RengarPassiveBuffDash",
            "BraumBasicAttackPassiveOverride", "gnarwproc",
            "hecarimrampattack", "illaoiwattack", "JaxEmpowerTwo",
            "JayceThunderingBlow", "RenektonSuperExecute",
            "vaynesilvereddebuff"
        };

        private static readonly string[] TargetedSpells =
        {
            "MonkeyKingQAttack", "FizzPiercingStrike", "IreliaEquilibriumStrike",
            "RengarQ", "GarenQAttack", "GarenRPreCast",
            "PoppyPassiveAttack", "viktorqbuff", "FioraEAttack",
            "TeemoQ"
        };

        private static readonly string[] InterrupterSpell =
        {
            "RenektonPreExecute", "TalonCutthroat",
            "XenZhaoThrust3", "KatarinaRTrigger", "KatarinaE",
        };
    }
}
