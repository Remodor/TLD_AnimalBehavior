using MelonLoader;
using UnityEngine;

namespace AnimalBehavior
{
    public class Implementation : MelonMod
    {
        private static float currentStalkingIntervalTime = 0;
        internal static bool WolfRandomShouldAttack(BaseAi instance)
        {
            if (instance.m_ForceChasePlayerSpeed) { return true; } // If it has been successfull once.
            if (GameManager.GetPlayerManagerComponent().PlayerIsZooming())
            {
                currentStalkingIntervalTime += Time.deltaTime;

                if (currentStalkingIntervalTime >= AB_Settings.Get().wolf_stalking_attack_interval)
                {
                    //!delete 
                    MelonLoader.MelonLogger.Log("time: {0}, interval time: {1}", currentStalkingIntervalTime, AB_Settings.Get().wolf_stalking_attack_interval);

                    bool roll = Utils.RollChance(AB_Settings.Get().wolf_stalking_attack_chance);
                    currentStalkingIntervalTime = 0;
                    //!delete 
                    MelonLoader.MelonLogger.Log("rollresult: {0}, rollchance: {1}", roll, AB_Settings.Get().wolf_stalking_attack_chance);

                    return roll;
                }
            }
            else
            {
                // Reset the clock when the player is not aiming.
                currentStalkingIntervalTime = AB_Settings.Get().wolf_stalking_attack_interval;
            }
            return false;
        }
        private static float currentHoldGroundIntervalTime = 0;
        private static bool TwShouldFlee = false;
        internal static bool TwRandomShouldFlee(BaseAi instance)
        {
            if (!GameManager.GetPlayerManagerComponent().PlayerIsZooming()) // Reset when not zooming.
            {
                //!delete 
                MelonLoader.MelonLogger.Log("reset");

                currentHoldGroundIntervalTime = Time.time - AB_Settings.Get().tw_holding_ground_flee_interval;
                TwShouldFlee = false;
                return false;
            }
            if (TwShouldFlee) // Keep fleeing until reset.
            {
                return true;
            }

            if (currentHoldGroundIntervalTime <= Time.time - AB_Settings.Get().tw_holding_ground_flee_interval)
            {
                //!delete 
                MelonLoader.MelonLogger.Log("time: {0}, interval time: {1}", currentHoldGroundIntervalTime, AB_Settings.Get().tw_holding_ground_flee_interval);

                bool roll = TwShouldFlee = Utils.RollChance(AB_Settings.Get().tw_holding_ground_flee_chance);
                currentHoldGroundIntervalTime = Time.time;
                //!delete 
                MelonLoader.MelonLogger.Log("rollresult: {0}, rollchance: {1}", roll, AB_Settings.Get().tw_holding_ground_flee_chance);

                return roll;
            }
            return false;
        }

        internal static void ApplyWolfSettings(BaseAi instance)
        {
            var settings = AB_Settings.Get();
            if (settings.wolf_enabled)
            {
                instance.m_SmellRange = settings.wolf_smell_range;
                instance.m_DetectionRange = settings.wolf_detection_range;
                instance.m_HearFootstepsRange = settings.wolf_hear_range;
                instance.m_DetectionRangeWhileFeeding = settings.wolf_detection_range_while_feeding;
                instance.m_HearFootstepsRangeWhileFeeding = settings.wolf_hear_range_while_feeding;
                instance.m_MinimumFleeTime = settings.wolf_flee_duration;
            }
        }
        internal static void ApplyTimberwolfSettings(BaseAi instance)
        {
            var settings = AB_Settings.Get();
            if (settings.timberwolf_enabled)
            {
                instance.m_SmellRange = settings.timberwolf_smell_range;
                instance.m_DetectionRange = settings.timberwolf_detection_range;
                instance.m_HearFootstepsRange = settings.timberwolf_hear_range;
                instance.m_DetectionRangeWhileFeeding = settings.timberwolf_detection_range_while_feeding;
                instance.m_HearFootstepsRangeWhileFeeding = settings.timberwolf_hear_range_while_feeding;
                instance.m_MinimumFleeTime = settings.timberwolf_flee_duration;
            }
        }
        internal static void ApplyDeerSettings(BaseAi instance)
        {
            var settings = AB_Settings.Get();
            if (settings.deer_enabled)
            {
                instance.m_DetectionRange = settings.deer_detection_range;
                instance.m_HearFootstepsRange = settings.deer_hear_range;
                instance.m_MinimumFleeTime = settings.deer_flee_duration;
            }
        }
        internal static void ApplyMooseSettings(BaseAi instance)
        {
            var settings = AB_Settings.Get();
            if (settings.moose_enabled)
            {
                instance.m_SmellRange = settings.moose_smell_range;
                instance.m_DetectionRange = settings.moose_detection_range;
                instance.m_HearFootstepsRange = settings.moose_hear_range;
                instance.m_MinimumFleeTime = settings.moose_flee_duration;
            }
        }
        internal static void ApplyRabbitSettings(BaseAi instance)
        {
            var settings = AB_Settings.Get();
            if (settings.rabbit_enabled)
            {
                instance.m_DetectionRange = settings.rabbit_detection_range;
                instance.m_HearFootstepsRange = settings.rabbit_hear_range;
                instance.m_MinimumFleeTime = settings.rabbit_flee_duration;
                instance.m_StunSeconds = settings.rabbit_stun_duration;
            }
        }
        internal static void ApplyBearSettings(BaseAi instance)
        {
            var settings = AB_Settings.Get();
            if (settings.bear_enabled)
            {
                instance.m_SmellRange = settings.bear_smell_range;
                instance.m_DetectionRange = settings.bear_detection_range;
                instance.m_HearFootstepsRange = settings.bear_hear_range;
                instance.m_MinimumFleeTime = settings.bear_flee_duration;
            }
        }
        internal static void ApplyCustomMode(BaseAi instance)
        {
            float customModifier = GameManager.GetExperienceModeManagerComponent().GetCustomWildlifeDetectionModifier();
            instance.m_DetectionRange *= customModifier;
            instance.m_HearFootstepsRange *= customModifier;
            instance.m_DetectionRangeWhileFeeding *= customModifier;
            instance.m_HearFootstepsRangeWhileFeeding *= customModifier;
        }
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] version {Info.Version} loaded!");
            AB_Settings.OnLoad();
        }

    }
}
