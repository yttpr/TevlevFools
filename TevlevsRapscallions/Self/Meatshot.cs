// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Meatshot
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class Meatshot
  {
    public static Character Gun;

    public static void add()
    {
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("SkillFleshRecalibrate", 1);
      ability1.name = "Flesh Recalibrate";
      ability1.description = "Convert 5 hp from this party member as mutualism.";
      ability1.cost = new ManaColorSO[1]{ Pigments.Gray };
      ability1.effects = new Effect[1];
      ability1.effects[0] = new Effect( ScriptableObject.CreateInstance<ConvertHealthToMutualismEffect>(), 5, new IntentType?((IntentType) 82), Slots.Self);
      ability1.visuals = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals;
      ExtraAbility_Wearable_SMS instance1 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
      instance1._extraAbility = ability1.CharacterAbility();
      CasterAddOrRemoveExtraAbilityEffect instance2 = ScriptableObject.CreateInstance<CasterAddOrRemoveExtraAbilityEffect>();
      instance2._extraAbility = instance1;
      CasterAddOrRemoveExtraAbilityEffect instance3 = ScriptableObject.CreateInstance<CasterAddOrRemoveExtraAbilityEffect>();
      instance3._extraAbility = instance1;
      instance3._removeExtraAbility = true;
      ParasitePassiveAbility instance4 = ScriptableObject.CreateInstance<ParasitePassiveAbility>();
      ((BasePassiveAbilitySO) instance4).conditions = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd.conditions;
      instance4._damagePercentage = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
      instance4.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect( instance2, 1, new IntentType?(), Slots.Self)
      });
      instance4.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect( instance3, 1, new IntentType?(), Slots.Self)
      });
      instance4.connectionImmediateEffect = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd).connectionImmediateEffect;
      instance4.disconnectionImmediateEffect = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd).disconnectionImmediateEffect;
      ((BasePassiveAbilitySO) instance4).doesPassiveTriggerInformationPanel = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd.doesPassiveTriggerInformationPanel;
      instance4.effects = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd).effects;
      ((BasePassiveAbilitySO) instance4).passiveIcon = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd.passiveIcon;
      ((BasePassiveAbilitySO) instance4).specialStoredValue = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd.specialStoredValue;
      ((BasePassiveAbilitySO) instance4).type = (PassiveAbilityTypes) 45;
      ((BasePassiveAbilitySO) instance4)._characterDescription = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd._characterDescription;
      instance4._damagePercentage = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
      ((BasePassiveAbilitySO) instance4)._enemyDescription = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd._characterDescription;
      instance4._isFriendly = true;
      instance4._parasiteShield = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._parasiteShield;
      ((BasePassiveAbilitySO) instance4)._passiveName = "Mutualism";
      instance4._secondTriggerOn = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._secondTriggerOn;
      instance4._thirdTriggerOn = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._thirdTriggerOn;
      ((BasePassiveAbilitySO) instance4)._triggerOn = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd._triggerOn;
      PreviousEffectCondition instance5 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance5.wasSuccessful = true;
      PreviousEffectCondition instance6 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance6.wasSuccessful = false;
      AnimationVisualsEffect instance7 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
      instance7._animationTarget = Slots.Self;
      instance7._visuals = LoadedAssetsHandler.GetEnemy("Scrungie_EN").abilities[3].ability.visuals;
      AnimationVisualsEffect instance8 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
      instance8._animationTarget = AllySlots.Left;
      instance8._visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[1].ability.visuals;
      EnterCasterMutalismEffect instance9 = ScriptableObject.CreateInstance<EnterCasterMutalismEffect>();
      instance9._passiveToAdd = (BasePassiveAbilitySO) instance4;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("SkillLocknLoad", 1);
      ability2.name = "Lock n' Load";
      ability2.description = "Force the left ally to enter this party member.\nIf this party member has mutualism, instead eject ally.";
      ability2.cost = new ManaColorSO[1]{ Pigments.Yellow };
      ability2.effects = new Effect[4];
      ability2.effects[0] = new Effect( ScriptableObject.CreateInstance<RemoveMutualismEffect>(), 1, new IntentType?((IntentType) 83), Slots.Self);
      ability2.effects[1] = new Effect( instance7, 1, new IntentType?(), Slots.Self,  instance5);
      ability2.effects[2] = new Effect( instance8, 1, new IntentType?(), Slots.Self,  instance6);
      ability2.effects[3] = new Effect( instance9, 1, new IntentType?((IntentType) 61), AllySlots.Left,  instance5);
      PerformEffectPassiveAbility instance10 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance10)._passiveName = "Leaky(3)";
      ((BasePassiveAbilitySO) instance10).passiveIcon = Passives.Leaky.passiveIcon;
      ((BasePassiveAbilitySO) instance10).type = (PassiveAbilityTypes) 256781;
      ((BasePassiveAbilitySO) instance10)._enemyDescription = "WHATE!!!";
      ((BasePassiveAbilitySO) instance10)._characterDescription = "Upon receiving direct damage, this character generates 3 extra pigment of its health colour.";
      instance10.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect( ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 3, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance10)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 12
      };
      Character character = new Character()
      {
        name = nameof (Meatshot),
        healthColor = Pigments.Red,
        entityID = (EntityIDs) 837145,
        levels = new CharacterRankedData[4],
        frontSprite = ResourceLoader.LoadSprite("MeatshotFront", 1),
        backSprite = ResourceLoader.LoadSprite("MeatshotBack", 1),
        overworldSprite = ResourceLoader.LoadSprite("MeatshotOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        lockedSprite = ResourceLoader.LoadSprite("MeatshotMenu", 1),
        unlockedSprite = ResourceLoader.LoadSprite("MeatshotMenu", 1),
        menuChar = true,
        walksInOverworld = true,
        isSupport = false,
        usesAllAbilities = false,
        usesBaseAbility = true,
        baseAbility = ability2,
        hurtSound = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").damageSound,
        deathSound = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").deathSound
      };
      character.dialogueSound = character.hurtSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance10
      };
      DamageBasedOnMutualismEffect instance11 = ScriptableObject.CreateInstance<DamageBasedOnMutualismEffect>();
      instance11._reduceamount = 50f;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("SkillPointBlank", 1);
      ability3.name = "Point-Blank Clap";
      ability3.description = "Deal 8 damage to the Opposing enemy.\nMove enemy to the left or right far as possible.\nIf this party member has mutualism, reduce 50% of ally's mutualism and deal it as extra damage. ";
      ability3.cost = new ManaColorSO[4]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability3.effects = new Effect[2];
      ability3.effects[0] = new Effect( instance11, 8, new IntentType?((IntentType) 2), Slots.Front);
      ability3.effects[1] = new Effect( ScriptableObject.CreateInstance<ForceTargetFarSwapEffect>(), 0, new IntentType?((IntentType) 40), Slots.Front);
      ability3.animationTarget = Slots.Front;
      ability3.visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;
      Ability ability4 = new Ability();
      ability4.sprite = ResourceLoader.LoadSprite("SkillPointBlank", 1);
      ability4.name = "Point-Blank Slam";
      ability4.description = "Deal 10 damage to the Opposing enemy.\nMove enemy to the left or right far as possible.\nIf this party member has mutualism, reduce 50% of ally's mutualism and deal it as extra damage. ";
      ability4.cost = new ManaColorSO[4]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability4.effects = new Effect[2];
      ability4.effects[0] = new Effect( instance11, 10, new IntentType?((IntentType) 2), Slots.Front);
      ability4.effects[1] = new Effect( ScriptableObject.CreateInstance<ForceTargetFarSwapEffect>(), 0, new IntentType?((IntentType) 40), Slots.Front);
      ability4.animationTarget = Slots.Front;
      ability4.visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("SkillPointBlank", 1);
      ability5.name = "Point-Blank Burst";
      ability5.description = "Deal 11 damage to the Opposing enemy.\nMove enemy to the left or right far as possible.\nIf this party member has mutualism, reduce 50% of ally's mutualism and deal it as extra damage. ";
      ability5.cost = new ManaColorSO[4]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability5.effects = new Effect[2];
      ability5.effects[0] = new Effect( instance11, 11, new IntentType?((IntentType) 3), Slots.Front);
      ability5.effects[1] = new Effect( ScriptableObject.CreateInstance<ForceTargetFarSwapEffect>(), 0, new IntentType?((IntentType) 40), Slots.Front);
      ability5.animationTarget = Slots.Front;
      ability5.visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("SkillPointBlank", 1);
      ability6.name = "Point-Blank Blast";
      ability6.description = "Deal 14 damage to the Opposing enemy.\nMove enemy to the left or right far as possible.\nIf this party member has mutualism, reduce 50% of ally's mutualism and deal it as extra damage. ";
      ability6.cost = new ManaColorSO[4]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability6.effects = new Effect[2];
      ability6.effects[0] = new Effect( instance11, 14, new IntentType?((IntentType) 3), Slots.Front);
      ability6.effects[1] = new Effect( ScriptableObject.CreateInstance<ForceTargetFarSwapEffect>(), 0, new IntentType?((IntentType) 40), Slots.Front);
      ability6.animationTarget = Slots.Front;
      ability6.visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;
      DamageBasedOnMutualismEffect instance12 = ScriptableObject.CreateInstance<DamageBasedOnMutualismEffect>();
      instance12._reduceamount = 100f;
      AnimationVisualsIfMutualismEffect instance13 = ScriptableObject.CreateInstance<AnimationVisualsIfMutualismEffect>();
      instance13._animationTarget = Slots.LeftRight;
      instance13._visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;
      Ability ability7 = new Ability();
      ability7.sprite = ResourceLoader.LoadSprite("SkillSnipe", 1);
      ability7.name = "Crooked Snipe";
      ability7.description = "Deal 4 to the Left and Right enemies.\nAfflict 2 Ruptured to the Left and Right enemies.\nIf this party member has mutualism, reduce 100% of ally's mutualism and deal it as damage to the Left and Right enemies.";
      ability7.cost = new ManaColorSO[4]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red,
        Pigments.Blue
      };
      ability7.effects = new Effect[4];
      ability7.effects[0] = new Effect( ScriptableObject.CreateInstance<DamageEffect>(), 4, new IntentType?((IntentType) 1), Slots.LeftRight);
      ability7.effects[1] = new Effect( ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, new IntentType?((IntentType) 151), Slots.LeftRight);
      ability7.effects[2] = new Effect( instance13, 0, new IntentType?(), Slots.Self);
      ability7.effects[3] = new Effect( instance12, 0, new IntentType?((IntentType) 1), Slots.LeftRight,  instance5);
      ability7.animationTarget = Slots.LeftRight;
      ability7.visuals = LoadedAssetsHandler.GetEnemy("Revola_EN").abilities[1].ability.visuals;
      Ability ability8 = new Ability();
      ability8.sprite = ResourceLoader.LoadSprite("SkillSnipe", 1);
      ability8.name = "Malefic Snipe";
      ability8.description = "Deal 6 to the Left and Right enemies.\nAfflict 2 Ruptured to the Left and Right enemies.\nIf this party member has mutualism, reduce 100% of ally's mutualism and deal it as damage to the Left and Right enemies.";
      ability8.cost = new ManaColorSO[4]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red,
        Pigments.Blue
      };
      ability8.effects = new Effect[4];
      ability8.effects[0] = new Effect( ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?((IntentType) 1), Slots.LeftRight);
      ability8.effects[1] = new Effect( ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, new IntentType?((IntentType) 151), Slots.LeftRight);
      ability8.effects[2] = new Effect( instance13, 0, new IntentType?(), Slots.Self);
      ability8.effects[3] = new Effect( instance12, 0, new IntentType?((IntentType) 1), Slots.LeftRight,  instance5);
      ability8.animationTarget = Slots.LeftRight;
      ability8.visuals = LoadedAssetsHandler.GetEnemy("Revola_EN").abilities[1].ability.visuals;
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("SkillSnipe", 1);
      ability9.name = "Twisted Snipe";
      ability9.description = "Deal 8 to the Left and Right enemies.\nAfflict 2 Ruptured to the Left and Right enemies.\nIf this party member has mutualism, reduce 100% of ally's mutualism and deal it as damage to the Left and Right enemies.";
      ability9.cost = new ManaColorSO[4]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red,
        Pigments.Blue
      };
      ability9.effects = new Effect[4];
      ability9.effects[0] = new Effect( ScriptableObject.CreateInstance<DamageEffect>(), 8, new IntentType?((IntentType) 2), Slots.LeftRight);
      ability9.effects[1] = new Effect( ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, new IntentType?((IntentType) 151), Slots.LeftRight);
      ability9.effects[2] = new Effect( instance13, 0, new IntentType?(), Slots.Self);
      ability9.effects[3] = new Effect( instance12, 0, new IntentType?((IntentType) 1), Slots.LeftRight,  instance5);
      ability9.animationTarget = Slots.LeftRight;
      ability9.visuals = LoadedAssetsHandler.GetEnemy("Revola_EN").abilities[1].ability.visuals;
      Ability ability10 = new Ability();
      ability10.sprite = ResourceLoader.LoadSprite("SkillSnipe", 1);
      ability10.name = "Horrendous Snipe";
      ability10.description = "Deal 10 to the Left and Right enemies.\nAfflict 3 Ruptured to the Left and Right enemies.\nIf this party member has mutualism, reduce 100% of ally's mutualism and deal it as damage to the Left and Right enemies.";
      ability10.cost = new ManaColorSO[4]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red,
        Pigments.Blue
      };
      ability10.effects = new Effect[4];
      ability10.effects[0] = new Effect( ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?((IntentType) 2), Slots.LeftRight);
      ability10.effects[1] = new Effect( ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, new IntentType?((IntentType) 151), Slots.LeftRight);
      ability10.effects[2] = new Effect( instance13, 0, new IntentType?(), Slots.Self);
      ability10.effects[3] = new Effect( instance12, 0, new IntentType?((IntentType) 1), Slots.LeftRight,  instance5);
      ability10.animationTarget = Slots.LeftRight;
      ability10.visuals = LoadedAssetsHandler.GetEnemy("Revola_EN").abilities[1].ability.visuals;
      DamageEffect instance14 = ScriptableObject.CreateInstance<DamageEffect>();
      instance14._returnKillAsSuccess = true;
      ApplyMutalismBasedOnPreviousAmount instance15 = ScriptableObject.CreateInstance<ApplyMutalismBasedOnPreviousAmount>();
      instance15._passiveToAdd = (BasePassiveAbilitySO) instance4;
      Ability ability11 = new Ability();
      ability11.sprite = ResourceLoader.LoadSprite("SkillEvisceration", 1);
      ability11.name = "Desperate Evisceration";
      ability11.description = "Deal 6 damage to the Opposing enemy.\nif this kills, apply Mutualism to this party member equal to the amount of damage done.";
      ability11.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability11.effects = new Effect[2];
      ability11.effects[0] = new Effect( instance14, 6, new IntentType?((IntentType) 1), Slots.Front);
      ability11.effects[1] = new Effect( instance15, 0, new IntentType?((IntentType) 104), Slots.Self,  instance5);
      ability11.animationTarget = Slots.Front;
      ability11.visuals = LoadedAssetsHandler.GetEnemy("MudLung_EN").abilities[0].ability.visuals;
      Ability ability12 = new Ability();
      ability12.sprite = ResourceLoader.LoadSprite("SkillEvisceration", 1);
      ability12.name = "Viscious Evisceration";
      ability12.description = "Deal 8 damage to the Opposing enemy.\nif this kills, apply Mutualism to this party member equal to the amount of damage done.";
      ability12.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability12.effects = new Effect[2];
      ability12.effects[0] = new Effect( instance14, 8, new IntentType?((IntentType) 1), Slots.Front);
      ability12.effects[1] = new Effect( instance15, 0, new IntentType?((IntentType) 104), Slots.Self,  instance5);
      ability12.animationTarget = Slots.Front;
      ability12.visuals = LoadedAssetsHandler.GetEnemy("MudLung_EN").abilities[0].ability.visuals;
      Ability ability13 = new Ability();
      ability13.sprite = ResourceLoader.LoadSprite("SkillEvisceration", 1);
      ability13.name = "Dangerous Evisceration";
      ability13.description = "Deal 10 damage to the Opposing enemy.\nif this kills, apply Mutualism to this party member equal to the amount of damage done.";
      ability13.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability13.effects = new Effect[2];
      ability13.effects[0] = new Effect( instance14, 10, new IntentType?((IntentType) 1), Slots.Front);
      ability13.effects[1] = new Effect( instance15, 0, new IntentType?((IntentType) 104), Slots.Self,  instance5);
      ability13.animationTarget = Slots.Front;
      ability13.visuals = LoadedAssetsHandler.GetEnemy("MudLung_EN").abilities[0].ability.visuals;
      Ability ability14 = new Ability();
      ability14.sprite = ResourceLoader.LoadSprite("SkillEvisceration", 1);
      ability14.name = "Fatal Evisceration";
      ability14.description = "Deal 12 damage to the Opposing enemy.\nif this kills, apply Mutualism to this party member equal to the amount of damage done.";
      ability14.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability14.effects = new Effect[2];
      ability14.effects[0] = new Effect( instance14, 12, new IntentType?((IntentType) 1), Slots.Front);
      ability14.effects[1] = new Effect( instance15, 0, new IntentType?((IntentType) 104), Slots.Self,  instance5);
      ability14.animationTarget = Slots.Front;
      ability14.visuals = LoadedAssetsHandler.GetEnemy("MudLung_EN").abilities[0].ability.visuals;
      character.AddLevel(22, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 0);
      character.AddLevel(25, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 1);
      character.AddLevel(30, new Ability[3]
      {
        ability5,
        ability9,
        ability13
      }, 2);
      character.AddLevel(35, new Ability[3]
      {
        ability6,
        ability10,
        ability14
      }, 3);
      character.AddCharacter();
      Meatshot.Gun = character;
    }
  }
}
