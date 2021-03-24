using Harmony;
using UnityEngine;
using MelonLoader;


namespace AnimalBehavior
{
    using Settings = AB_Settings;
    using StunBehavior = AnimalBehavior_Settings.StunBehavior;
    using WolfHoldingGround = AnimalBehavior_Settings.WolfHoldingGround;
    using WolfHoldingGroundWolves = AnimalBehavior_Settings.WolfHoldingGroundWolves;

    //* Wolves holding ground behavior when player aims.
    [HarmonyPatch(typeof(BaseAi), "IsPlayerFacingAi", new System.Type[] { typeof(Vector3), typeof(float) })]
    internal class BaseAi_IsPlayerFacingAi2
    {
        internal static void Prefix(BaseAi __instance, Vector3 aiToTarget, ref float dotProductThreshold)
        {
            if (__instance.m_AiWolf &&
            (Settings.Get().wolf_holding_ground_behavior == WolfHoldingGround.DirectAim ||
            Settings.Get().wolf_holding_ground_behavior == WolfHoldingGround.DirectAimRandom))
            {
                if (__instance.IsTimberwolf() && Settings.Get().wolf_holding_ground_wolves == WolfHoldingGroundWolves.Wolves) // Timberwolves but setting is only wolves.
                {
                    return;
                }
                if (!__instance.IsTimberwolf() && Settings.Get().wolf_holding_ground_wolves == WolfHoldingGroundWolves.Timberwolves) // Wolves but setting is only timberwolves.
                {
                    return;
                }
                else
                {
                    dotProductThreshold = Settings.Get().wolf_holding_ground_aim_accuracy / 100f;
                }
            }


        }
        internal static void Postfix(BaseAi __instance, ref bool __result)
        {
            if (__result && __instance.m_AiWolf && Settings.Get().wolf_holding_ground_behavior == WolfHoldingGround.DirectAimRandom)
            {
                if (__instance.IsTimberwolf() && Settings.Get().wolf_holding_ground_wolves == WolfHoldingGroundWolves.Wolves) // Timberwolves but setting is only wolves.
                {
                    return;
                }
                if (!__instance.IsTimberwolf() && Settings.Get().wolf_holding_ground_wolves == WolfHoldingGroundWolves.Timberwolves) // Wolves but setting is only timberwolves.
                {
                    return;
                }
                __result = Implementation.WolfRandomShouldFlee(__instance);
            }
        }
    }
    [HarmonyPatch(typeof(BaseAi), "ProcessHoldGround")]
    internal class BaseAi_IsPlayerAThreat
    {
        internal static void Postfix()
        {
            if (!GameManager.GetPlayerManagerComponent().PlayerIsZooming()) // Reset when not zooming.
            {
                Implementation.ResetShouldFlee();
            }
        }
    }
    [HarmonyPatch(typeof(BaseAi), "AttackOrFleeAfterNearMissGunshot")]
    internal class BaseAi_AttackOrFleeAfterNearMissGunshot
    {
        internal static void Postfix(BaseAi __instance, ref bool __result)
        {
            if (__instance.IsTimberwolf() && __instance.GetAiMode() == AiMode.HoldGround)
            {
                __result = true;
            }
        }
    }
    //* Stalking wolves behavior when player aims.
    [HarmonyPatch(typeof(BaseAi), "ProcessStalking")]
    internal class BaseAi_ProcessStalking
    {
        internal static void Prefix()
        {
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
    [HarmonyPatch(typeof(BaseAi), "ApplyDamage", new System.Type[] { typeof(float), typeof(float), typeof(DamageSource), typeof(string) })]
    internal class LocalizedDamage_GetBleedOutMinutes
    {
        internal static void Prefix(float damage, ref float bleedOutMintues, DamageSource damageSource, string collider)
        {
            if (collider == "StruggleTap") // Wolf struggle.
            {
                bleedOutMintues *= Settings.Get().bleed_out_modifier_wolf_struggle;
            }
            else
            {
                bleedOutMintues *= Settings.Get().bleed_out_modifier;
            }
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
            }
        }
    }
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
                if (kill)
                {
                    __instance.SetAiMode(AiMode.Dead);
                    return false;
                }
                if (Settings.Get().rabbit_stun_behavior == StunBehavior.AllRandom)
                {
                    float min = Settings.Get().rabbit_minimum_stun_duration;
                    float max = Settings.Get().rabbit_maximum_stun_duration;
                    float random_dur = UnityEngine.Random.Range(min, max);
                    __instance.m_StunSeconds = random_dur;

                }


            }
            return true;
        }
    }
}
