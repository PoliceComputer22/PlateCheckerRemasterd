using PlateChecker;
using PlateCheckerRemastered;
using Rage;
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
    }
}
