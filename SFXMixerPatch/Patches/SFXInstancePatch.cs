using System;
using System.Reflection;
using CessilCellsCeaChells.CeaChore;
using HarmonyLib;
using Zorro.Core;

[assembly: RequiresMethod(typeof(SFX_Instance), "Awake", typeof(void))]

namespace SFXMixerPatch.Patches;

[HarmonyPatch(typeof(SFX_Instance))]
public class SFXInstancePatch {
    [HarmonyPatch("Awake")]
    [HarmonyPrefix]
    private static void FixMixer(SFX_Instance __instance)
    {
        __instance.settings.mixerGroup = SingletonAsset<MixerHolder>.Instance.sfxMixer;
    }
}