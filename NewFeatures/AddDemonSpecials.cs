﻿using BlueprintCore.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using WOTR_PATH_OF_RAGE.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using WOTR_PATH_OF_RAGE;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Localization;
using UnityEngine;
using static Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.RuleSystem;
using Kingmaker.Enums;
using Kingmaker.ElementsSystem;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using WOTR_PATH_OF_RAGE.New_Rules;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using WOTR_PATH_OF_RAGE.MechanicsChanges;
using WOTR_PATH_OF_RAGE.NewFeatures;
using BlueprintCore.Utils;

namespace WOTR_PATH_OF_RAGE.NewFeatures
{
    class DemonSpecials
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyPriority(Priority.First)]
            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;

                Main.Log("Patching Demonic Smash");
                DemonBlast.AddDemonBlast();
                SpecialFeatures.AddDemonSpecialFeatures();
                SpecialResources.AddDemonSpecialResources();
                DemonSmashProjectile.AddDemonSmashProjectile();
                DemonSmash.AddDemonSmash();
                DemonSoul.AddDemonSoul();
                DemonPolymorph.AddDemonPolymorph();
                DemonRip.AddDemonRip();
                DemonTear.AddDemonTear();
                AddDemonSpecialsToSelection();
            }
           
            public static void AddDemonSpecialsToSelection()
            {
                var demonSpecialSelection = BlueprintTool.Get<BlueprintFeatureSelection>("1df9edd3e5f4485793e57a40e1d567f2");

                var demonSmashFeature = BlueprintTool.Get<BlueprintFeature>("23d7996386d64d67a83e79f5bc5fedaf");
                var demonSoulFeature = BlueprintTool.Get<BlueprintFeature>("30dcbf939783418c881d15f623d53bf9");
                var demonPolyFeature = BlueprintTool.Get<BlueprintFeature>("bbd26df513044c01a56b5fad024a86bc");
                var demonRipFeature = BlueprintTool.Get<BlueprintFeature>("6f4041fd6be843a8ae935fe1307aba08"); 
                var demonTearFeature = BlueprintTool.Get<BlueprintFeature>("b044212d111b4e26865344982084e5c7");

                demonSpecialSelection.SetFeatures(demonSmashFeature, demonSoulFeature, demonPolyFeature, demonRipFeature, demonTearFeature);

                Main.Log("Demonic Specials Added To Selection");

            }
        }
    }

}
