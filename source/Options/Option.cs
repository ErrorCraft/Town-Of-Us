using UnityEngine;

namespace TownOfUs.Options {
    public abstract class Option<T> {
        protected T Value { get; set; }
        private readonly string Description;
        private readonly Color? Colour;

        protected Option(string description, Color? colour, T value) {
            Description = description;
            Colour = colour;
            SetValue(value);
        }

        public virtual void SetValue(T value) {
            Value = value;
        }

        public abstract string GetDisplay();
    }
}
