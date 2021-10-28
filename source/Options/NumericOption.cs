using Reactor.Extensions;
using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace TownOfUs.Options {
    public class NumericOption : Option<double> {
        private NumberOption Option;

        public override OptionBehaviour Behaviour {
            get {
                return Option;
            }
        }

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

        public override OptionBehaviour Create() {
            NumberOption prefab = UnityObject.FindObjectOfType<NumberOption>();
            Option = UnityObject.Instantiate(prefab, prefab.transform.parent).DontDestroy();

            Option.TitleText.text = Description;
            Option.ValidRange = new FloatRange((float)Minimum, (float)Maximum);
            Option.Increment = 10.0f;
            Update();

            return Option;
        }

        public override void Update() {
            if (Option == null) {
                return;
            }
            Option.Value = Option.oldValue = (float)Value;
            Option.ValueText.text = GetDisplay();
        }
    }
}
