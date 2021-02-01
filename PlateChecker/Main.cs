using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response.Mod.API;
using System.Reflection;
using System.Media;

namespace PlateCheckerRemastered
{
    public class Main : Plugin
    {
        public static Random rnd = new Random();
        private static SoundPlayer ButtonSelectSound = new SoundPlayer("Plugins/LSPDFR/PlateCheckerRemastered/Audio/ButtonSelect.wav");

        public override void Initialize()
        {
            LSPD_First_Response.Mod.API.Functions.OnOnDutyStateChanged += DutyChange;
            Configuration.ReadIniFile();
            Game.LogTrivial("~b~PlateChecker Remastered ~w~" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " by ~g~Loikas~w~ has been initialized.");
        }

        public override void Finally()
        {

        }

        public static void DutyChange(bool OnDuty)
        {
            if (OnDuty)
            {
                Game.DisplayNotification("~b~PlateChecker Remastered~y~ " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "~w~ by ~g~Loikas~w~ has been loaded succesfully!");
                MainLogic();
            }
        }
        public static void MainLogic()
        {
            GameFiber.StartNew(delegate
            {
                while (true)
                {
                    GameFiber.Yield();
                    if (Game.IsKeyDown(Configuration.PlateCheckKey))
                    {
                        ButtonSelectSound.Play();
                        Game.LocalPlayer.Character.Tasks.PlayAnimation("random@arrests", "generic_radio_chatter", 1.5f, AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask);
                        PlateChecker.Main();
                    }
                    if (Game.IsKeyDown(Configuration.PedCheckKey) && !Game.LocalPlayer.Character.IsInAnyVehicle(false))
                    {
                        ButtonSelectSound.Play();
                        Game.LocalPlayer.Character.Tasks.PlayAnimation("random@arrests", "generic_radio_chatter", 1.5f, AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask);
                        RunPedName.Main();
                    }
                }

            });
        }
        public static bool IsLSPDFRPluginRunning(string Plugin, Version minversion = null)
        {
            foreach (Assembly assembly in LSPD_First_Response.Mod.API.Functions.GetAllUserPlugins())
            {
                AssemblyName an = assembly.GetName();
                if (an.Name.ToLower() == Plugin.ToLower())
                {
                    if (minversion == null || an.Version.CompareTo(minversion) >= 0) { return true; }
                }
            }
            return false;
        }
    }
}
