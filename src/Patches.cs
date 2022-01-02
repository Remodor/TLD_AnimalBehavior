using HarmonyLib;
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
    //* Bears ignore flares.
    [HarmonyPatch(typeof(BaseAi), "MaybeHoldGroundForRedFlareForAttack")]
    internal class BaseAi_MaybeHoldGroundForRedFlareForAttack
    {
        internal static bool Prefix(BaseAi __instance, ref bool __result)
        {
            if (__instance.m_AiSubType == AiSubType.Bear && Settings.Get().bear_ignore_flare)
            {
                __result = false;
                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(BaseAi), "MaybeHoldGroundForBlueFlareForAttack")]
    internal class BaseAi_MaybeHoldGroundForBlueFlareForAttack
    {
        internal static bool Prefix(BaseAi __instance, ref bool __result)
        {
            if (__instance.m_AiSubType == AiSubType.Bear && Settings.Get().bear_ignore_marine_flare)
            {
                __result = false;
                return false;
            }
            return true;
        }
    }
    //* Custom bleed out modifier. Stackable bleed out.
    [HarmonyPatch(typeof(BaseAi), "ApplyDamage", new System.Type[] { typeof(float), typeof(float), typeof(DamageSource), typeof(string) })]
    internal class BaseAi_ApplyDamage
    {
        internal static void Prefix(BaseAi __instance, float damage, ref float bleedOutMintues, DamageSource damageSource, string collider)
        {
            if (collider == "StruggleTap") // Wolf struggle.
            {
                bleedOutMintues *= Settings.Get().bleed_out_modifier_wolf_struggle;
            }
            else
            {
                bleedOutMintues *= Settings.Get().bleed_out_modifier;
            }
            if (Settings.Get().stackable_bleed_out
                && __instance.IsBleedingOut() && !Utils.IsZero(bleedOutMintues))
            {
                float bleedProgress = __instance.m_ElapsedBleedingOutMinutes / __instance.m_DeathAfterBleeingOutMinutes;
                if (bleedProgress >= 1) { return; }
                float sum = bleedOutMintues + __instance.m_DeathAfterBleeingOutMinutes;
                float product = bleedOutMintues * __instance.m_DeathAfterBleeingOutMinutes;
                float combinedBleedOut = product / sum;
                float newBleedProgress = combinedBleedOut * bleedProgress;
                __instance.m_DeathAfterBleeingOutMinutes = combinedBleedOut;
                __instance.m_ElapsedBleedingOutMinutes = newBleedProgress;
            }
        }
    }
    //* Blood decals lifetime.
    [HarmonyPatch(typeof(DynamicDecalsManager), "ComputeDecalProjectorLifeTime")]
    internal class DynamicDecalsManager_ComputeDecalProjectorLifeTime
    {
        internal static void Prefix(DynamicDecalsManager __instance, DecalProjectorType projectorType)
        {
            if (projectorType == DecalProjectorType.AnimalBlood)
            {
                __instance.m_NPCDecalsLifeTimeHours = Settings.Get().blood_drop_lifetime;
                __instance.m_NPCDecalsLifeTimeInBlizzardHours = Settings.Get().blood_drop_lifetime_blizzard;
                __instance.m_NPCDecalsLifeTimeInHeavySnowHours = Settings.Get().blood_drop_lifetime_heavy_snow;
                __instance.m_NPCDecalsLifeTimeInHighWindsHours = Settings.Get().blood_drop_lifetime_high_winds;
            }
        }
    }
    //* Maximum decals.
    [HarmonyPatch(typeof(DynamicDecalsManager), "InstantiateDecalProjectorInstances")]
    internal class DynamicDecalsManager_InstantiateDecalProjectorInstances
    {
        internal static void Postfix(DynamicDecalsManager __instance)
        {
            __instance.m_MaxNonPlacedDynamicDecals = Settings.Get().maximum_decals;
            int missingDecals = __instance.m_MaxNonPlacedDynamicDecals + __instance.m_MaxPlacedDynamicDecals + __instance.m_PoolSizeIncrement - __instance.m_Pool_DecalProjectorInstances.Count;
            if (missingDecals > 0)
            {
                MelonLogger.Log("Current decals: {0}, create missing decals: {1}.", __instance.m_Pool_DecalProjectorInstances.Count, missingDecals);
                __instance.InstantiateDecalProjectorInstances(missingDecals);
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
