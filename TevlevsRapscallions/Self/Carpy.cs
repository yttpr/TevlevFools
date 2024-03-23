// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Carpy
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class Carpy
  {
    public static Character Fish;
    public static Sprite fishySprite = ResourceLoader.LoadSprite("MungWhispererPassive");
    public static PerformEffectWearable fishingRod;
    public static PerformEffectWearable wormsCan;
    public static PerformEffectWithConsumeEffectWearable catfish;
    public static ExtraLootListEffect rodFish;
    public static ExtraLootListEffect canFish;
    public static ExtraLootListEffect catFish;
    private static bool fishSet = false;

    public static void Add()
    {
      Carpy.SetupFish();
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (Carpy).GetMethod("AddOtherStoredValue", ~BindingFlags.Default), (object) typeof (Carpy).GetMethod("AddStoredValue", ~BindingFlags.Default));
      FishWhisperPassive instance1 = ScriptableObject.CreateInstance<FishWhisperPassive>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "Fish Whisperer";
      ((BasePassiveAbilitySO) instance1).passiveIcon = Carpy.fishySprite;
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 89261;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "Iggle my Wiggle";
      ((BasePassiveAbilitySO) instance1)._characterDescription = "At the end of combat, catch fish based on the amount of Fish Whisperer. Fishy wishy slub dub.";
      ((BasePassiveAbilitySO) instance1).specialStoredValue = (UnitStoredValueNames) 93512;
      ExtraLootForEachPassiveAmountList instance2 = ScriptableObject.CreateInstance<ExtraLootForEachPassiveAmountList>();
      instance2._treasurePercentage = 1;
      instance2._nothingPercentage = 0;
      instance2._shopPercentage = 2;
      instance2._valueName = (UnitStoredValueNames) 93512;
      instance2._lootableItems = Carpy.rodFish._lootableItems;
      instance2._lockedLootableItems = Carpy.rodFish._lockedLootableItems;
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 31
      };
      CasterStoredValueChangeEffect instance3 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance3._minimumValue = 0;
      instance3._valueName = (UnitStoredValueNames) 93512;
      instance3._increase = true;
      Character character = new Character()
      {
        name = nameof (Carpy),
        healthColor = Pigments.Blue,
        entityID = (EntityIDs) 763895,
        levels = new CharacterRankedData[4],
        frontSprite = ResourceLoader.LoadSprite("CarpyFront"),
        backSprite = ResourceLoader.LoadSprite("Carpyback"),
        overworldSprite = ResourceLoader.LoadSprite("CarpyOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        lockedSprite = ResourceLoader.LoadSprite("CarpyMenu"),
        unlockedSprite = ResourceLoader.LoadSprite("CarpyMenu"),
        menuChar = true,
        usesBaseAbility = true,
        usesAllAbilities = false,
        appearsInShops = true,
        hurtSound = LoadedAssetsHandler.GetEnemy("Visage_Mother_EN").damageSound,
        deathSound = LoadedAssetsHandler.GetEnemy("Visage_Mother_EN").deathSound
      };
      character.dialogueSound = character.hurtSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance1
      };
      GenerateColorManaEffect instance4 = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
      instance4.mana = Pigments.Blue;
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("SkillCarpCry", 1);
      ability1.name = "Carp Cry";
      ability1.description = "Produce 1 blue pigment, heal this party member 2 health.\n40% chance to refresh this party member's abilities.";
      ability1.cost = new ManaColorSO[1]
      {
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Blue)
      };
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) instance4, 1, new IntentType?((IntentType) 60), Slots.Self);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?((IntentType) 20), Slots.Self);
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) Conditions.Chance(40));
      ability1.animationTarget = Slots.Self;
      ability1.visuals = LoadedAssetsHandler.GetEnemy("Mung_EN").abilities[0].ability.visuals;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("SkillCarpCry", 1);
      ability2.name = "Carp Weep";
      ability2.description = "Produce 1 blue pigment, heal this party member 2 health.\n50% chance to refresh this party member's abilities.";
      ability2.cost = new ManaColorSO[1]
      {
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Blue)
      };
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect((EffectSO) instance4, 1, new IntentType?((IntentType) 60), Slots.Self);
      ability2.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?((IntentType) 20), Slots.Self);
      ability2.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) Conditions.Chance(50));
      ability2.animationTarget = Slots.Self;
      ability2.visuals = LoadedAssetsHandler.GetEnemy("Mung_EN").abilities[0].ability.visuals;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("SkillCarpCry", 1);
      ability3.name = "Carp Tear";
      ability3.description = "Produce 1 blue pigment, heal this party member 2 health.\n60% chance to refresh this party member's abilities.";
      ability3.cost = new ManaColorSO[1]{ Pigments.Gray };
      ability3.effects = new Effect[3];
      ability3.effects[0] = new Effect((EffectSO) instance4, 1, new IntentType?((IntentType) 60), Slots.Self);
      ability3.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 3, new IntentType?((IntentType) 20), Slots.Self);
      ability3.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) Conditions.Chance(60));
      ability3.animationTarget = Slots.Self;
      ability3.visuals = LoadedAssetsHandler.GetEnemy("Mung_EN").abilities[0].ability.visuals;
      Ability ability4 = new Ability();
      ability4.sprite = ResourceLoader.LoadSprite("SkillCarpCry", 1);
      ability4.name = "Carp Depression";
      ability4.description = "Produce 1 blue pigment, heal this party member 2 health.\n70% chance to refresh this party member's abilities.";
      ability4.cost = new ManaColorSO[1]{ Pigments.Gray };
      ability4.effects = new Effect[3];
      ability4.effects[0] = new Effect((EffectSO) instance4, 1, new IntentType?((IntentType) 60), Slots.Self);
      ability4.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), Slots.Self);
      ability4.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) Conditions.Chance(70));
      ability4.animationTarget = Slots.Self;
      ability4.visuals = LoadedAssetsHandler.GetEnemy("Mung_EN").abilities[0].ability.visuals;
      PreviousEffectCondition instance5 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance5.wasSuccessful = false;
      CatchFishIfKillDamageEffect instance6 = ScriptableObject.CreateInstance<CatchFishIfKillDamageEffect>();
      instance6._valueName = (UnitStoredValueNames) 93512;
      instance6._indirect = true;
      CatchFishIfKillDamageEffect instance7 = ScriptableObject.CreateInstance<CatchFishIfKillDamageEffect>();
      instance7._valueName = (UnitStoredValueNames) 93512;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("SkillSalmonSkin", 1);
      ability5.name = "Salmon Skin";
      ability5.description = "Move left or Right 3 times. Deal 8 damage to the Opposing enemy.\nIf there is no opposing enemy, split this damage to the left and right indirectly.\nIf this move kills increase Fish Whisperer by 1.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability5.effects = new Effect[5];
            AnimationVisualsEffect yeah = EZEffects.GetVisuals<AnimationVisualsEffect>("Extra_Trout_A", true, Slots.Front);
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<SwapThreeTimesEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability5.effects[2] = new Effect((EffectSO) yeah, 1, new IntentType?((IntentType) 40), Slots.Self);
      ability5.effects[3] = new Effect((EffectSO) instance7, 8, new IntentType?((IntentType) 2), Slots.Front);
      ability5.effects[4] = new Effect((EffectSO) instance6, 4, new IntentType?((IntentType) 1), Slots.LeftRight, (EffectConditionSO) instance5);
      ability5.animationTarget = Slots.Front;
      ability5.visuals = null;
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("SkillSalmonSkin", 1);
      ability6.name = "Salmon Flesh";
      ability6.description = "Move left or Right 3 times. Deal 10 damage to the Opposing enemy.\nIf there is no opposing enemy, split this damage to the left and right indirectly.\nIf this move kills increase Fish Whisperer by 1.";
      ability6.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability6.effects = new Effect[5];
      ability6.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<SwapThreeTimesEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability6.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability6.effects[2] = new Effect(yeah, 1, new IntentType?((IntentType) 40), Slots.Self);
      ability6.effects[3] = new Effect((EffectSO) instance7, 10, new IntentType?((IntentType) 2), Slots.Front);
      ability6.effects[4] = new Effect((EffectSO) instance6, 5, new IntentType?((IntentType) 1), Slots.LeftRight, (EffectConditionSO) instance5);
      ability6.animationTarget = Slots.Front;
            ability6.visuals = null;
      Ability ability7 = new Ability();
      ability7.sprite = ResourceLoader.LoadSprite("SkillSalmonSkin", 1);
      ability7.name = "Salmon Guts";
      ability7.description = "Move left or Right 3 times. Deal 12 damage to the Opposing enemy.\nIf there is no opposing enemy, split this damage to the left and right indirectly.\nIf this move kills increase Fish Whisperer by 1.";
      ability7.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability7.effects = new Effect[5];
      ability7.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<SwapThreeTimesEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability7.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability7.effects[2] = new Effect(yeah, 1, new IntentType?((IntentType) 40), Slots.Self);
      ability7.effects[3] = new Effect((EffectSO) instance7, 12, new IntentType?((IntentType) 3), Slots.Front);
      ability7.effects[4] = new Effect((EffectSO) instance6, 6, new IntentType?((IntentType) 1), Slots.LeftRight, (EffectConditionSO) instance5);
      ability7.animationTarget = Slots.Front;
            ability7.visuals = null;
      Ability ability8 = new Ability();
      ability8.sprite = ResourceLoader.LoadSprite("SkillSalmonSkin", 1);
      ability8.name = "Salmon Bones";
      ability8.description = "Move left or Right 3 times. Deal 16 damage to the Opposing enemy.\nIf there is no opposing enemy, split this damage to the left and right indirectly.\nIf this move kills increase Fish Whisperer by 1.";
      ability8.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability8.effects = new Effect[5];
      ability8.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<SwapThreeTimesEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability8.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability8.effects[2] = new Effect(yeah, 1, new IntentType?((IntentType) 40), Slots.Self);
      ability8.effects[3] = new Effect((EffectSO) instance7, 16, new IntentType?((IntentType) 4), Slots.Front);
      ability8.effects[4] = new Effect((EffectSO) instance6, 8, new IntentType?((IntentType) 2), Slots.LeftRight, (EffectConditionSO) instance5);
      ability8.animationTarget = Slots.Front;
            ability8.visuals = null;
      ScriptableObject.CreateInstance<ChangeHealthColorEffect>()._color = Pigments.Blue;
      ApplyRandomStatusEffectEffect instance8 = ScriptableObject.CreateInstance<ApplyRandomStatusEffectEffect>();
      instance8._repeatAmount = 2;
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("SkillFishyBusiness", 1);
      ability9.name = "Fishy Trade";
      ability9.description = "Inflict 2 random status or field effects to the opposing enemy. Increase Fish Whisperer by 0-1.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Blue
      };
      ability9.effects = new Effect[2];
      ability9.effects[0] = new Effect((EffectSO) instance8, 1, new IntentType?(), Slots.Front);
      ability9.effects[1] = new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(50));
      ability9.animationTarget = Slots.Self;
      ability9.visuals = LoadedAssetsHandler.GetEnemy("Scrungie_EN").abilities[3].ability.visuals;
      ApplyRandomStatusEffectEffect instance9 = ScriptableObject.CreateInstance<ApplyRandomStatusEffectEffect>();
      instance9._repeatAmount = 3;
      Ability ability10 = new Ability();
      ability10.sprite = ResourceLoader.LoadSprite("SkillFishyBusiness", 1);
      ability10.name = "Fishy Bargain";
      ability10.description = "Inflict 3 random status or field effects to the opposing enemy. Increase Fish Whisperer by 0-1.";
      ability10.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Blue
      };
      ability10.effects = new Effect[2];
      ability10.effects[0] = new Effect((EffectSO) instance9, 1, new IntentType?(), Slots.Front);
      ability10.effects[1] = new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(50));
      ability10.animationTarget = Slots.Self;
      ability10.visuals = LoadedAssetsHandler.GetEnemy("Scrungie_EN").abilities[3].ability.visuals;
      ApplyRandomStatusEffectEffect instance10 = ScriptableObject.CreateInstance<ApplyRandomStatusEffectEffect>();
      instance10._repeatAmount = 4;
      Ability ability11 = new Ability();
      ability11.sprite = ResourceLoader.LoadSprite("SkillFishyBusiness", 1);
      ability11.name = "Fishy Deal";
      ability11.description = "Inflict 4 random status or field effects to the opposing enemy. Increase Fish Whisperer by 0-1.";
      ability11.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Blue
      };
      ability11.effects = new Effect[2];
      ability11.effects[0] = new Effect((EffectSO) instance10, 1, new IntentType?(), Slots.Front);
      ability11.effects[1] = new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(50));
      ability11.animationTarget = Slots.Self;
      ability11.visuals = LoadedAssetsHandler.GetEnemy("Scrungie_EN").abilities[3].ability.visuals;
      ApplyRandomStatusEffectEffect instance11 = ScriptableObject.CreateInstance<ApplyRandomStatusEffectEffect>();
      instance11._repeatAmount = 5;
      Ability ability12 = new Ability();
      ability12.sprite = ResourceLoader.LoadSprite("SkillFishyBusiness", 1);
      ability12.name = "Fishy Business";
      ability12.description = "Inflict 5 random status or field effects to the opposing enemy. Increase Fish Whisperer by 0-1.";
      ability12.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Blue
      };
      ability12.effects = new Effect[2];
      ability12.effects[0] = new Effect((EffectSO) instance11, 1, new IntentType?(), Slots.Front);
      ability12.effects[1] = new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(50));
      ability12.animationTarget = Slots.Self;
      ability12.visuals = LoadedAssetsHandler.GetEnemy("Scrungie_EN").abilities[3].ability.visuals;
      character.AddLevel(13, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(16, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(18, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(20, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.isSupport = true;
      character.ignoredAbilities = new List<int>() { 1 };
      character.AddCharacter();
      BrutalAPI.BrutalAPI.selCharsSO._dpsCharacters.Add(new CharacterRefString(character.charData._characterName), new CharacterIgnoredAbilities()
      {
        ignoredAbilities = new List<int>() { 0, 2 }
      });
      Carpy.Fish = character;
    }

    public static string AddOtherStoredValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color red = Color.red;
      string str1;
      if (storedValue == (UnitStoredValueNames)93512)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Fish" + string.Format(" +{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    public static void SetupFish()
    {
      Carpy.fishingRod = LoadedAssetsHandler.GetWearable("FishingRod_TW") as PerformEffectWearable;
      Carpy.wormsCan = LoadedAssetsHandler.GetWearable("CanOfWorms_SW") as PerformEffectWearable;
      Carpy.catfish = LoadedAssetsHandler.GetWearable("WelsCatfish_ExtraW") as PerformEffectWithConsumeEffectWearable;
      Carpy.rodFish = Carpy.fishingRod.effects[0].effect as ExtraLootListEffect;
      Carpy.canFish = Carpy.wormsCan.effects[0].effect as ExtraLootListEffect;
      Carpy.catFish = Carpy.catfish._consumptionEffects[0].effect as ExtraLootListEffect;
      Carpy.fishSet = true;
    }

    public static void FishExample()
    {
      ExtraLootListEffect effect = (LoadedAssetsHandler.GetWearable("FishingRod_TW") as PerformEffectWearable).effects[0].effect as ExtraLootListEffect;
      ExtraLootListEffect instance = ScriptableObject.CreateInstance<ExtraLootListEffect>();
      instance._treasurePercentage = 1;
      instance._nothingPercentage = 0;
      instance._shopPercentage = 2;
      instance._lootableItems = effect._lootableItems;
      instance._lockedLootableItems = effect._lockedLootableItems;
    }
  }

    public class SwapThreeTimesEffect : SwapToSidesEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < 3; i++) if (base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, entryVariable, out int ex)) exitAmount += ex;
            return true;
        }
    }
}
