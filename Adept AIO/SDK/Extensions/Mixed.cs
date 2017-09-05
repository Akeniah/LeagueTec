﻿using Aimtec;

namespace Adept_AIO.SDK.Extensions
{
    internal class Mixed
    {
        public static Vector3 GetFountainPos(GameObject target)
        {
            switch (Game.MapId)
            {
                case GameMapId.SummonersRift:
                    return target.Team == GameObjectTeam.Order
                        ? new Vector3(396, 185.1325f, 462)
                        : new Vector3(14340, 171.9777f, 14390);

                case GameMapId.TwistedTreeline:
                    return target.Team == GameObjectTeam.Order
                        ? new Vector3(1058, 150.8638f, 7297)
                        : new Vector3(14320, 151.9291f, 7235);
            }
            return Vector3.Zero;
        }

        public static int PercentDmg(Obj_AI_Base target, double dmg)
        {
            return (int)(dmg / target.Health * 100);
        }
    }
}
