using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using LSPD_First_Response.Mod.API;
using Microsoft.CSharp.RuntimeBinder;
using Rage;
using Rage.Native;

namespace PlateChecker
{
    internal enum DrugsLevels { POSITIVE, NEGATIVE };
    internal static class DrugTestKit
    {

        private static Dictionary<PoolHandle, DrugsLevels> pedCannabisLevels = new Dictionary<PoolHandle, DrugsLevels>();
        private static Dictionary<PoolHandle, DrugsLevels> pedCocaineLevels = new Dictionary<PoolHandle, DrugsLevels>();
        
        public static bool DoesPedHaveDrugsInSystem(Ped ped)
        {
            addPedToDictionaries(ped);
            return (pedCocaineLevels[ped.Handle] == DrugsLevels.POSITIVE || pedCannabisLevels[ped.Handle] == DrugsLevels.POSITIVE);
        }

        private static void addPedToDictionaries(Ped _ped)
        {
            if (!pedCannabisLevels.ContainsKey(_ped.Handle))
            {
                if (PlateCheckerRemastered.Main.rnd.Next(8) == 0)
                {
                    pedCannabisLevels.Add(_ped.Handle, DrugsLevels.POSITIVE);
                }
                else
                {
                    pedCannabisLevels.Add(_ped.Handle, DrugsLevels.NEGATIVE);
                }
            }
            if (!pedCocaineLevels.ContainsKey(_ped.Handle))
            {
                if (PlateCheckerRemastered.Main.rnd.Next(8) == 0)
                {
                    pedCocaineLevels.Add(_ped.Handle, DrugsLevels.POSITIVE);
                }
                else
                {
                    pedCocaineLevels.Add(_ped.Handle, DrugsLevels.NEGATIVE);
                }

            }
        }

        public static void SetPedDrugsLevels(Ped ped, DrugsLevels cannabisLevel, DrugsLevels cocaineLevel)
        {
            if (ped.Exists() && ped.IsValid())
            {
                Game.LogTrivial("Setting drug levels");
                if (!pedCannabisLevels.ContainsKey(ped.Handle))
                {
                    pedCannabisLevels.Add(ped.Handle, cannabisLevel);
                }
                else
                {
                    pedCannabisLevels[ped.Handle] = cannabisLevel;
                }
                if (!pedCocaineLevels.ContainsKey(ped.Handle))
                {
                    pedCocaineLevels.Add(ped.Handle, cocaineLevel);
                }
                else
                {
                    pedCocaineLevels[ped.Handle] = cocaineLevel;
                }


            }

        }
        public static void SetPedDrugsLevels(Ped ped, bool Cannabis, bool Cocaine)
        {
            DrugsLevels Cannabislevel;
            DrugsLevels Cocainelevel;
            if (Cannabis)
            {
                Cannabislevel = DrugsLevels.POSITIVE;
            }
            else
            {
                Cannabislevel = DrugsLevels.NEGATIVE;
            }
            if (Cocaine)
            {
                Cocainelevel = DrugsLevels.POSITIVE;
            }
            else
            {
                Cocainelevel = DrugsLevels.NEGATIVE;
            }
            SetPedDrugsLevels(ped, Cannabislevel, Cocainelevel);
        }
    }
}
