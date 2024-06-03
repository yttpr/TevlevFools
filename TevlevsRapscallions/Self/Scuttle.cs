// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Scuttle
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class Scuttle
  {
    public static void Major()
    {
      Character character = new Character()
      {
        name = "ScuttleFace",
        healthColor = Pigments.Red,
        entityID = (EntityIDs) 426945,
        frontSprite = ResourceLoader.LoadSprite("ScuttleFaceFront"),
        backSprite = ResourceLoader.LoadSprite("ScuttleFaceback"),
        overworldSprite = ResourceLoader.LoadSprite("ScuttleFaceOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        lockedSprite = ResourceLoader.LoadSprite("ScuttleFaceMenu", 321)
      };
      character.unlockedSprite = character.lockedSprite;
      character.menuChar = false;
      character.usesBaseAbility = true;
      character.isSupport = false;
      character.usesAllAbilities = false;
      character.appearsInShops = false;
      character.hurtSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").damageSound;
      character.deathSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").deathSound;
      character.dialogueSound = character.hurtSound;
      character.passives = LoveBug.Bug.passives;
      character.levels = new CharacterRankedData[1];
      ParasitePassiveAbility instance1 = ScriptableObject.CreateInstance<ParasitePassiveAbility>();
      ((BasePassiveAbilitySO) instance1).conditions = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.conditions;
      instance1._damagePercentage = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
      instance1.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
      CasterSetStoredValueEffect instance2 = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
      instance2._valueName = (UnitStoredValueNames) 14;
      CopyAndSpawnCustomCharacterAnywhereEffect instance3 = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
      instance3._characterCopy = "ScuttleMaggot_CH";
      instance3._permanentSpawn = true;
      instance3._rank = 0;
      instance3._extraModifiers = new WearableStaticModifierSetterSO[0];
      instance1.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
      {
        new Effect( instance2, 0, new IntentType?(), Slots.Self),
        new Effect( instance3, 1, new IntentType?(), Slots.Self)
      });
      instance1.connectionImmediateEffect = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).connectionImmediateEffect;
      instance1.disconnectionImmediateEffect = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).disconnectionImmediateEffect;
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.doesPassiveTriggerInformationPanel;
      DealRandomAmountDamageConvertToParasiteEffect instance4 = ScriptableObject.CreateInstance<DealRandomAmountDamageConvertToParasiteEffect>();
      instance4._indirect = true;
      instance4._minAmount = 0;
      instance4._passiveToAdd = (BasePassiveAbilitySO) instance1;
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect( instance4, 2, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1).passiveIcon = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.passiveIcon;
      ((BasePassiveAbilitySO) instance1).specialStoredValue = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.specialStoredValue;
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 45;
      ((BasePassiveAbilitySO) instance1)._characterDescription = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd._characterDescription;
      instance1._damagePercentage = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "Increases the damage received by 5% per point of Parasite. Parasite will decrease by the original unmutliplied damage amount. Parasite will remove 0-2 health from this enemies at the end of every turn and convert it into more Parasite.";
      instance1._isFriendly = false;
      instance1._parasiteShield = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._parasiteShield;
      ((BasePassiveAbilitySO) instance1)._passiveName = "Parasitism";
      instance1._secondTriggerOn = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._secondTriggerOn;
      instance1._thirdTriggerOn = ((ParasitePassiveAbility) ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._thirdTriggerOn;
      ((BasePassiveAbilitySO) instance1)._triggerOn = ((AddPassiveEffect) LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd._triggerOn;
      ApplyParasiteEffect instance5 = ScriptableObject.CreateInstance<ApplyParasiteEffect>();
      instance5._passiveToAdd = (BasePassiveAbilitySO) instance1;
      ReturnPreviousExitAmountDamageParasiteEffect instance6 = ScriptableObject.CreateInstance<ReturnPreviousExitAmountDamageParasiteEffect>();
      instance6._passiveToAdd = (BasePassiveAbilitySO) instance1;
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("SkillPeekabo", 1);
      ability1.name = "Playful Peekabo";
      ability1.description = "Move Left or Right.\nDeal 4 damage to the Opposing enemy and apply parasitism for the amount of damage done.\nAttempt to return to the original position.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect( ScriptableObject.CreateInstance<SwapToSidesReturnCurrentSlotEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability1.effects[1] = new Effect( instance6, 4, new IntentType?((IntentType) 1), Slots.Front);
      ability1.effects[2] = new Effect( ScriptableObject.CreateInstance<ReturnBackToSlotBasedOnPreviousExitAmountEffect>(), 4, new IntentType?((IntentType) 40), Slots.Self);
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharcater("Splig_CH").rankedData[0].rankAbilities[2].ability.visuals;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("SkillKissyKissy", 1);
      ability2.name = "Dappy Kissy Kissy";
      ability2.description = "Apply 3 parasitism to the opposing enemy.\nRemove all Ruptured from this party member.\n50% chance to refresh this party member.";
      ability2.cost = new ManaColorSO[1]
      {
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
      };
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect( instance5, 3, new IntentType?((IntentType) 104), Slots.Front);
      RemoveMultipleStatusEffectsEffect instance7 = ScriptableObject.CreateInstance<RemoveMultipleStatusEffectsEffect>();
      instance7._statusToRemove = new StatusEffectType[1]
      {
        (StatusEffectType) 2
      };
      ability2.effects[1] = new Effect( instance7, 1, new IntentType?((IntentType) 191), Slots.Self);
      ability2.effects[2] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self,  Conditions.Chance(50));
      ability2.animationTarget = Slots.Front;
      ability2.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[0].ability.visuals;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("SkillPet", 1);
      ability3.name = "Jovial Pet";
      ability3.description = "Deal 10 damage to the Opposing enemy.\nIf the Opposing enemy does not have parasitism, deal 6 damage to this party member.";
      ability3.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability3.effects = new Effect[1];
      ability3.effects[0] = new Effect( ScriptableObject.CreateInstance<DamageIfNoParasitismEffect>(), 10, new IntentType?((IntentType) 2), Slots.Front);
      ability3.animationTarget = Slots.Front;
      ability3.visuals = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").abilities[0].ability.visuals;
      character.AddLevel(10, new Ability[3]
      {
        ability1,
        ability2,
        ability3
      }, 0);
      character.AddCharacter();
    }

    public static void Minor()
    {
      Character character = new Character()
      {
        name = "ScuttleMaggot",
        healthColor = Pigments.Red,
        entityID = (EntityIDs) 426945,
        frontSprite = ResourceLoader.LoadSprite("ScuttleMaggotFront.png"),
        backSprite = ResourceLoader.LoadSprite("ScuttleMaggotBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("ScuttleMaggotOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        lockedSprite = ResourceLoader.LoadSprite("ScuttleMaggotOverworld.png", 321)
      };
      character.unlockedSprite = character.lockedSprite;
      character.menuChar = false;
      character.usesBaseAbility = false;
      character.isSupport = false;
      character.usesAllAbilities = true;
      character.appearsInShops = false;
      character.hurtSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound;
      character.deathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound;
      character.dialogueSound = character.hurtSound;
      character.passives = new BasePassiveAbilitySO[0];
      character.levels = new CharacterRankedData[1];
      Ability ability1 = new Ability();
      ability1.name = "Munch";
      ability1.description = "Deal 2 damage to the Opposing enemy. \nIf this kills, this party member permanently grows into their next phase.";
      ability1.sprite = LoadedAssetsHandler.GetCharacterAbility("Nibble_1_A").abilitySprite;
      ability1.cost = new ManaColorSO[1]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Yellow)
      };
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Nibble_A").visuals;
      ability1.animationTarget = Slots.Front;
      DamageEffect instance1 = ScriptableObject.CreateInstance<DamageEffect>();
      instance1._returnKillAsSuccess = true;
      CopyAndSpawnCustomCharacterSameSlotEffect instance2 = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterSameSlotEffect>();
      instance2._characterCopy = "ScuttleFace_CH";
      instance2._permanentSpawn = true;
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect( instance1, 2, new IntentType?((IntentType) 0), Slots.Front);
      ability1.effects[1] = new Effect( ScriptableObject.CreateInstance<PermaFleeCasterEffect>(), 1, new IntentType?(), Slots.Self,  EZEffects.DidThat<PreviousEffectCondition>(true));
      ability1.effects[2] = new Effect( SubActionEffect.Create(new Effect[1]
      {
        new Effect( instance2, 1, new IntentType?(), Slots.Self)
      }), 1, new IntentType?((IntentType) 83), Slots.Self,  EZEffects.DidThat<PreviousEffectCondition>(true, 2));
      Ability ability2 = new Ability();
      ability2.name = "Skitter";
      ability2.description = "Fully heal this party member and instantly flee.";
      ability2.cost = new ManaColorSO[1]{ Pigments.Yellow };
      ability2.visuals = (AttackVisualsSO) null;
      ability2.animationTarget = Slots.Self;
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect( ScriptableObject.CreateInstance<FullHealEffect>(), 1, new IntentType?((IntentType) 22), Slots.Self);
      ability2.effects[1] = new Effect( ScriptableObject.CreateInstance<DamageByCostEffect>(), 1, new IntentType?(), Slots.Self);
      CustomIntentInfo customIntentInfo = new CustomIntentInfo("Fleeting", (IntentType) 83021006, Passives.Fleeting.passiveIcon, (IntentType) 100);
      ability2.effects[2] = new Effect( ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Fleeting")), Slots.Self);
      character.AddLevel(5, new Ability[2]
      {
        ability1,
        ability2
      }, 0);
      character.AddCharacter();
    }
  }
}
