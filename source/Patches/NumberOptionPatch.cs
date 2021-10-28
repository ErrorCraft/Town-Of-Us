using TownOfUs.Options;
using HarmonyLib;
using System.Linq;
using Reactor;

namespace TownOfUs.Patches {
    public static class NumberOptionPatch {
        [HarmonyPatch(typeof(NumberOption), nameof(NumberOption.OnEnable))]
        public static class OnEnable {
            public static bool Prefix(NumberOption __instance) {
                Option customOption = Option.GetAllOptions().FirstOrDefault(option => option.Behaviour.name == __instance.name);
                if (customOption == null) {
                    return true;
                }

                customOption.Update();
                return false;
            }
        }
    }
}
