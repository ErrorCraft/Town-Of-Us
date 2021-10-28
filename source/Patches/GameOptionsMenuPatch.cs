using HarmonyLib;
using Reactor;
using System.Collections.Generic;
using System.Linq;
using TownOfUs.Options;
using UnhollowerBaseLib;
using UnityEngine;

namespace TownOfUs.Patches {
    public static class GameOptionsMenuPatch {
        [HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Start))]
        public static class Start {
            public static void Postfix(GameOptionsMenu __instance) {
                List<OptionBehaviour> customOptions = CreateOptions(__instance);
                float y = __instance.GetComponentsInChildren<OptionBehaviour>()
                    .Max(option => option.transform.localPosition.y);
                float x = __instance.Children[1].transform.localPosition.x;
                float z = __instance.Children[1].transform.localPosition.z;
                int i = 0;

                foreach (var option in customOptions) {
                    float newY = y - i++ * 0.5f;
                    option.transform.localPosition = new Vector3(x, newY, z);
                }

                __instance.Children = new Il2CppReferenceArray<OptionBehaviour>(customOptions.ToArray());
            }

        }

        private static List<OptionBehaviour> CreateOptions(GameOptionsMenu menu) {
            List<OptionBehaviour> options = new List<OptionBehaviour>();

            foreach (OptionBehaviour defaultOption in menu.Children) {
                options.Add(defaultOption);
            }

            foreach (Option option in Option.GetAllOptions()) {
                options.Add(option.Create());
            }

            return options;
        }
    }
}
