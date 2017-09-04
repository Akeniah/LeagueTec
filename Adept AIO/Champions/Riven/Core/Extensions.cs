﻿using Adept_AIO.SDK.Extensions;

namespace Adept_AIO.Champions.Riven.Core
{
    internal class Extensions
    {
        public static float FlashRange()
        {
            var flashRange = 425 + 35 + SpellConfig.W.Range;
            return AllIn ? flashRange : 0;
        }

        public static int EngageRange
        {
            get
            {
                var range = 0f;

                if (AllIn)
                {
                    range += 425;
                }
                else
                {
                    range += Global.Player.AttackRange;
                }

                if (SpellConfig.E.Ready)
                {
                    range += SpellConfig.E.Range - 80;
                }
                else if (SpellConfig.Q.Ready && !SpellConfig.E.Ready)
                {
                    range += SpellConfig.Q.Range;
                }

                return (int)range;
            }
        }

        public static bool DidJustAuto;
        public static bool AllIn;

        public static int CurrentQCount = 1;
        public static int LastQCastAttempt;

        public static string[] InvulnerableList = { "FioraW", "kindrednodeathbuff", "Undying Rage", "JudicatorIntervention" };
   
        public static HarassPattern Current;
        public static UltimateMode UltimateMode;
    }

    public enum HarassPattern
    {
        SemiCombo = 0,
        AvoidTarget = 1, 
        BackToTarget = 2 
    }

    public enum UltimateMode
    {
        First,
        Second
    }
}