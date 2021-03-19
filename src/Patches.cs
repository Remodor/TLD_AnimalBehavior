using Harmony;
using UnityEngine;
using MelonLoader;


namespace AnimalBehavior
{
    using Settings = AB_Settings;
    using StunBehavior = AnimalBehavior_Settings.StunBehavior;
    using TwHoldingGround = AnimalBehavior_Settings.TwHoldingGround;
    //* Timberwolves holding ground behavior when player aims.
    [HarmonyPatch(typeof(BaseAi), "IsPlayerFacingAi", new System.Type[] { })]
    internal class BaseAi_IsPlayerFacingAi
    {
        internal static void Postfix(BaseAi __instance, ref bool __result)
        {
            if (__result && __instance.IsTimberwolf() && Settings.Get().tw_holding_ground_behavior == TwHoldingGround.DirectAimRandom)
            {
                __result = Implementation.TwRandomShouldFlee(__instance);
            }
        }
    }

    [HarmonyPatch(typeof(BaseAi), "IsPlayerFacingAi", new System.Type[] { typeof(Vector3), typeof(float) })]
    internal class BaseAi_IsPlayerFacingAi2
    {
        internal static void Prefix(BaseAi __instance, Vector3 aiToTarget, ref float dotProductThreshold)
        {
            if (__instance.IsTimberwolf() &&
            (Settings.Get().tw_holding_ground_behavior == TwHoldingGround.DirectAim ||
            Settings.Get().tw_holding_ground_behavior == TwHoldingGround.DirectAimRandom))
            {
                dotProductThreshold = Settings.Get().tw_holding_ground_aim_accuracy;
            }
        }
    }
    //* Stalking wolves behavior when player aims.
    [HarmonyPatch(typeof(BaseAi), "ProcessStalking")]
    internal class BaseAi_ProcessStalking
    {
        internal static void Prefix()
        {
            //!delete 
            MelonLoader.MelonLogger.Log("process stalking");

            BaseAi_UseFixedStalkingSpeed.processStalking = true;
        }
        internal static void Postfix()
        {
            BaseAi_UseFixedStalkingSpeed.processStalking = false;
        }
    }
    [HarmonyPatch(typeof(BaseAi), "UseFixedStalkingSpeed")]
    internal class BaseAi_UseFixedStalkingSpeed
    {
        internal static bool processStalking = false;
        internal static void Postfix(BaseAi __instance, ref bool __result)
        {
            if (!processStalking || !__instance.m_AiWolf)
            {
                return;
            }
            processStalking = false;
            switch (Settings.Get().wolf_stalking_behavior)
            {
                case AnimalBehavior_Settings.WolfStalkingBehavior.Random:
                    bool skipAttack = !Implementation.WolfRandomShouldAttack(__instance);
                    __result = skipAttack;
                    return;
                case AnimalBehavior_Settings.WolfStalkingBehavior.Nothing:
                    __result = true;
                    return;
                case AnimalBehavior_Settings.WolfStalkingBehavior.Vanilla:
                    return;
            }

        }
    }
    //* Custom bleed out modifier
    [HarmonyPatch(typeof(BodyDamage), "GetBleedOutMinutes")]
    internal class LocalizedDamage_GetBleedOutMinutes
    {
        internal static void Postfix(ref float __result)
        {
            //!delete 
            MelonLoader.MelonLogger.Log("Before bleedtime: {0}", __result);

            __result *= Settings.Get().bleed_out_multiplier;
            //!delete 
            MelonLoader.MelonLogger.Log("After bleedtime: {0}", __result);
        }
    }
    //* Custom animal values.
    [HarmonyPatch(typeof(BaseAi), "DoCustomModeModifiers")]
    internal class BaseAi_DoCustomModeModifiers
    {
        internal static void Postfix(BaseAi __instance)
        {
            switch (__instance.m_AiSubType)
            {
                case AiSubType.Wolf:
                    if (__instance.IsTimberwolf())
                    {
                        Implementation.ApplyTimberwolfSettings(__instance);
                    }
                    else
                    {
                        Implementation.ApplyWolfSettings(__instance);
                    }
                    break;
                case AiSubType.Stag:
                    Implementation.ApplyDeerSettings(__instance);
                    break;
                case AiSubType.Moose:
                    Implementation.ApplyMooseSettings(__instance);
                    break;
                case AiSubType.Rabbit:
                    Implementation.ApplyRabbitSettings(__instance);
                    break;
                case AiSubType.Bear:
                    Implementation.ApplyBearSettings(__instance);
                    break;
            }                        //!delete 
            MelonLoader.MelonLogger.Log("DisplayName: {0}", __instance.m_DisplayName);
            MelonLoader.MelonLogger.Log("minflee: {0}, m_SmellRange: {1}", __instance.m_MinimumFleeTime, __instance.m_SmellRange);
            MelonLoader.MelonLogger.Log("m_DetectionRange: {0}, m_HearFootstepsRange: {1}", __instance.m_DetectionRange, __instance.m_HearFootstepsRange);
            MelonLoader.MelonLogger.Log("m_DetectionRangeWhileFeeding: {0}, m_HearFootstepsRangeWhileFeeding: {1}", __instance.m_DetectionRangeWhileFeeding, __instance.m_HearFootstepsRangeWhileFeeding);
        }
    }
    //!delete 
    // [HarmonyPatch(typeof(BaseAi), "EnterFlee")]
    // internal class BaseAi_SetFleeReason
    // {
    //     internal static void Prefix(BaseAi __instance)
    //     {
    //         //!delete 
    //         MelonLoader.MelonLogger.Log("Prefix fleereason: {0}", __instance.m_FleeReason);
    //     }
    //     internal static void Postfix(BaseAi __instance)
    //     {
    //         //!delete 
    //         MelonLoader.MelonLogger.Log("Post fleereason: {0}", __instance.m_FleeReason);
    //     }

    // }
    //* Rabbit stun behavior.
    [HarmonyPatch(typeof(BaseAi), "Stun")]
    internal class BaseAi_Stun
    {
        internal static bool Prefix(BaseAi __instance)
        {
            if (__instance.m_AiSubType == AiSubType.Rabbit &&
            Settings.Get().rabbit_stun_behavior != StunBehavior.Vanilla)
            {
                bool kill = Utils.RollChance(Settings.Get().rabbit_kill_on_hit_chance);
                //!delete 
                MelonLoader.MelonLogger.Log("Kill: {0}, with%: {1}", kill, Settings.Get().rabbit_kill_on_hit_chance);
                if (kill)
                {
                    __instance.SetAiMode(AiMode.Dead);
                    return false;
                }
                if (Settings.Get().rabbit_stun_behavior == StunBehavior.AllRandom)
                {
                    float min = Settings.Get().rabbit_minimum_stun_duration;
                    float max = Settings.Get().rabbit_stun_duration;
                    float random_dur = UnityEngine.Random.Range(min, max);
                    __instance.m_StunSeconds = random_dur;
                    //!delete 
                    MelonLoader.MelonLogger.Log("RandomDur: {0}, Between: {1}, and: {2}", random_dur, min, max);
                }


            }
            return true;
        }
    }
}
