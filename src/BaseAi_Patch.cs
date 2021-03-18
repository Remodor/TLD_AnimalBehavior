using Harmony;
using UnityEngine;
using MelonLoader;


namespace AnimalBehavior
{
    //* USED by timberwolves
    [HarmonyPatch(typeof(BaseAi), "IsPlayerAThreat")]
    internal class BaseAi_IsPlayerAThread
    {
        internal static void Postfix(ref bool __result)
        {
            if (__result)
            {
                MelonLoader.MelonLogger.Log("Is thread");
                //todo apply random if isplayerfacingai.
            }
            //__result = false;
        }
    }
    //todo don't know
    [HarmonyPatch(typeof(BaseAi), "IsPlayerFacingAi", new System.Type[] { })]
    internal class BaseAi_IsPlayerFacingAi
    {
        internal static void Postfix(ref bool __result)
        {
            if (__result)
            {
                MelonLoader.MelonLogger.Log("IsPlayerFacingAi");

            }
            //__result = false;
        }
    }
    // [HarmonyPatch(typeof(BaseAi), "IsPlayerFacingAi", new System.Type[] { typeof(Vector3), typeof(float) })]
    // internal class BaseAi_IsPlayerFacingAi2
    // {
    //     internal static void Postfix(ref bool __result)
    //     {
    //         if (__result)
    //         {
    //             MelonLoader.MelonLogger.Log("IsPlayerFacingAi2");

    //         }
    //         //__result = false;
    //     }
    // }
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
            switch (AB_Settings.Get().wolf_stalking_behavior)
            {
                case AnimalBehavior_Settings.StalkingBehavior.Random:
                    bool skipAttack = !Implementation.StalkRandomShouldAttack(__instance);
                    __result = skipAttack;
                    return;
                case AnimalBehavior_Settings.StalkingBehavior.Nothing:
                    __result = true;
                    return;
                case AnimalBehavior_Settings.StalkingBehavior.Vanilla:
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

            __result *= AB_Settings.Get().bleed_out_multiplier;
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
            }
        }
    }
}
