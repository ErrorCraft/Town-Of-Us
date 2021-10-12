using UnityEngine;

namespace TownOfUs.Options {
    public class PercentageOption : NumericOption {
        public PercentageOption(string description, Color colour, double value) : base(description, colour, value, 0.0d, 100.0d) {}

        public override string GetDisplay() {
            return $"{Value:0}%";
        }
    }
}
