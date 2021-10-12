using System;
using UnityEngine;

namespace TownOfUs.Options {
    public class NumericOption : Option<double> {
        protected double Minimum { get; }
        protected double Maximum { get; }

        public NumericOption(string description, Color colour, double value, double minimum, double maximum) : base(description, colour, value) {
            Minimum = minimum;
            Maximum = maximum;
        }

        public override void SetValue(double value) {
            Value = Math.Clamp(value, Minimum, Maximum);
        }

        public override string GetDisplay() {
            return $"{Value:0.0#}";
        }
    }
}
