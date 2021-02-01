using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlateCheckerRemastered
{
    class Configuration
    {
        private static InitializationFile iniFile = new InitializationFile("Plugins\\LSPDFR\\PlateCheckerRemastered.ini");
        public static string PlayerName;
        public static bool UseBritishPersona;
        public static Keys PedCheckKey;
        public static Keys PlateCheckKey;

        public static void ReadIniFile()
        {
            PlayerName = iniFile.ReadString("DISPLAY", "PlayerName", "Loikas");
            UseBritishPersona = iniFile.ReadBoolean("DISPLAY", "UseBritishPersona", false);
            KeysConverter kc = new KeysConverter();
            PlateCheckKey = (Keys)kc.ConvertFromString(iniFile.ReadString("KEYBINDINGS", "PlateCheck", "C"));
            PedCheckKey = (Keys)kc.ConvertFromString(iniFile.ReadString("KEYBINDINGS", "PedCheck", "X"));
        }
    }
}
