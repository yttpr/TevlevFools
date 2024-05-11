// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.LoveBug
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class LoveBug
  {
    public static Character Bug;
    public static ApplyParasiteEffect AddPara;

        public static void add()
        {
            PerformEffectPassiveAbility performEffectPassiveAbility = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            performEffectPassiveAbility._passiveName = "Skittish (2)";
            performEffectPassiveAbility.passiveIcon = Passives.Skittish.passiveIcon;
            performEffectPassiveAbility.type = (PassiveAbilityTypes)386742;
            performEffectPassiveAbility._enemyDescription = "This is my brother billo";
            performEffectPassiveAbility._characterDescription = "Upon performing an ability this party member will move to the Left or Right 2 times.";
            performEffectPassiveAbility.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self, null),
                new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self, null)
            });
            performEffectPassiveAbility._triggerOn = new TriggerCalls[]
            {
                (TriggerCalls)14
            };
            ParasitePassiveAbility parasitePassiveAbility = ScriptableObject.CreateInstance<ParasitePassiveAbility>();
            parasitePassiveAbility.conditions = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.conditions;
            parasitePassiveAbility._damagePercentage = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
            parasitePassiveAbility.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
            CasterSetStoredValueEffect casterSetStoredValueEffect = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
            casterSetStoredValueEffect._valueName = (UnitStoredValueNames)14;
            parasitePassiveAbility.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(casterSetStoredValueEffect, 0, null, Slots.Self, null)
            });
            parasitePassiveAbility.connectionImmediateEffect = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).connectionImmediateEffect;
            parasitePassiveAbility.disconnectionImmediateEffect = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).disconnectionImmediateEffect;
            parasitePassiveAbility.doesPassiveTriggerInformationPanel = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.doesPassiveTriggerInformationPanel;
            DealRandomAmountDamageConvertToParasiteEffect dealRandomAmountDamageConvertToParasiteEffect = ScriptableObject.CreateInstance<DealRandomAmountDamageConvertToParasiteEffect>();
            dealRandomAmountDamageConvertToParasiteEffect._indirect = true;
            dealRandomAmountDamageConvertToParasiteEffect._minAmount = 1;
            dealRandomAmountDamageConvertToParasiteEffect._passiveToAdd = parasitePassiveAbility;
            parasitePassiveAbility.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(dealRandomAmountDamageConvertToParasiteEffect, 5, null, Slots.Self, null)
            });
            parasitePassiveAbility.passiveIcon = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.passiveIcon;
            parasitePassiveAbility.specialStoredValue = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).specialStoredValue;
            parasitePassiveAbility.type = (PassiveAbilityTypes)45;
            parasitePassiveAbility._characterDescription = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd._characterDescription;
            parasitePassiveAbility._damagePercentage = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
            parasitePassiveAbility._enemyDescription = "Increases the damage received by 5% per point of Parasite. Parasite will decrease by the original unmutliplied damage amount. Parasite will remove 1-5 health from this enemies at the end of every turn and convert it into more Parasite.";
            parasitePassiveAbility._isFriendly = false;
            parasitePassiveAbility._parasiteShield = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._parasiteShield;
            parasitePassiveAbility._passiveName = "Parasitism";
            parasitePassiveAbility._secondTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._secondTriggerOn;
            parasitePassiveAbility._thirdTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._thirdTriggerOn;
            parasitePassiveAbility._triggerOn = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd._triggerOn;
            ApplyParasiteEffect applyParasiteEffect = ScriptableObject.CreateInstance<ApplyParasiteEffect>();
            applyParasiteEffect._passiveToAdd = parasitePassiveAbility;
            LoveBug.AddPara = applyParasiteEffect;
            ReturnPreviousExitAmountDamageParasiteEffect returnPreviousExitAmountDamageParasiteEffect = ScriptableObject.CreateInstance<ReturnPreviousExitAmountDamageParasiteEffect>();
            returnPreviousExitAmountDamageParasiteEffect._passiveToAdd = parasitePassiveAbility;
            Character character = new Character();
            character.name = "LoveBug";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)837845;
            character.levels = new CharacterRankedData[4];
            character.frontSprite = ResourceLoader.LoadSprite("LovebugFront", 1, null);
            character.backSprite = ResourceLoader.LoadSprite("Lovebugback", 1, null);
            character.overworldSprite = ResourceLoader.LoadSprite("LovebugOverworld", 32, new Vector2?(new Vector2(0.5f, 0f)));
            character.lockedSprite = ResourceLoader.LoadSprite("LovebugMenu", 1, null);
            character.unlockedSprite = ResourceLoader.LoadSprite("LovebugMenu", 1, null);
            character.menuChar = true;
            character.usesBaseAbility = true;
            character.isSupport = false;
            character.usesAllAbilities = false;
            character.appearsInShops = true;
            character.hurtSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Waning_EN").damageSound;
            character.deathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Waning_EN").deathSound;
            character.dialogueSound = character.hurtSound;
            character.passives = new BasePassiveAbilitySO[]
            {
                performEffectPassiveAbility
            };
            Ability ability = new Ability();
            ability.sprite = ResourceLoader.LoadSprite("SkillPeekabo", 1, null);
            ability.name = "Playful Peekabo";
            ability.description = "Move Left or Right.\nDeal 4 damage to the Opposing enemy and apply parasitism for the amount of damage done.\nAttempt to return to the original position.";
            ability.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Yellow
            };
            ability.effects = new Effect[3];
            ability.effects[0] = new Effect(ScriptableObject.CreateInstance<SwapToSidesReturnCurrentSlotEffect>(), 1, new IntentType?((IntentType)40), Slots.Self, null);
            ability.effects[1] = new Effect(returnPreviousExitAmountDamageParasiteEffect, 4, new IntentType?((IntentType)1), Slots.Front, null);
            ability.effects[2] = new Effect(ScriptableObject.CreateInstance<ReturnBackToSlotBasedOnPreviousExitAmountEffect>(), 4, new IntentType?((IntentType)40), Slots.Self, null);
            ability.animationTarget = Slots.Front;
            ability.visuals = LoadedAssetsHandler.GetCharcater("Splig_CH").rankedData[0].rankAbilities[2].ability.visuals;
            Ability ability2 = new Ability();
            ability2.sprite = ResourceLoader.LoadSprite("SkillPeekabo", 1, null);
            ability2.name = "Frivolous Peekabo";
            ability2.description = "Move Left or Right.\nDeal 6 damage to the Opposing enemy and apply parasitism for the amount of damage done.\nAttempt to return to the original position.";
            ability2.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Yellow
            };
            ability2.effects = new Effect[3];
            ability2.effects[0] = new Effect(ScriptableObject.CreateInstance<SwapToSidesReturnCurrentSlotEffect>(), 1, new IntentType?((IntentType)40), Slots.Self, null);
            ability2.effects[1] = new Effect(returnPreviousExitAmountDamageParasiteEffect, 6, new IntentType?((IntentType)1), Slots.Front, null);
            ability2.effects[2] = new Effect(ScriptableObject.CreateInstance<ReturnBackToSlotBasedOnPreviousExitAmountEffect>(), 4, new IntentType?((IntentType)40), Slots.Self, null);
            ability2.animationTarget = Slots.Front;
            ability2.visuals = LoadedAssetsHandler.GetCharcater("Splig_CH").rankedData[0].rankAbilities[1].ability.visuals;
            Ability ability3 = new Ability();
            ability3.sprite = ResourceLoader.LoadSprite("SkillPeekabo", 1, null);
            ability3.name = "Effervescent Peekabo";
            ability3.description = "Move Left or Right.\nDeal 8 damage to the Opposing enemy and apply parasitism for the amount of damage done.\nAttempt to return to the original position.";
            ability3.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Yellow
            };
            ability3.effects = new Effect[3];
            ability3.effects[0] = new Effect(ScriptableObject.CreateInstance<SwapToSidesReturnCurrentSlotEffect>(), 1, new IntentType?((IntentType)40), Slots.Self, null);
            ability3.effects[1] = new Effect(returnPreviousExitAmountDamageParasiteEffect, 8, new IntentType?((IntentType)2), Slots.Front, null);
            ability3.effects[2] = new Effect(ScriptableObject.CreateInstance<ReturnBackToSlotBasedOnPreviousExitAmountEffect>(), 4, new IntentType?((IntentType)40), Slots.Self, null);
            ability3.animationTarget = Slots.Front;
            ability3.visuals = LoadedAssetsHandler.GetCharcater("Splig_CH").rankedData[0].rankAbilities[1].ability.visuals;
            Ability ability4 = new Ability();
            ability4.sprite = ResourceLoader.LoadSprite("SkillPeekabo", 1, null);
            ability4.name = "Mirthful Peekabo";
            ability4.description = "Move Left or Right.\nDeal 9 damage to the Opposing enemy and apply parasitism for the amount of damage done.\nAttempt to return to the original position.";
            ability4.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Yellow
            };
            ability4.effects = new Effect[3];
            ability4.effects[0] = new Effect(ScriptableObject.CreateInstance<SwapToSidesReturnCurrentSlotEffect>(), 1, new IntentType?((IntentType)40), Slots.Self, null);
            ability4.effects[1] = new Effect(returnPreviousExitAmountDamageParasiteEffect, 9, new IntentType?((IntentType)2), Slots.Front, null);
            ability4.effects[2] = new Effect(ScriptableObject.CreateInstance<ReturnBackToSlotBasedOnPreviousExitAmountEffect>(), 4, new IntentType?((IntentType)40), Slots.Self, null);
            ability4.animationTarget = Slots.Front;
            ability4.visuals = LoadedAssetsHandler.GetCharcater("Splig_CH").rankedData[0].rankAbilities[1].ability.visuals;
            RemoveMultipleStatusEffectsEffect removeMultipleStatusEffectsEffect = ScriptableObject.CreateInstance<RemoveMultipleStatusEffectsEffect>();
            removeMultipleStatusEffectsEffect._statusToRemove = new StatusEffectType[]
            {
                (StatusEffectType)2
            };
            Ability ability5 = new Ability();
            ability5.sprite = ResourceLoader.LoadSprite("SkillKissyKissy", 1, null);
            ability5.name = "Dappy Kissy Kissy";
            ability5.description = "Apply 3 parasitism to the opposing enemy.\nRemove all Ruptured from this party member.\n50% chance to refresh this party member.";
            ability5.cost = new ManaColorSO[]
            {
                Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
            };
            ability5.effects = new Effect[3];
            ability5.effects[0] = new Effect(applyParasiteEffect, 3, new IntentType?((IntentType)104), Slots.Front, null);
            ability5.effects[1] = new Effect(removeMultipleStatusEffectsEffect, 1, new IntentType?((IntentType)191), Slots.Self, null);
            ability5.effects[2] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType)85), Slots.Self, Conditions.Chance(50));
            ability5.animationTarget = Slots.Front;
            ability5.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[0].ability.visuals;
            Ability ability6 = new Ability();
            ability6.sprite = ResourceLoader.LoadSprite("SkillKissyKissy", 1, null);
            ability6.name = "Quixotic Kissy Kissy";
            ability6.description = "Apply 4 parasitism to the opposing enemy.\nRemove all Ruptured from this party member.\n50% chance to refresh this party member.";
            ability6.cost = new ManaColorSO[]
            {
                Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
            };
            ability6.effects = new Effect[3];
            ability6.effects[0] = new Effect(applyParasiteEffect, 4, new IntentType?((IntentType)104), Slots.Front, null);
            ability6.effects[1] = new Effect(removeMultipleStatusEffectsEffect, 1, new IntentType?((IntentType)191), Slots.Self, null);
            ability6.effects[2] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType)85), Slots.Self, Conditions.Chance(50));
            ability6.animationTarget = Slots.Front;
            ability6.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[0].ability.visuals;
            RemoveAllNegativeStatusEffect removeMultipleStatusEffectsEffect2 = ScriptableObject.CreateInstance<RemoveAllNegativeStatusEffect>();
            Ability ability7 = new Ability();
            ability7.sprite = ResourceLoader.LoadSprite("SkillKissyKissy", 1, null);
            ability7.name = "Vagary Kissy Kissy";
            ability7.description = "Apply 4 parasitism to the opposing enemy.\nRemove all negative status effects from this party member.\n50% chance to refresh this party member.";
            ability7.cost = new ManaColorSO[]
            {
                Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
            };
            ability7.effects = new Effect[3];
            ability7.effects[0] = new Effect(applyParasiteEffect, 4, new IntentType?((IntentType)104), Slots.Front, null);
            ability7.effects[1] = new Effect(removeMultipleStatusEffectsEffect2, 1, new IntentType?((IntentType)61), Slots.Self, null);
            ability7.effects[2] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType)85), Slots.Self, Conditions.Chance(50));
            ability7.animationTarget = Slots.Front;
            ability7.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[0].ability.visuals;
            Ability ability8 = new Ability();
            ability8.sprite = ResourceLoader.LoadSprite("SkillKissyKissy", 1, null);
            ability8.name = "Exuberant Kissy Kissy";
            ability8.description = "Apply 5 parasitism to the opposing enemy.\nRemove all negative status effects from this party member.\n50% chance to refresh this party member.";
            ability8.cost = new ManaColorSO[]
            {
                Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
            };
            ability8.effects = new Effect[3];
            ability8.effects[0] = new Effect(applyParasiteEffect, 5, new IntentType?((IntentType)104), Slots.Front, null);
            ability8.effects[1] = new Effect(removeMultipleStatusEffectsEffect2, 1, new IntentType?((IntentType)61), Slots.Self, null);
            ability8.effects[2] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType)85), Slots.Self, Conditions.Chance(50));
            ability8.animationTarget = Slots.Front;
            ability8.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[0].ability.visuals;
            Ability ability9 = new Ability();
            ability9.sprite = ResourceLoader.LoadSprite("SkillPet", 1, null);
            ability9.name = "Jovial Pet";
            ability9.description = "Deal 10 damage to the Opposing enemy.\nIf the Opposing enemy does not have parasitism, deal 6 damage to this party member.";
            ability9.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Red
            };
            ability9.effects = new Effect[1];
            ability9.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageIfNoParasitismEffect>(), 10, new IntentType?((IntentType)2), Slots.Front, null);
            ability9.animationTarget = Slots.Front;
            ability9.visuals = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").abilities[0].ability.visuals;
            Ability ability10 = new Ability();
            ability10.sprite = ResourceLoader.LoadSprite("SkillPet", 1, null);
            ability10.name = "Jocund Pet";
            ability10.description = "Deal 12 damage to the Opposing enemy.\nIf the Opposing enemy does not have parasitism, deal 6 damage to this party member.";
            ability10.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Red
            };
            ability10.effects = new Effect[1];
            ability10.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageIfNoParasitismEffect>(), 12, new IntentType?((IntentType)3), Slots.Front, null);
            ability10.animationTarget = Slots.Front;
            ability10.visuals = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").abilities[0].ability.visuals;
            Ability ability11 = new Ability();
            ability11.sprite = ResourceLoader.LoadSprite("SkillPet", 1, null);
            ability11.name = "Joyous Pet";
            ability11.description = "Deal 16 damage to the Opposing enemy.\nIf the Opposing enemy does not have parasitism, deal 6 damage to this party member.";
            ability11.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Red
            };
            ability11.effects = new Effect[1];
            ability11.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageIfNoParasitismEffect>(), 16, new IntentType?((IntentType)4), Slots.Front, null);
            ability11.animationTarget = Slots.Front;
            ability11.visuals = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").abilities[0].ability.visuals;
            Ability ability12 = new Ability();
            ability12.sprite = ResourceLoader.LoadSprite("SkillPet", 1, null);
            ability12.name = "Radiant Pet";
            ability12.description = "Deal 20 damage to the Opposing enemy.\nIf the Opposing enemy does not have parasitism, deal 6 damage to this party member.";
            ability12.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Red
            };
            ability12.effects = new Effect[1];
            ability12.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageIfNoParasitismEffect>(), 20, new IntentType?((IntentType)4), Slots.Front, null);
            ability12.animationTarget = Slots.Front;
            ability12.visuals = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").abilities[0].ability.visuals;
            character.AddLevel(14, new Ability[]
            {
                ability,
                ability5,
                ability9
            }, 0);
            character.AddLevel(17, new Ability[]
            {
                ability2,
                ability6,
                ability10
            }, 1);
            character.AddLevel(20, new Ability[]
            {
                ability3,
                ability7,
                ability11
            }, 2);
            character.AddLevel(25, new Ability[]
            {
                ability4,
                ability8,
                ability12
            }, 3);
            character.AddCharacter();
            LoveBug.Bug = character;
            try { LoadedAssetsHandler.GetCharcater("LoveBug_CH")._characterName = "Lovebug"; }
            catch { Debug.LogError("failed to change lovebug's name"); }
        }
    }

    public class RemoveAllNegativeStatusEffect : EffectSO
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit is IStatusEffector unit)
                {
                    foreach (IStatusEffect istatusEffect in new List<IStatusEffect>((IEnumerable<IStatusEffect>)unit.StatusEffects))
                    {
                        if (!istatusEffect.IsPositive)
                            exitAmount += target.Unit.TryRemoveStatusEffect(istatusEffect.EffectType);
                    }
                }
            }
            return exitAmount > 0;
        }
    }
}
