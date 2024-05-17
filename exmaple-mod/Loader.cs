using BalsaAddons;
using BalsaCore;
using UnityEngine;
using System;
using System.Diagnostics;
using System.IO;


namespace exmaple_mod
{
    [BalsaAddon]
    public class Loader : MonoBehaviour
    {
        private static bool loaded = false;
        public static GameObject go;
        private static MonoBehaviour mod;
        [BalsaAddonInit(invokeTime = AddonInvokeTime.OnLoaded)]
        public static void BalsaInit()
        {
            //depending on where you put this code ot will load at different times
            if (!loaded)
            {
                loaded = true;
                go = new GameObject();
                
            }
            mod = go.AddComponent<exmaple_mod>();
        }

        [BalsaAddonInit(invokeTime = AddonInvokeTime.MainMenu)]
        public static void BalsaInitMainMenu()
        {
        }

        [BalsaAddonFinalize(invokeTime = AddonInvokeTime.MainMenu)]
        public static void BalsaFinalizeMainMenu()
        {
        }

        [BalsaAddonInit(invokeTime = AddonInvokeTime.Flight)]
        public static void BalsaInitFlight()
        {
        }

        [BalsaAddonFinalize(invokeTime = AddonInvokeTime.Flight)]
        public static void BalsaFinalizeFlight()
        {

        }
        //Game exit
        [BalsaAddonFinalize]
        public static void BalsaFinalize()
        {
        }
    }
}
