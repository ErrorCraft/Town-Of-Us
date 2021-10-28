using System.Collections.Generic;
using UnityEngine;

namespace TownOfUs.Options {
    public abstract class Option {
        private static readonly List<Option> ALL_OPTIONS = new List<Option>();
        public static readonly PercentageOption MAYOR_CHANCE = new PercentageOption("Mayor", new Color(0.44f, 0.31f, 0.66f, 1.0f), 0.0d);

        public abstract OptionBehaviour Behaviour { get; }
        
        public static List<Option> GetAllOptions() {
            return ALL_OPTIONS;
        }

        protected static void AddOption(Option option) {
            ALL_OPTIONS.Add(option);
        }

        public abstract OptionBehaviour Create();
        public abstract void Update();
    }

    public abstract class Option<T> : Option {
        protected T Value { get; set; }
        protected string Description { get; }
        private readonly Color? Colour;

        protected Option(string description, Color? colour, T value) {
            Description = description;
            Colour = colour;
            SetValue(value);
            AddOption(this);
        }

        public virtual void SetValue(T value) {
            Value = value;
        }

        public abstract string GetDisplay();
    }
}
