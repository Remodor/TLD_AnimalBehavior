﻿using System.Reflection;
using ModSettings;
using UnityEngine;

namespace AnimalBehavior
{
    internal class AnimalBehavior_Settings : JsonModSettings
    {

        //* ----Special----
        public enum WolfStalkingBehavior
        {
            Vanilla,
            Nothing,
            Random
        }
        [Section("Special Behavior")]
        [Name("Wolf Stalking Behavior When Aiming")]
        [Description("The stalking behavior from wolves when the player aims at them.\n(Vanilla = Always start attacking, Nothing = Will not react to the player aiming, Random: Configurable)")]
        [Choice("Vanilla", "Nothing", "Random")]
        public WolfStalkingBehavior wolf_stalking_behavior = WolfStalkingBehavior.Vanilla;
        [Name("        Attack Probability")]
        [Description("The probability for an attack every time it is checked.\n(0% = Never, 100% = Always, Default = 40%)")]
        public int wolf_stalking_attack_chance = 40;
        [Name("        Attack Probability Interval")]
        [Description("The duration between each probability check in seconds. The first one is when you begin to aim.\n(Default = 2s)")]
        [Slider(0f, 10f, 101, NumberFormat = "{0:F1}s")]
        public float wolf_stalking_attack_interval = 2f;

        public enum WolfHoldingGround
        {
            Vanilla,
            DirectAim,
            DirectAimRandom
        }

        [Name("Wolf Holding Ground Behavior When Aiming")]
        [Description("The behavior from threatening wolves when the player is near a fire and aims at them.\nVanilla = They flee when the player aims broadly in their direction,\nDirectAim = They flee when directly aimed at them,\nDirectAimRandom = In addition to DirectAim, it is also random.")]
        [Choice("Vanilla", "DirectAim", "DirectAimRandom")]
        public WolfHoldingGround wolf_holding_ground_behavior = WolfHoldingGround.Vanilla;
        public enum WolfHoldingGroundWolves
        {
            Wolves,
            Timberwolves,
            Both
        }
        [Name("        Choose Wolves")]
        [Description("Choose wolves to apply the changes. When applied to timberwolves they will also flee when you fire a gun and they are holding ground.\n(Both = Vanilla, Wolves, Timberwolves)")]
        [Choice("Wolves", "Timberwolves", "Both")]
        public WolfHoldingGroundWolves wolf_holding_ground_wolves = WolfHoldingGroundWolves.Both;

        [Name("        Direct Aim Accuracy")]
        [Description("How close you have to aim you crosshair on a wolf to trigger fleeing.\n(0 = Aim anywhere, 99 = Directly on it, Default = 94)")]
        [Slider(0, 99, 100)]
        public int wolf_holding_ground_aim_accuracy = 94;

        [Name("        Flee Probability")]
        [Description("The probability for fleeing every time it is checked.\n(0% = Never, 100% = Always, Default = 20%)")]
        public int wolf_holding_ground_flee_chance = 20;
        [Name("        Flee Probability Interval")]
        [Description("The duration between each probability check in seconds.\n(Default = 1s)")]
        [Slider(0f, 10f, 101, NumberFormat = "{0:F1}s")]
        public float wolf_holding_ground_flee_interval = 1f;

        public enum StunBehavior
        {
            Vanilla,
            CanKill,
            AllRandom
        }
        [Name("Rabbit Stun")]
        [Description("The rabbit behavior when hit by a stone. The stun duration can be changed in the rabbits section (except when you set it to random).\nVanilla = Gets stunned for the duration,\nCanKill = The stone can kill the rabbit,\nAllRandom: Both duration and kill probability are random.")]
        [Choice("Vanilla", "CanKill", "AllRandom")]
        public StunBehavior rabbit_stun_behavior = StunBehavior.Vanilla;
        [Name("        Kill On Hit Probability")]
        [Description("The probability to instantly kill the rabbit.\n(Vanilla = 0%, default = 12%)")]
        public int rabbit_kill_on_hit_chance = 12;
        [Name("        Maximum Stun Duration")]
        [Description("The maximum stun duration when set to random. This overrides the stun duration in the rabbits section.\n(Vanilla = 4, default = 6)")]
        [Slider(0f, 30f, 61, NumberFormat = "{0:F1}s")]
        public float rabbit_maximum_stun_duration = 6f;
        [Name("        Minimum Stun Duration")]
        [Description("The minimum stun duration when set to random. This overrides the stun duration in the rabbits section.\n(Vanilla = 4, default = 1)")]
        [Slider(0f, 30f, 61, NumberFormat = "{0:F1}s")]
        public float rabbit_minimum_stun_duration = 1f;

        //* ----Bleeding----
        [Section("Animal Bleeding")]
        [Name("Bleed Out Modifier")]
        [Description("The bleed out time is very dependent on what the player uses, on which animal and where it is being hit. This modifier will be multiplied to the final bleed out duration for arrows, bullets and flare gun shells (Not wolf struggle!).\nA common bleed out duration is 60 INGAME minutes, higher modifier means longer.\n(Vanilla = 1)")]
        [Slider(0.05f, 3f, 60, NumberFormat = "{0:F2}")]
        public float bleed_out_modifier = 1f;

        [Name("Stackable Bleeding")]
        [Description("If you want stackable bleeding. If an animal is hit multiple times bleeding will get accumulated. Also applies to wolf struggle. Wolf struggle multiplier should get set accordingly.\nE.g. Two hits with: Duration1 = 60, Duration2 = 90\n-> Final duration = 36\n(Vanilla = false [Only the shorter duration counts])")]
        public bool stackable_bleed_out = false;

        [Name("Wolf Struggle")]
        [Description("This modifier will be multiplied to the final bleed out duration for wolf struggle.\nThe default is 12 INGAME minutes for a knife. If used together with stackable bleeding, this should be set pretty high as you hit the wolf around 10 times, e.g. 20.\n(Vanilla = 1)")]
        [Slider(0.2f, 40f, 200)]
        public float bleed_out_modifier_wolf_struggle = 1f;

        [Name("Blood Drop Lifetime")]
        [Description("Specify the lifetime of blood drops in hours. The oldest one will also disappear when the maximum amount of decals is reached. This is mostly the case if you don't increase the number of decals.\n(Vanilla = 1h)")]
        [Slider(0, 8, 161, NumberFormat = "{0:F2}h")]
        public float blood_drop_lifetime = 1;
        [Name("        Lifetime - Blizzard")]
        [Description("Specify the blood drop lifetime in hours if created during blizzards.\n(Vanilla = 0.005h)")]
        [Slider(0, 1, 201, NumberFormat = "{0:F3}h")]
        public float blood_drop_lifetime_blizzard = 0.005f;
        [Name("        Lifetime - Heavy Snow")]
        [Description("Specify the blood drop lifetime in hours if created during heavy snow.\n(Vanilla = 0.2h)")]
        [Slider(0, 2, 201, NumberFormat = "{0:F2}h")]
        public float blood_drop_lifetime_heavy_snow = 0.2f;
        [Name("        Lifetime - High Winds")]
        [Description("Specify the blood drop lifetime in hours if created during high winds.\n(Vanilla = 0.3h)")]
        [Slider(0, 2, 201, NumberFormat = "{0:F2}h")]
        public float blood_drop_lifetime_high_winds = 0.3f;

        [Name("    Lifetime - Randomness")]
        [Description("If you like to add randomness to every blood drop.\n(Default = false)")]
        public bool blood_drop_random_lifetime = false;
        [Name("        Min Lifetime")]
        [Description("The minimum lifetime of blood drops in hours. A random value is chosen between this and the 'Blood Drop Lifetime' -value.")]
        [Slider(0, 8, 161, NumberFormat = "{0:F2}h")]
        public float blood_drop_min_lifetime = 1;
        [Name("        Min Lifetime - Blizzard")]
        [Description("The minimum lifetime of blood drops created during blizzards. A random value is chosen between this and the 'Lifetime - Blizzard' -value.")]
        [Slider(0, 1, 201, NumberFormat = "{0:F3}h")]
        public float blood_drop_min_lifetime_blizzard = 0.005f;
        [Name("        Min Lifetime - Heavy Snow")]
        [Description("The minimum lifetime of blood drops created during heavy snow. A random value is chosen between this and the 'Lifetime - Heavy Snow' -value.")]
        [Slider(0, 2, 201, NumberFormat = "{0:F2}h")]
        public float blood_drop_min_lifetime_heavy_snow = 0.2f;
        [Name("        Min Lifetime - High Winds")]
        [Description("The minimum lifetime of blood drops created during high winds. A random value is chosen between this and the 'Lifetime - High Winds' -value.")]
        [Slider(0, 2, 201, NumberFormat = "{0:F2}h")]
        public float blood_drop_min_lifetime_high_winds = 0.3f;


        [Name("Maximum Decals (Reload Required)")]
        [Description("Specify the maximum amount of decals. These are: Player blood, animal blood, ice cracks, bullet decals. The oldest one will disappear when the maximum amount of decals is reached.\nKeep in mind, they need to be computed and may affect FPS! However, I had no problems even with 1000.\n(Vanilla = 250)")]
        [Slider(5, 1000, 200)]
        public int maximum_decals = 250;
        [Name("Try Restoring Blood When Loading")]
        [Description("Changing scenes, e.g. when entering a house, completely resets all decals. This tries to restore previous decals. Only works if you enter a location and exit back to the previous location. Works pretty good to go inside, recover and continue the chase!")]
        public bool restore_blood = false;

        //* ----Animal Stats----
        [Section("Animal Stats (Applied After Reload)")]
        //* ----Wolf----
        [Name("Wolf")]
        [Description("Apply custom values to wolves.\nNote: also affects wolves' detection of rabbits and deer.\nThe values are also modified with the two values for \"Wildlife Detection Range\"/ \"Wildlife Smell Range\" which can be seen when creating a custom survival game. Medium represents the set vanilla value. Only smell range will get changed with a different difficulty. Detection range is constant except when set otherwise.\n(Vanilla = false, all values as of build 1.93)")]
        public bool wolf_enabled = false;

        [Name("        Smell Range")]
        [Description("How far it can smell the player while carrying meat.\n(Vanilla = 100)")]
        [Slider(0f, 250f, 251)]
        public int wolf_smell_range = 100;
        [Name("        Begin Charging Range")]
        [Description("How far it will start charging at you when stalking.\n(Vanilla = 15)")]
        [Slider(0f, 250f, 251)]
        public int wolf_charging_range = 15;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 75)")]
        [Slider(0f, 250f, 251)]
        public int wolf_detection_range = 75;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public int wolf_hear_range = 60;

        [Name("        Detection Range While Feeding")]
        [Description("How far it can see while it is feeding.\n(Vanilla = 20)")]
        [Slider(0f, 250f, 251)]
        public int wolf_detection_range_while_feeding = 20;
        [Name("        Hear Range While Feeding")]
        [Description("How far it can hear the player walk while it is feeding.\n(Vanilla = 25)")]
        [Slider(0f, 250f, 251)]
        public int wolf_hear_range_while_feeding = 25;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 121, NumberFormat = "{0:F1}s")]
        public float wolf_flee_duration = 8f;

        //* ----Timberwolf----
        [Name("Timberwolf")]
        [Description("Apply custom values to timberwolves.\nNote: also affects timberwolves' detection of rabbits and deer.\nThe values are also modified with the two values for \"Wildlife Detection Range\"/ \"Wildlife Smell Range\" which can be seen when creating a custom survival game. Medium represents the set vanilla value. Only smell range will get changed with a different difficulty. Detection range is constant except when set otherwise.\n(Vanilla = false, all values as of build 1.93)")]
        public bool timberwolf_enabled = false;

        [Name("        Smell Range")]
        [Description("How far it can smell the player while carrying meat. This is also changed by the chosen difficulty.\n(Vanilla = 120)")]
        [Slider(0f, 250f, 251)]
        public int timberwolf_smell_range = 120;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 90)")]
        [Slider(0f, 250f, 251)]
        public int timberwolf_detection_range = 90;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 120)")]
        [Slider(0f, 250f, 251)]
        public int timberwolf_hear_range = 120;

        [Name("        Detection Range While Feeding")]
        [Description("How far it can see while it is feeding.\n(Vanilla = 35)")]
        [Slider(0f, 250f, 251)]
        public int timberwolf_detection_range_while_feeding = 35;

        [Name("        Hear Range While Feeding")]
        [Description("How far it can hear the player walk while it is feeding.\n(Vanilla = 35)")]
        [Slider(0f, 250f, 251)]
        public int timberwolf_hear_range_while_feeding = 35;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 10)")]
        [Slider(0f, 60f, 121, NumberFormat = "{0:F1}s")]
        public float timberwolf_flee_duration = 10f;

        //* ----Deer----
        [Name("Deer")]
        [Description("Apply custom values to deers.\nThe values are also modified with the two values for \"Wildlife Detection Range\"/ \"Wildlife Smell Range\" which can be seen when creating a custom survival game. Medium represents the set vanilla value. Only smell range will get changed with a different difficulty. Detection range is constant except when set otherwise.\n(Vanilla = false, all values as of build 1.93)")]
        public bool deer_enabled = false;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 40)")]
        [Slider(0f, 250f, 251)]
        public int deer_detection_range = 40;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public int deer_hear_range = 60;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 121, NumberFormat = "{0:F1}s")]
        public float deer_flee_duration = 8f;

        //* ----Moose----
        [Name("Moose")]
        [Description("Apply custom values to Moose.\nThe values are also modified with the two values for \"Wildlife Detection Range\"/ \"Wildlife Smell Range\" which can be seen when creating a custom survival game. Medium represents the set vanilla value. Only smell range will get changed with a different difficulty. Detection range is constant except when set otherwise.\n(Vanilla = false, all values as of build 1.93)")]
        public bool moose_enabled = false;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 50)")]
        [Slider(0f, 250f, 251)]
        public int moose_detection_range = 50;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public int moose_hear_range = 60;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 121, NumberFormat = "{0:F1}s")]
        public float moose_flee_duration = 8f;

        //* ----Rabbit----
        [Name("Rabbit")]
        [Description("Apply custom values to rabbits.\nThe values are also modified with the two values for \"Wildlife Detection Range\"/ \"Wildlife Smell Range\" which can be seen when creating a custom survival game. Medium represents the set vanilla value. Only smell range will get changed with a different difficulty. Detection range is constant except when set otherwise.\n(Vanilla = false, all values as of build 1.93)")]
        public bool rabbit_enabled = false;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 12)")]
        [Slider(0f, 250f, 251)]
        public int rabbit_detection_range = 12;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 7)")]
        [Slider(0f, 250f, 251)]
        public int rabbit_hear_range = 7;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 4)")]
        [Slider(0f, 60f, 121, NumberFormat = "{0:F1}s")]
        public float rabbit_flee_duration = 4f;
        [Name("        Stun Duration")]
        [Description("The stun duration in seconds when hit with a stone.\n(Vanilla = 4)")]
        [Slider(0f, 30f, 61, NumberFormat = "{0:F1}s")]
        public float rabbit_stun_duration = 4f;

        //* ----Bear----
        [Name("Bear")]
        [Description("Apply custom values to bears.\nThe values are also modified with the two values for \"Wildlife Detection Range\"/ \"Wildlife Smell Range\" which can be seen when creating a custom survival game. Medium represents the set vanilla value. Only smell range will get changed with a different difficulty. Detection range is constant except when set otherwise.\n(Vanilla = false, all values as of build 1.93)")]
        public bool bear_enabled = false;

        [Name("        Smell Range")]
        [Description("How far it can smell the player while carrying meat. This is also changed by the chosen difficulty.\n(Vanilla = 150)")]
        [Slider(0f, 250f, 251)]
        public int bear_smell_range = 150;

        [Name("        Begin Charging Range")]
        [Description("How far it will start charging at you when stalking.\n(Vanilla = 25)")]
        [Slider(0f, 250f, 251)]
        public int bear_charging_range = 25;

        [Name("        Detection Range")]
        [Description("How far it can see.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public int bear_detection_range = 60;

        [Name("        Hear Range")]
        [Description("How far it can hear the player walk.\n(Vanilla = 60)")]
        [Slider(0f, 250f, 251)]
        public int bear_hear_range = 60;

        [Name("        Flee Duration")]
        [Description("The minimum flee duration in seconds.\n(Vanilla = 8)")]
        [Slider(0f, 60f, 121, NumberFormat = "{0:F1}s")]
        public float bear_flee_duration = 8f;

        [Name("        Ignore Flares")]
        [Description("Currently flares are very strong. This setting will let bears ignore held flares.\n(Vanilla = false)")]
        public bool bear_ignore_flare = false;

        [Name("        Ignore Marine Flares")]
        [Description("This setting will let bears ignore held marine flares.\n(Vanilla = false)")]
        public bool bear_ignore_marine_flare = false;

        protected void SetWolfStalkingBehaviorVisibility(WolfStalkingBehavior new_stalking_behavior)
        {
            bool visible = new_stalking_behavior == WolfStalkingBehavior.Random ? true : false;
            this.SetFieldVisible(GetType().GetField("wolf_stalking_attack_chance"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_stalking_attack_interval"), visible);
        }
        protected void SetWolfHoldingGroundBehaviorVisibility(WolfHoldingGround new_holding_ground_behavior)
        {
            bool directAim = new_holding_ground_behavior == WolfHoldingGround.DirectAim || new_holding_ground_behavior == WolfHoldingGround.DirectAimRandom;
            this.SetFieldVisible(GetType().GetField("wolf_holding_ground_aim_accuracy"), directAim);
            this.SetFieldVisible(GetType().GetField("wolf_holding_ground_wolves"), directAim);

            bool directAimRandom = new_holding_ground_behavior == WolfHoldingGround.DirectAimRandom;
            this.SetFieldVisible(GetType().GetField("wolf_holding_ground_flee_chance"), directAimRandom);
            this.SetFieldVisible(GetType().GetField("wolf_holding_ground_flee_interval"), directAimRandom);
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
        protected void SetRandomBloodVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("blood_drop_min_lifetime"), visible);
            this.SetFieldVisible(GetType().GetField("blood_drop_min_lifetime_blizzard"), visible);
            this.SetFieldVisible(GetType().GetField("blood_drop_min_lifetime_heavy_snow"), visible);
            this.SetFieldVisible(GetType().GetField("blood_drop_min_lifetime_high_winds"), visible);
        }
        protected void SetWolfVisibility(bool visible)
        {
            this.SetFieldVisible(GetType().GetField("wolf_smell_range"), visible);
            this.SetFieldVisible(GetType().GetField("wolf_charging_range"), visible);
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
            this.SetFieldVisible(GetType().GetField("bear_charging_range"), visible);
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
            SetWolfHoldingGroundBehaviorVisibility(wolf_holding_ground_behavior);
            SetRabbitStunBehaviorVisibility(rabbit_stun_behavior);
            SetRandomBloodVisibility(blood_drop_random_lifetime);
        }
        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            rabbit_minimum_stun_duration = Mathf.Min(rabbit_minimum_stun_duration, rabbit_maximum_stun_duration);
            blood_drop_min_lifetime = Mathf.Min(blood_drop_min_lifetime, blood_drop_lifetime);
            blood_drop_min_lifetime_blizzard = Mathf.Min(blood_drop_min_lifetime_blizzard, blood_drop_lifetime_blizzard);
            blood_drop_min_lifetime_heavy_snow = Mathf.Min(blood_drop_min_lifetime_heavy_snow, blood_drop_lifetime_heavy_snow);
            blood_drop_min_lifetime_high_winds = Mathf.Min(blood_drop_min_lifetime_high_winds, blood_drop_lifetime_high_winds);
            base.RefreshGUI();
            base.OnChange(field, oldValue, newValue);
            if (field.Name == "wolf_enabled") SetWolfVisibility((bool)newValue);
            else if (field.Name == "timberwolf_enabled") SetTimberwolfVisibility((bool)newValue);
            else if (field.Name == "deer_enabled") SetDeerVisibility((bool)newValue);
            else if (field.Name == "moose_enabled") SetMooseVisibility((bool)newValue);
            else if (field.Name == "rabbit_enabled") SetRabbitVisibility((bool)newValue);
            else if (field.Name == "bear_enabled") SetBearVisibility((bool)newValue);
            else if (field.Name == "wolf_stalking_behavior") SetWolfStalkingBehaviorVisibility((WolfStalkingBehavior)newValue);
            else if (field.Name == "wolf_holding_ground_behavior") SetWolfHoldingGroundBehaviorVisibility((WolfHoldingGround)newValue);
            else if (field.Name == "rabbit_stun_behavior") SetRabbitStunBehaviorVisibility((StunBehavior)newValue);
            else if (field.Name == "blood_drop_random_lifetime") SetRandomBloodVisibility((bool)newValue);
        }
        protected override void OnConfirm()
        {
            rabbit_minimum_stun_duration = Mathf.Min(rabbit_minimum_stun_duration, rabbit_maximum_stun_duration);
            blood_drop_min_lifetime = Mathf.Min(blood_drop_min_lifetime, blood_drop_lifetime);
            blood_drop_min_lifetime_blizzard = Mathf.Min(blood_drop_min_lifetime_blizzard, blood_drop_lifetime_blizzard);
            blood_drop_min_lifetime_heavy_snow = Mathf.Min(blood_drop_min_lifetime_heavy_snow, blood_drop_lifetime_heavy_snow);
            blood_drop_min_lifetime_high_winds = Mathf.Min(blood_drop_min_lifetime_high_winds, blood_drop_lifetime_high_winds);
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
