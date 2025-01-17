﻿using PlateChecker;
using PlateCheckerRemastered;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlateCheckerRemastered
{
    public static class Functions
    {
        /// <summary>
        /// Check whether the vehicle is insured as per the insurance system.
        /// </summary>
        /// <param name="veh"></param>
        /// <returns></returns>

        public static bool IsVehicleInsured(Vehicle veh)
        {
            if (veh.Exists())
            {

                EVehicleDetailsStatus insurancestatus = VehicleDetails.GetInsuranceStatusForVehicle(veh);
                return insurancestatus == EVehicleDetailsStatus.Valid;

            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Sets the insurance status for a vehicle. Used when vehicle is checked.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="Insured">If false, sets insurance status to expired/none at random.</param>
        public static void SetVehicleInsuranceStatus(Vehicle vehicle, bool Insured)
        {
            if (Insured)
            {
                VehicleDetails.SetInsuranceStatusForVehicle(vehicle, EVehicleDetailsStatus.Valid);
            }
            else
            {
                if (Main.rnd.Next(5) < 2)
                {
                    VehicleDetails.SetInsuranceStatusForVehicle(vehicle, EVehicleDetailsStatus.None);
                }
                else
                {
                    VehicleDetails.SetInsuranceStatusForVehicle(vehicle, EVehicleDetailsStatus.Expired);
                }
            }
        }

        /// <summary>
        /// Sets the insurance status for a vehicle. Used when vehicle is checked.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="InsuranceStatus"></param>
        public static void SetVehicleInsuranceStatus(Vehicle vehicle, EVehicleDetailsStatus InsuranceStatus)
        {
            VehicleDetails.SetInsuranceStatusForVehicle(vehicle, InsuranceStatus);
        }

        /// <summary>
        /// Sets the registration status for a vehicle. Used when vehicle is checked.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="registrationValid">If false, sets status to expired/none at random </param>
        public static void SetVehicleRegistrationStatus(Vehicle vehicle, bool registrationValid)
        {
            if (registrationValid)
            {
                VehicleDetails.SetRegistrationStatusForVehicle(vehicle, EVehicleDetailsStatus.Valid);
            }
            else
            {
                if (Main.rnd.Next(5) < 2)
                {
                    VehicleDetails.SetRegistrationStatusForVehicle(vehicle, EVehicleDetailsStatus.None);
                }
                else
                {
                    VehicleDetails.SetRegistrationStatusForVehicle(vehicle, EVehicleDetailsStatus.Expired);
                }
            }
        }

        /// <summary>
        /// Sets the registration status for a vehicle. Used when vehicle is checked.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="RegistrationStatus"></param>
        public static void SetVehicleRegistrationStatus(Vehicle vehicle, EVehicleDetailsStatus RegistrationStatus)
        {
            VehicleDetails.SetRegistrationStatusForVehicle(vehicle, RegistrationStatus);
        }

        /// <summary>
        /// Gets the registration status for a vehicle. Used when vehicle is checked.
        /// </summary>
        /// <param name="veh"></param>
        /// <returns></returns>
        public static EVehicleDetailsStatus GetVehicleRegistrationStatus(Vehicle veh)
        {
            return VehicleDetails.GetRegistrationStatusForVehicle(veh);
        }

        /// <summary>
        /// Gets the insurance status for a vehicle. Used when vehicle is checked.
        /// </summary>
        /// <param name="veh"></param>
        /// <returns></returns>
        public static EVehicleDetailsStatus GetVehicleInsuranceStatus(Vehicle veh)
        {
            return VehicleDetails.GetInsuranceStatusForVehicle(veh);
        }

        /// <summary>
        /// Sets the drug levels for the ped. Used by Traffic Policer's Drugalyzer.
        /// </summary>
        /// <param name="ped"></param>
        /// <param name="Cannabis"></param>
        /// <param name="Cocaine"></param>
        public static void SetPedDrugsLevels(Ped ped, bool Cannabis, bool Cocaine)
        {
            DrugTestKit.SetPedDrugsLevels(ped, Cannabis, Cocaine);
        }
        /// <summary>
        /// Prevents this ped from being taken over by a Traffic Policer ambient event.
        /// </summary>




        /// <summary>
        /// Use this only if you don't want the vehicle details to appear after typing in a licence plate in a custom window. Remember to reactivate this after you're done fetching the input.
        /// </summary>
        /// <param name="enabled"></param>
        public static void SetAutomaticVehicleDeatilsChecksEnabled(bool enabled)
        {
            Game.LogTrivial("Traffic Policer API: Assembly " + Assembly.GetCallingAssembly().GetName().Name + " setting automatic vehicle details checks to: " + enabled.ToString());
            VehicleDetails.AutomaticDetailsChecksEnabled = enabled;
            VehicleDetails.AutomaticDetailsChecksEnabled = enabled;
        }

        /// <summary>
        /// Adds an Action to the specified button. Only buttons contained in a folder matching your plugin's name can be manipulated.
        /// </summary>
        /// <param name="action">The action to execute if the button is selected.</param>
        /// <param name="buttonName">The texture file name of the button, excluding any directories or file extensions.</param>
        /// <returns>Returns whether the button was successfully added or not. If false, a reason is logged to the console.</returns>

        /// <summary>
        /// Adds an Action and an availability check to the specified button. Only buttons contained in a folder matching your plugin's name can be manipulated.
        /// </summary>
        /// <param name="action">The action to execute if the button is selected.</param>
        /// <param name="isAvailable">Function returning a bool indicating whether the button is currently available (if false, button is hidden). This is often called, so try making this light-weight (e.g. simply return the value of a boolean property). Make sure to do proper checking in your Action too, as the user can forcefully display all buttons via a setting in their config file.</param>
        /// <param name="buttonName">The texture file name of the button, excluding any directories or file extensions.</param>
        /// <returns>Returns whether the button was successfully added or not. If false, a reason is logged to the console.</returns>


        /// <summary>
        /// Raised whenever the player selects a button on the SmartRadio.
        /// </summary>
        public static event Action ButtonSelected;

        internal static void OnButtonSelected()
        {

            if (ButtonSelected != null)
            {
                ButtonSelected();
            }
        }

        //public static void RunLicencePlateCheck(Vehicle veh)
        //{
        //    British_Policing_Script.VehicleRecords recs = British_Policing_Script.API.Functions.GetVehicleRecords(veh);
        //    recs.RunPlateCheck();
        //}

        //public static void RunPedCheck(Ped p, int delay = 0)
        //{
        //    British_Policing_Script.BritishPersona recs = British_Policing_Script.API.Functions.GetBritishPersona(p);
        //    GameFiber.Wait(delay);
        //    recs.RunLicenceCheck();
        //}

        public static VehicleColor GetColors(this Vehicle v)
        {
            return UnsafeGetVehicleColors(v);
        }

        private static unsafe VehicleColor UnsafeGetVehicleColors(Vehicle vehicle)
        {
            int colorPrimaryInt;
            int colorSecondaryInt;

            ulong GetVehicleColorsHash = 0xa19435f193e081ac;
            NativeFunction.CallByHash<uint>(GetVehicleColorsHash, vehicle, &colorPrimaryInt, &colorSecondaryInt);

            VehicleColor colors = new VehicleColor();

            colors.PrimaryColor = (EPaint)colorPrimaryInt;
            colors.SecondaryColor = (EPaint)colorSecondaryInt;

            return colors;
        }
    }

    public enum EPaint
    {
        /* CLASSIC|METALLIC */
        Black = 0,
        Carbon_Black = 147,
        Graphite = 1,
        Anhracite_Black = 11,
        Black_Steel = 2,
        Dark_Steel = 3,
        Silver = 4,
        Bluish_Silver = 5,
        Rolled_Steel = 6,
        Shadow_Silver = 7,
        Stone_Silver = 8,
        Midnight_Silver = 9,
        Cast_Iron_Silver = 10,
        Red = 27,
        Torino_Red = 28,
        Formula_Red = 29,
        Lava_Red = 150,
        Blaze_Red = 30,
        Grace_Red = 31,
        Garnet_Red = 32,
        Sunset_Red = 33,
        Cabernet_Red = 34,
        Wine_Red = 143,
        Candy_Red = 35,
        Hot_Pink = 135,
        Pfister_Pink = 137,
        Salmon_Pink = 136,
        Sunrise_Orange = 36,
        Orange = 38,
        Bright_Orange = 138,
        Gold = 37,
        Bronze = 90,
        Yellow = 88,
        Race_Yellow = 89,
        Dew_Yellow = 91,
        Green = 139,
        Dark_Green = 49,
        Racing_Green = 50,
        Sea_Green = 51,
        Olive_Green = 52,
        Bright_Green = 53,
        Gasoline_Green = 54,
        Lime_Green = 92,
        Hunter_Green = 144,
        Securiror_Green = 125,
        Midnight_Blue = 141,
        Galaxy_Blue = 61,
        Dark_Blue = 62,
        Saxon_Blue = 63,
        Blue = 64,
        Bright_Blue = 140,
        Mariner_Blue = 65,
        Harbor_Blue = 66,
        Diamond_Blue = 67,
        Surf_Blue = 68,
        Nautical_Blue = 69,
        Racing_Blue = 73,
        Ultra_Blue = 70,
        Light_Blue = 74,
        Police_Car_Blue = 127,
        Epsilon_Blue = 157,
        Chocolate_Brown = 96,
        Bison_Brown = 101,
        Creek_Brown = 95,
        Feltzer_Brown = 94,
        Maple_Brown = 97,
        Beechwood_Brown = 103,
        Sienna_Brown = 104,
        Saddle_Brown = 98,
        Moss_Brown = 100,
        Woodbeech_Brown = 102,
        Straw_Brown = 99,
        Sandy_Brown = 105,
        Bleached_Brown = 106,
        Schafter_Purple = 71,
        Spinnaker_Purple = 72,
        Midnight_Purple = 142,
        Metallic_Midnight_Purple = 146,
        Bright_Purple = 145,
        Cream = 107,
        Ice_White = 111,
        Frost_White = 112,
        Pure_White = 134,
        Default_Alloy = 156,
        Champagne = 93,

        /* MATTE */
        Matte_Black = 12,
        Matte_Gray = 13,
        Matte_Light_Gray = 14,
        Matte_Ice_White = 131,
        Matte_Blue = 83,
        Matte_Dark_Blue = 82,
        Matte_Midnight_Blue = 84,
        Matte_Midnight_Purple = 149,
        Matte_Schafter_Purple = 148,
        Matte_Red = 39,
        Matte_Dark_Red = 40,
        Matte_Orange = 41,
        Matte_Yellow = 42,
        Matte_Lime_Green = 55,
        Matte_Green = 128,
        Matte_Forest_Green = 151,
        Matte_Foliage_Green = 155,
        Matte_Brown = 129,
        Matte_Olive_Darb = 152,
        Matte_Dark_Earth = 153,
        Matte_Desert_Tan = 154,

        /* Util */
        Util_Black = 15,
        Util_Black_Poly = 16,
        Util_Dark_Silver = 17,
        Util_Silver = 18,
        Util_Gun_Metal = 19,
        Util_Shadow_Silver = 20,
        Util_Red = 43,
        Util_Bright_Red = 44,
        Util_Garnet_Red = 45,
        Util_Dark_Green = 56,
        Util_Green = 57,
        Util_Dark_Blue = 75,
        Util_Midnight_Blue = 76,
        Util_Blue = 77,
        Util_Sea_Foam_Blue = 78,
        Util_Lightning_Blue = 79,
        Util_Maui_Blue_Poly = 80,
        Util_Bright_Blue = 81,
        Util_Brown = 108,
        Util_Medium_Brown = 109,
        Util_Light_Brown = 110,
        Util_Off_White = 122,

        /* Worn */
        Worn_Black = 21,
        Worn_Graphite = 22,
        Worn_Silver_Grey = 23,
        Worn_Silver = 24,
        Worn_Blue_Silver = 25,
        Worn_Shadow_Silver = 26,
        Worn_Red = 46,
        Worn_Golden_Red = 47,
        Worn_Dark_Red = 48,
        Worn_Dark_Green = 58,
        Worn_Green = 59,
        Worn_Sea_Wash = 60,
        Worn_Dark_Blue = 85,
        Worn_Blue = 86,
        Worn_Light_Blue = 87,
        Worn_Honey_Beige = 113,
        Worn_Brown = 114,
        Worn_Dark_Brown = 115,
        Worn_Straw_Beige = 116,
        Worn_Off_White = 121,
        Worn_Yellow = 123,
        Worn_Light_Orange = 124,
        Worn_Taxi_Yellow = 126,
        Worn_Orange = 130,
        Worn_White = 132,
        Worn_Olive_Army_Green = 133,

        /* METALS */
        Brushed_Steel = 117,
        Brushed_Black_Steel = 118,
        Brushed_Aluminum = 119,
        Pure_Gold = 158,
        Brushed_Gold = 159,
        Secret_Gold = 160,

        /* CHROME */
        Chrome = 120,
    }

    public struct VehicleColor
    {
        /// <summary>
        /// The primary color paint index 
        /// </summary>
        public EPaint PrimaryColor { get; set; }

        /// <summary>
        /// The secondary color paint index 
        /// </summary>
        public EPaint SecondaryColor { get; set; }



        /// <summary>
        /// Gets the primary color name
        /// </summary>
        public string PrimaryColorName
        {
            get { return GetColorName(PrimaryColor); }
        }
        /// <summary>
        /// Gets the secondary color name
        /// </summary>
        public string SecondaryColorName
        {
            get { return GetColorName(SecondaryColor); }
        }



        /// <summary>
        /// Gets the color name
        /// </summary>
        /// <param name="paint">Color to get the name from</param>
        /// <returns></returns>
        public string GetColorName(EPaint paint)
        {
            String name = Enum.GetName(typeof(EPaint), paint);
            return name.Replace("_", " ");
        }
    }
}
