using System.Reflection;
using ModSettings;
using UnityEngine;

namespace AnimalBehavior
{
    internal class AnimalBehavior_Settings : JsonModSettings
    {

        //* ----Special----
        [Section("Special Behavior")]
        [Name("Bleed Out Modifier")]
        [Description("The bleed out time is very dependend on what the player uses, on which animal and where it is being hit. This modifier will be multiplied to the final bleedout time for arrows, bullets and flare gun shells.\n(Vanilla = 1, A common bleed out duration is 60 ingame minutes)")]
        [Slider(0.1f, 10f, 100)]
        public float bleed_out_multiplier = 1f;

        public enum WolfStalkingBehavior
        {
            Vanilla,
            Nothing,
            Random
        }
        [Name("Wolf Stalking Behavior When Aiming")]
        [Description("The stalking behavior from wolves when the player aims at them.\n(Vanilla = Always start attacking, Nothing = Will not react to the player aiming, Random: Configurable)")]
        [Choice("Vanilla", "Nothing", "Random")]
        public WolfStalkingBehavior wolf_stalking_behavior = WolfStalkingBehavior.Vanilla;
        [Name("        Attack Probability")]
        [Description("The probability for an attack everytime it is checked.\n(0% = Never, 100% = Always, Default = 40%)")]
        [Slider(0f, 100f, 101)]
        public float wolf_stalking_attack_chance = 40f;
        [Name("        Attack Probability Interval")]
        [Description("The duration between each probability check in seconds. The first one is when you begin to aim.\n(Default = 2s)")]
        [Slider(0f, 10f, 101)]
        public float wolf_stalking_attack_interval = 2f;

        public enum TwHoldingGround
        {
            Vanilla,
            DirectAim,
            DirectAimRandom
        }

        [Name("Timberwolf Holding Ground Behavior When Aiming")]
        [Description("The behavior from threatening timberwolves when the player is near a fire and aims at them.\nVanilla = They flee when the player aims broadly in their direction,\nDirectAim = They flee when directly aimed at them,\nDirectAimRandom = In addition to DirectAim, it is also random.")]
        [Choice("Vanilla", "DirectAim", "DirectAimRandom")]
        public TwHoldingGround tw_holding_ground_behavior = TwHoldingGround.Vanilla;
        [Name("        Direct Aim Accuracy")]
        [Description("How close you have to aim you crosshair on a wolf.\n(0 = Aim anywhere, 1 = Directly on it, Default = 0.94)")]
        [Slider(0f, 99f, 100)]
        public float tw_holding_ground_aim_accuracy = 0.94f;

        [Name("        Flee Probability")]
        [Description("The probability for fleeing everytime it is checked.\n(0% = Never, 100% = Always, Default = 50%)")]
        [Slider(0f, 100f, 101)]
        public float tw_holding_ground_flee_chance = 50f;
        [Name("        Flee Probability Interval")]
        [Description("The duration between each probability check in seconds.\n(Default = 2s)")]
        [Slider(0f, 10f, 101)]
        public float tw_holding_ground_flee_interval = 2f;

        public enum StunBehavior
        {
            Vanilla,
            CanKill,
            AllRandom
        }
        [Name("Rabbit Stun")]
        [Description("The rabbit behavior when hit by a stone. The stun duration can be changed in the rabbits section (this is also the maximum duration when set to random).\nVanilla = Gets stunned for the duration,\nCanKill = The stone can kill the rabbit,\nAllRandom: Both duration and kill probability are random.")]
        [Choice("Vanilla", "CanKill", "AllRandom")]
        public StunBehavior rabbit_stun_behavior = StunBehavior.Vanilla;
        [Name("        Kill On Hit Probability")]
        [Description("The probability to instantly kill the rabbit.\n(Vanilla = 0%, default = 15%)")]
        [Slider(0f, 100f, 101)]
        public float rabbit_kill_on_hit_chance = 15f;
        [Name("        Minimum Stun Duration")]
        [Description("The minimum stun duration when set to random. It is bounded by the maximum duration (the stun duration in the rabbits section).\n(Vanilla = 4, default = 1)")]
        [Slider(0f, 30f, 61)]
        public float rabbit_minimum_stun_duration = 1f;

        //* ----Animal Stats----
        [Section("Animal Stats (Applied After Reload)")]
        //* ----Wolf----
        [Name("Wolf")]
        [Description("Apply custom values to wolves.\nNote: also affects wolves' detection of rabbits and deer.\n(Vanilla = false, all values as of build 1.93")]
        public bool wolf_enabled = false;

        [Name("        Smell Range")]
        [Description("How far it can smell the player while carrying meat.\n(Vanilla = 100)")]
        [Slider(0f, 250f, 251)]
        public float wolf_smell_range = 100f;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 75)")]
        [Slider(0f, 250f, 251)]
        public float wolf_detection_range = 75f;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public float wolf_hear_range = 60f;

        [Name("        Detection Range While Feeding")]
        [Description("How far it can see while it is feeding.\n(Vanilla = 20)")]
        [Slider(0f, 250f, 251)]
        public float wolf_detection_range_while_feeding = 20f;
        [Name("        Hear Range While Feeding")]
        [Description("How far it can hear the player walk while it is feeding.\n(Vanilla = 25)")]
        [Slider(0f, 250f, 251)]
        public float wolf_hear_range_while_feeding = 25f;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 61)]
        public float wolf_flee_duration = 8f;

        //* ----Timberwolf----
        [Name("Timberwolf")]
        [Description("Apply custom values to timberwolves.\nNote: also affects timberwolves' detection of rabbits and deer.\n(Vanilla = false, all values as of build 1.93")]
        public bool timberwolf_enabled = false;

        [Name("        Smell Range")]
        [Description("How far it can smell the player while carrying meat.\n(Vanilla = 120)")]
        [Slider(0f, 250f, 251)]
        public float timberwolf_smell_range = 120f;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 90)")]
        [Slider(0f, 250f, 251)]
        public float timberwolf_detection_range = 90f;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 120)")]
        [Slider(0f, 250f, 251)]
        public float timberwolf_hear_range = 120f;

        [Name("        Detection Range While Feeding")]
        [Description("How far it can see while it is feeding.\n(Vanilla = 35)")]
        [Slider(0f, 250f, 251)]
        public float timberwolf_detection_range_while_feeding = 35f;

        [Name("        Hear Range While Feeding")]
        [Description("How far it can hear the player walk while it is feeding.\n(Vanilla = 35)")]
        [Slider(0f, 250f, 251)]
        public float timberwolf_hear_range_while_feeding = 35f;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 10)")]
        [Slider(0f, 60f, 61)]
        public float timberwolf_flee_duration = 10f;

        //* ----Deer----
        [Name("Deer")]
        [Description("Apply custom values to deers.\n(Vanilla = false, all values as of build 1.93")]
        public bool deer_enabled = false;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 40)")]
        [Slider(0f, 250f, 251)]
        public float deer_detection_range = 40f;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public float deer_hear_range = 60f;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 61)]
        public float deer_flee_duration = 8f;

        //* ----Moose----
        [Name("Moose")]
        [Description("Apply custom values to Moose.\n(Vanilla = false, all values as of build 1.93")]
        public bool moose_enabled = false;

        [Name("        Smell Range")]
        [Description("How far it can smell the player while carrying meat. It is up to you if that makes sense.\n(Vanilla = 0)")]
        [Slider(0f, 250f, 251)]
        public float moose_smell_range = 0f;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 50)")]
        [Slider(0f, 250f, 251)]
        public float moose_detection_range = 50f;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public float moose_hear_range = 60f;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 61)]
        public float moose_flee_duration = 8f;

        //* ----Rabbit----
        [Name("Rabbit")]
        [Description("Apply custom values to rabbits.\n(Vanilla = false, all values as of build 1.93")]
        public bool rabbit_enabled = false;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 12)")]
        [Slider(0f, 250f, 251)]
        public float rabbit_detection_range = 12f;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 7)")]
        [Slider(0f, 250f, 251)]
        public float rabbit_hear_range = 7f;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 4)")]
        [Slider(0f, 60f, 61)]
        public float rabbit_flee_duration = 4f;
        [Name("        Stun Duration")]
        [Description("The stun duration in seconds when hit with a stone.\n(Vanilla = 4)")]
        [Slider(0f, 30f, 61)]
        public float rabbit_stun_duration = 4;

        //* ----Bear----
        [Name("Bear")]
        [Description("Apply custom values to bears.\n(Vanilla = false, all values as of build 1.93")]
        public bool bear_enabled = false;

        [Name("        Smell Range")]
        [Description("How far it can smell the player while carrying meat.\n(Vanilla = 150)")]
        [Slider(0f, 250f, 251)]
        public float bear_smell_range = 150f;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public float bear_detection_range = 60f;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public float bear_hear_range = 60f;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 61)]
        public float bear_flee_duration = 8f;
        //[Choice("Vanilla", "CanKill", "AllRandom")]

        protected void SetWolfStalkingBehaviorVisibility(WolfStalkingBehavior new_stalking_behavior)
        {
            bool visible = new_stalking_behavior == WolfStalkingBehavior.Random ? true : false;
            this.SetFieldVisible(GetType().GetField("wolf_stalking_attack_chance"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_stalking_attack_interval"), visible);
        }
        protected void SetTwHoldingGroundBehaviorVisibility(TwHoldingGround new_holding_ground_behavior)
        {
            bool directAim = new_holding_ground_behavior == TwHoldingGround.DirectAim || new_holding_ground_behavior == TwHoldingGround.DirectAimRandom;
            this.SetFieldVisible(GetType().GetField("tw_holding_ground_aim_accuracy"), directAim);

            bool directAimRandom = new_holding_ground_behavior == TwHoldingGround.DirectAimRandom;
            this.SetFieldVisible(GetType().GetField("tw_holding_ground_flee_chance"), directAimRandom);
            this.SetFieldVisible(GetType().GetField("tw_holding_ground_flee_interval"), directAimRandom);
        }
        protected void SetRabbitStunBehaviorVisibility(StunBehavior new_stun_behavior)
        {
            switch (new_stun_behavior)
            {
                case StunBehavior.Vanilla:
                    this.SetFieldVisible(GetType().GetField("rabbit_kill_on_hit_chance"), false);
                    this.SetFieldVisible(GetType().GetField("rabbit_minimum_stun_duration"), false);
                    break;
                case StunBehavior.CanKill:
                    this.SetFieldVisible(GetType().GetField("rabbit_kill_on_hit_chance"), true);
                    this.SetFieldVisible(GetType().GetField("rabbit_minimum_stun_duration"), false);
                    break;
                case StunBehavior.AllRandom:
                    this.SetFieldVisible(GetType().GetField("rabbit_kill_on_hit_chance"), true);
                    this.SetFieldVisible(GetType().GetField("rabbit_minimum_stun_duration"), true);
                    break;
            }

        }
        protected void SetWolfVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("wolf_smell_range"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_detection_range"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_hear_range"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_detection_range_while_feeding"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_hear_range_while_feeding"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_flee_duration"), visible);
        }
        protected void SetTimberwolfVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("timberwolf_smell_range"), visible);
            this.SetFieldVisible(GetType().GetField("timberwolf_detection_range"), visible);
            this.SetFieldVisible(GetType().GetField("timberwolf_hear_range"), visible);
            this.SetFieldVisible(GetType().GetField("timberwolf_detection_range_while_feeding"), visible);
            this.SetFieldVisible(GetType().GetField("timberwolf_hear_range_while_feeding"), visible);
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
            SetTimberwolfVisibility(timberwolf_enabled);
            SetDeerVisibility(deer_enabled);
            SetMooseVisibility(moose_enabled);
            SetRabbitVisibility(rabbit_enabled);
            SetBearVisibility(bear_enabled);
            SetWolfStalkingBehaviorVisibility(wolf_stalking_behavior);
            SetTwHoldingGroundBehaviorVisibility(tw_holding_ground_behavior);
            SetRabbitStunBehaviorVisibility(rabbit_stun_behavior);
        }
        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            rabbit_minimum_stun_duration = Mathf.Min(rabbit_minimum_stun_duration, rabbit_stun_duration);
            base.RefreshGUI();
            base.OnChange(field, oldValue, newValue);
            if (field.Name == "wolf_enabled") SetWolfVisibility((bool)newValue);
            else if (field.Name == "timberwolf_enabled") SetTimberwolfVisibility((bool)newValue);
            else if (field.Name == "deer_enabled") SetDeerVisibility((bool)newValue);
            else if (field.Name == "moose_enabled") SetMooseVisibility((bool)newValue);
            else if (field.Name == "rabbit_enabled") SetRabbitVisibility((bool)newValue);
            else if (field.Name == "bear_enabled") SetBearVisibility((bool)newValue);
            else if (field.Name == "wolf_stalking_behavior") SetWolfStalkingBehaviorVisibility((WolfStalkingBehavior)newValue);
            else if (field.Name == "tw_holding_ground_behavior") SetTwHoldingGroundBehaviorVisibility((TwHoldingGround)newValue);
            else if (field.Name == "rabbit_stun_behavior") SetRabbitStunBehaviorVisibility((StunBehavior)newValue);
        }
        protected override void OnConfirm()
        {
            rabbit_minimum_stun_duration = Mathf.Min(rabbit_minimum_stun_duration, rabbit_stun_duration);
            base.RefreshGUI();
            base.OnConfirm();
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
