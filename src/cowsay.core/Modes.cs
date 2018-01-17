using System;
using System.Collections.Generic;

namespace cowsay.core {
    public enum Modes {
        Default,
        Borg,
        Dead,
        Greedy,
        Paranoid,
        Stoned,
        Youthful
    }

    public static class ModeSettings {
        private static readonly Dictionary<Enum, ModeSetting> Settings = new Dictionary<Enum, ModeSetting> {
            {Modes.Default, new ModeSetting("oo"," ")},
            {Modes.Borg, new ModeSetting("=="," ")},
            {Modes.Dead, new ModeSetting("XX","U")},
            {Modes.Greedy, new ModeSetting("$$"," ")},
            {Modes.Paranoid, new ModeSetting("@@"," ")},
            {Modes.Stoned, new ModeSetting("**","U")},
            {Modes.Youthful, new ModeSetting(".."," ")}
        };

        public static ModeSetting FindMode(Modes mode) {
            return Settings[mode];
        }
    }

    public class ModeSetting {
        private readonly string _eyes;
        private readonly string _tongue;
        
        public ModeSetting(string eyes, string tongue) {
            _eyes = eyes;
            _tongue = tongue;
        }

        public string Eyes => _eyes;
        public string Tongue => _tongue;
    }
}