using System.Reflection;
using ModSettings;

namespace AnimalBehavior
{
    internal class AnimalBehavior_Settings : JsonModSettings
    {

        //* ----Global----
        [Section("Global")]
        [Name("Bleed Out Modifier")]
        [Description("The bleed out time is very dependend what the player uses, on which animal and where it is being hit. This modifier will be multiplied to the final bleedout time for arrows, bullets and flare gun shells.\n(Vanilla = 1)")]
        [Slider(0f, 10f, 101)]
        public float bleed_out_multiplier = 1f;

        public enum StalkingBehavior
        {
            Vanilla,
            Nothing,
            Random
        }
        //todo applies to timberwolves?
        [Name("Wolf Stalking Behavior When Aiming")]
        [Description("The stalking behavior from wolves when the player aims at them.\n(Vanilla = Always start attacking, Nothing = Will not react to the player aiming, Random: Configurable")]
        [Choice("Vanilla", "Nothing", "Random")]
        public StalkingBehavior wolf_stalking_behavior = StalkingBehavior.Vanilla;
        [Name("Attack Probability")]
        [Description("The probability for an attack everytime it is checked in percentage.\n(0 = Never, 100 = Always, Default = 30")]
        [Slider(0f, 100f, 101)]
        public float wolf_stalking_attack_chance = 20f;
        [Name("Attack Probability Interval")]
        [Description("The duration between each probability check in seconds. The first one is when you begin to aim.\n(Default = 2s)")]
        [Slider(0f, 10f, 101)]
        public float wolf_stalking_attack_interval = 2f;


        //* ----Wolf----
        [Section("Wolf")]
        [Name("Enable")]
        [Description("Apply custom values to wolves.\nNote: also affects wolves' detection of rabbits and deer.\n(Vanilla = false, all values as of build 1.93")]
        public bool wolf_enabled = false;

        [Name("Smell Range")]
        [Description("How far it can smell the player while carrying meat.\n(Vanilla = 100)")]
        [Slider(0f, 300f, 301)]
        public float wolf_smell_range = 100f;

        [Name("Detection Range")]
        [Description("How far it can see.\n(Vanilla = 75)")]
        [Slider(0f, 300f, 301)]
        public float wolf_detection_range = 75f;

        [Name("Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 300f, 301)]
        public float wolf_hear_range = 60f;

        [Name("Detection Range While Feeding")]
        [Description("How far it can see while it is feeding.\n(Vanilla = 20)")]
        [Slider(0f, 300f, 301)]
        public float wolf_detection_range_while_feeding = 20f;
        [Name("Hear Range While Feeding")]
        [Description("How far it can hear the player walk while it is feeding.\n(Vanilla = 25)")]
        [Slider(0f, 300f, 301)]
        public float wolf_hear_range_while_feeding = 25f;

        [Name("Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 61)]
        public float wolf_flee_duration = 8f;

        //* ----Timberwolf----
        [Section("Timberwolf")]
        [Name("Enable")]
        [Description("Apply custom values to timberwolves.\nNote: also affects timberwolves' detection of rabbits and deer.\n(Vanilla = false, all values as of build 1.93")]
        public bool timberwolf_enabled = false;

        [Name("Smell Range")]
        [Description("How far it can smell the player while carrying meat.\n(Vanilla = 120)")]
        [Slider(0f, 300f, 301)]
        public float timberwolf_smell_range = 120f;

        [Name("Detection Range")]
        [Description("How far it can see.\n(Vanilla = 90)")]
        [Slider(0f, 300f, 301)]
        public float timberwolf_detection_range = 90f;

        [Name("Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 120)")]
        [Slider(0f, 300f, 301)]
        public float timberwolf_hear_range = 120f;

        [Name("Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 10)")]
        [Slider(0f, 60f, 61)]
        public float timberwolf_flee_duration = 10f;

        //* ----Deer----
        [Section("Deer")]

        [Name("Enable")]
        [Description("Apply custom values to deers.\n(Vanilla = false, all values as of build 1.93")]
        public bool deer_enabled = false;

        [Name("Detection Range")]
        [Description("How far it can see.\n(Vanilla = 40)")]
        [Slider(0f, 300f, 301)]
        public float deer_detection_range = 40f;

        [Name("Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 300f, 301)]
        public float deer_hear_range = 60f;

        [Name("Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 61)]
        public float deer_flee_duration = 8f;

        //* ----Moose----
        [Section("Moose")]

        [Name("Enable")]
        [Description("Apply custom values to Moose.\n(Vanilla = false, all values as of build 1.93")]
        public bool moose_enabled = false;

        [Name("Smell Range")]
        [Description("How far it can smell the player while carrying meat. It is up to you if that makes sense.\n(Vanilla = 0)")]
        [Slider(0f, 300f, 301)]
        public float moose_smell_range = 0f;

        [Name("Detection Range")]
        [Description("How far it can see.\n(Vanilla = 50)")]
        [Slider(0f, 300f, 301)]
        public float moose_detection_range = 50f;

        [Name("Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 300f, 301)]
        public float moose_hear_range = 60f;

        [Name("Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 61)]
        public float moose_flee_duration = 8f;

        //* ----Rabbit----
        [Section("Rabbit")]

        [Name("Enable")]
        [Description("Apply custom values to rabbits.\n(Vanilla = false, all values as of build 1.93")]
        public bool rabbit_enabled = false;

        [Name("Detection Range")]
        [Description("How far it can see.\n(Vanilla = 12)")]
        [Slider(0f, 300f, 301)]
        public float rabbit_detection_range = 12f;

        [Name("Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 7)")]
        [Slider(0f, 300f, 301)]
        public float rabbit_hear_range = 7f;

        [Name("Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 4)")]
        [Slider(0f, 60f, 61)]
        public float rabbit_flee_duration = 4f;
        [Name("Stun Duration")]
        [Description("The stun duration in seconds when hit with a stone.\n(Vanilla = 4)")]
        [Slider(0f, 30f, 61)]
        public float rabbit_stun_duration = 4;

        //* ----Bear----
        [Section("Bear")]

        [Name("Enable")]
        [Description("Apply custom values to bears.\n(Vanilla = false, all values as of build 1.93")]
        public bool bear_enabled = false;

        [Name("Smell Range")]
        [Description("How far it can smell the player while carrying meat.\n(Vanilla = 150)")]
        [Slider(0f, 300f, 301)]
        public float bear_smell_range = 150f;

        [Name("Detection Range")]
        [Description("How far it can see.\n(Vanilla = 60)")]
        [Slider(0f, 300f, 301)]
        public float bear_detection_range = 60f;

        [Name("Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 300f, 301)]
        public float bear_hear_range = 60f;

        [Name("Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 61)]
        public float bear_flee_duration = 8f;

        protected void SetWolfStalkingBehaviorRandom(StalkingBehavior new_stalking_behavior)
        {
            bool visible = new_stalking_behavior == StalkingBehavior.Random ? true : false;
            this.SetFieldVisible(GetType().GetField("wolf_stalking_attack_chance"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_stalking_attack_interval"), visible);
        }
        protected void SetWolfVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("wolf_smell_range"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_hear_range"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_hear_range_while_feeding"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_detection_range"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_detection_range_while_feeding"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_flee_duration"), visible);
        }
        protected void SetTimberwolfVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("timberwolf_smell_range"), visible);
            this.SetFieldVisible(GetType().GetField("timberwolf_hear_range"), visible);
            this.SetFieldVisible(GetType().GetField("timberwolf_detection_range"), visible);
            this.SetFieldVisible(GetType().GetField("timberwolf_flee_duration"), visible);
        }
        protected void SetDeerVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("deer_hear_range"), visible);
            this.SetFieldVisible(GetType().GetField("deer_detection_range"), visible);
            this.SetFieldVisible(GetType().GetField("deer_flee_duration"), visible);
        }
        protected void SetMooseVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("moose_smell_range"), visible);
            this.SetFieldVisible(GetType().GetField("moose_hear_range"), visible);
            this.SetFieldVisible(GetType().GetField("moose_detection_range"), visible);
            this.SetFieldVisible(GetType().GetField("moose_flee_duration"), visible);
        }
        protected void SetRabbitVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("rabbit_hear_range"), visible);
            this.SetFieldVisible(GetType().GetField("rabbit_detection_range"), visible);
            this.SetFieldVisible(GetType().GetField("rabbit_flee_duration"), visible);
            this.SetFieldVisible(GetType().GetField("rabbit_stun_duration"), visible);
        }
        protected void SetBearVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("bear_smell_range"), visible);
            this.SetFieldVisible(GetType().GetField("bear_hear_range"), visible);
            this.SetFieldVisible(GetType().GetField("bear_detection_range"), visible);
            this.SetFieldVisible(GetType().GetField("bear_flee_duration"), visible);
        }
        internal void UpdateVisibility()
        {
            SetWolfVisibility(wolf_enabled);
            SetDeerVisibility(deer_enabled);
            SetMooseVisibility(moose_enabled);
            SetRabbitVisibility(rabbit_enabled);
            SetBearVisibility(bear_enabled);
            SetWolfStalkingBehaviorRandom(wolf_stalking_behavior);
        }
        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            base.OnChange(field, oldValue, newValue);
            if (field.Name == "wolf_enabled") SetWolfVisibility((bool)newValue);
            else if (field.Name == "deer_enabled") SetDeerVisibility((bool)newValue);
            else if (field.Name == "moose_enabled") SetMooseVisibility((bool)newValue);
            else if (field.Name == "rabbit_enabled") SetRabbitVisibility((bool)newValue);
            else if (field.Name == "bear_enabled") SetBearVisibility((bool)newValue);
            else if (field.Name == "wolf_stalking_behavior") SetWolfStalkingBehaviorRandom((StalkingBehavior)newValue);
        }
    }

    internal static class AB_Settings
    {
        private static AnimalBehavior_Settings settings = new AnimalBehavior_Settings();

        public static void OnLoad()
        {
            settings.AddToModSettings("Animal Behavior");
            settings.UpdateVisibility();
        }
        public static AnimalBehavior_Settings Get()
        {
            return settings;
        }
    }
}
