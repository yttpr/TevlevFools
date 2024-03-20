// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Zensuke
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class Zensuke
  {
    public static Character Sale;

    public static void Add()
    {
      RandomAbilityPassive instance1 = ScriptableObject.CreateInstance<RandomAbilityPassive>();
      instance1._passiveName = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0]._passiveName;
      instance1.passiveIcon = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0].passiveIcon;
      instance1.type = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0].type;
      instance1._enemyDescription = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0]._enemyDescription;
      instance1._characterDescription = LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0]._characterDescription;
      instance1._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 889532
      };
      PerformEffectPassiveAbility instance2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance2)._passiveName = "Junk Collector";
      ((BasePassiveAbilitySO) instance2).passiveIcon = ResourceLoader.LoadSprite("JunkCollectorPassive", 1);
      ((BasePassiveAbilitySO) instance2).type = (PassiveAbilityTypes) 795693;
      ((BasePassiveAbilitySO) instance2)._enemyDescription = "At the end of combat find 0-1 SquibbleDibbleDabbleBooblesPoobaa..";
      ((BasePassiveAbilitySO) instance2)._characterDescription = "At the end of combat find 1 Junk.";
      instance2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<GetJunkItemEffect>(), 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance2)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 31
      };
      Character character = new Character();
      character.name = nameof (Zensuke);
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 726845;
      character.levels = new CharacterRankedData[4];
      character.frontSprite = ResourceLoader.LoadSprite("ZensukeFront");
      character.backSprite = ResourceLoader.LoadSprite("ZensukeBack");
      character.overworldSprite = ResourceLoader.LoadSprite("ZensukeOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = ResourceLoader.LoadSprite("ZensukeMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("ZensukeMenu");
      character.menuChar = true;
      character.usesBaseAbility = true;
      character.isSupport = true;
      character.usesAllAbilities = false;
      character.appearsInShops = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Griffin_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Griffin_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Griffin_CH").dxSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance2
      };
      ExtraLootEffect instance3 = ScriptableObject.CreateInstance<ExtraLootEffect>();
      instance3._isTreasure = true;
      instance3._getLocked = false;
      PreviousEffectCondition instance4 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance4.wasSuccessful = true;
      PreviousEffectCondition instance5 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance5.wasSuccessful = false;
      DoubleEffectCondition condition = DoubleEffectCondition.Create((EffectConditionSO) instance4, (EffectConditionSO) Conditions.Chance(50), true);
      PreviousEffectCondition instance6 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance6.wasSuccessful = false;
      instance6.previousAmount = 3;
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("SkillBriefcase", 1);
      ability1.name = "Briefcase Hit";
      ability1.description = "Destroy this party member's item.\nIf an item was destroyed, Deal 10 damage to the Opposing enemy and 50% chance to produce a random item at the end of combat.\nIf no item was destroyed, Deal 4 damage to the Opposing enemy instead.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Red
      };
      ability1.effects = new Effect[4];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.Self);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ReturnPreviousExitAmountDamageEffect>(), 10, new IntentType?((IntentType) 2), Slots.Front, (EffectConditionSO) instance4);
      ability1.effects[2] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) condition);
      ability1.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 4, new IntentType?((IntentType) 1), Slots.Front, (EffectConditionSO) instance6);
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[0].ability.visuals;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("SkillBriefcase", 1);
      ability2.name = "Briefcase Slam";
      ability2.description = "Destroy this party member's item.\nIf an item was destroyed, deal 12 damage to the Opposing enemy and 50% chance to produce a random item at the end of combat.\nIf no item was destroyed, Deal 5 damage to the Opposing enemy instead.";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Red
      };
      ability2.effects = new Effect[4];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.Self);
      ability2.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ReturnPreviousExitAmountDamageEffect>(), 12, new IntentType?((IntentType) 3), Slots.Front, (EffectConditionSO) instance4);
      ability2.effects[2] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) condition);
      ability2.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?((IntentType) 1), Slots.Front, (EffectConditionSO) instance6);
      ability2.animationTarget = Slots.Front;
      ability2.visuals = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[0].ability.visuals;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("SkillBriefcase", 1);
      ability3.name = "Briefcase Crush";
      ability3.description = "Destroy this party member's item.\nIf an item was destroyed, deal 20 damage to the Opposing enemy and 50% chance to produce a random item at the end of combat.\nIf no item was destroyed, Deal 6 damage to the Opposing enemy instead.";
      ability3.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Red
      };
      ability3.effects = new Effect[4];
      ability3.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.Self);
      ability3.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ReturnPreviousExitAmountDamageEffect>(), 20, new IntentType?((IntentType) 4), Slots.Front, (EffectConditionSO) instance4);
      ability3.effects[2] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) condition);
      ability3.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?((IntentType) 1), Slots.Front, (EffectConditionSO) instance6);
      ability3.animationTarget = Slots.Front;
      ability3.visuals = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[0].ability.visuals;
      Ability ability4 = new Ability();
      ability4.sprite = ResourceLoader.LoadSprite("SkillBriefcase", 1);
      ability4.name = "Briefcase Deck";
      ability4.description = "Destroy this party member's item.\nIf an item was destroyed, deal 23 damage to the Opposing enemy and 50% chance to produce a random item at the end of combat.\nIf no item was destroyed, Deal 7 damage to the Opposing enemy instead.";
      ability4.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Red
      };
      ability4.effects = new Effect[4];
      ability4.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.Self);
      ability4.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ReturnPreviousExitAmountDamageEffect>(), 23, new IntentType?((IntentType) 5), Slots.Front, (EffectConditionSO) instance4);
      ability4.effects[2] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) condition);
      ability4.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 7, new IntentType?((IntentType) 1), Slots.Front, (EffectConditionSO) instance6);
      ability4.animationTarget = Slots.Front;
      ability4.visuals = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[0].ability.visuals;
      ProduceCoinsBetweenRandomEffect instance7 = ScriptableObject.CreateInstance<ProduceCoinsBetweenRandomEffect>();
      instance7._min = 2;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("SkillMoneygame", 1);
      ability5.name = "Cents Game";
      ability5.description = "Destroy Left ally's item.\nHeal the Left ally 10 and produce 2-3 coins.\nif there's no item, apply 4 shield to Left ally's position instead.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Yellow
      };
      ability5.effects = new Effect[4];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ReturnPreviousExitValueHealEffect>(), 10, new IntentType?((IntentType) 21), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance4);
      ability5.effects[2] = new Effect((EffectSO) instance7, 3, new IntentType?((IntentType) 105), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance4);
      ability5.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 4, new IntentType?((IntentType) 171), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance5);
      ability5.animationTarget = Slots.SlotTarget(new int[1]
      {
        -1
      }, true);
      ability5.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[2].ability.visuals;
      ProduceCoinsBetweenRandomEffect instance8 = ScriptableObject.CreateInstance<ProduceCoinsBetweenRandomEffect>();
      instance8._min = 3;
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("SkillMoneygame", 1);
      ability6.name = "Cash Game";
      ability6.description = "Destroy Left ally's item.\nHeal the Left ally 13 and produce 3-4 coins.\nif there's no item, apply 5 shield to Left ally's position instead.";
      ability6.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Yellow
      };
      ability6.effects = new Effect[4];
      ability6.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability6.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ReturnPreviousExitValueHealEffect>(), 13, new IntentType?((IntentType) 22), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance4);
      ability6.effects[2] = new Effect((EffectSO) instance8, 4, new IntentType?((IntentType) 105), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance4);
      ability6.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, new IntentType?((IntentType) 171), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance5);
      ability6.animationTarget = Slots.SlotTarget(new int[1]
      {
        -1
      }, true);
      ability6.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[2].ability.visuals;
      ProduceCoinsBetweenRandomEffect instance9 = ScriptableObject.CreateInstance<ProduceCoinsBetweenRandomEffect>();
      instance9._min = 4;
      Ability ability7 = new Ability();
      ability7.sprite = ResourceLoader.LoadSprite("SkillMoneygame", 1);
      ability7.name = "Money Game";
      ability7.description = "Destroy Left ally's item.\nHeal the Left ally 14 and produce 4-5 coins.\nif there's no item, apply 7 shield to Left ally's position instead.";
      ability7.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Yellow
      };
      ability7.effects = new Effect[4];
      ability7.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability7.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ReturnPreviousExitValueHealEffect>(), 14, new IntentType?((IntentType) 22), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance4);
      ability7.effects[2] = new Effect((EffectSO) instance9, 5, new IntentType?((IntentType) 105), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance4);
      ability7.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 7, new IntentType?((IntentType) 171), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance5);
      ability7.animationTarget = Slots.SlotTarget(new int[1]
      {
        -1
      }, true);
      ability7.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[2].ability.visuals;
      ScriptableObject.CreateInstance<ProduceCoinsBetweenRandomEffect>()._min = 5;
      Ability ability8 = new Ability();
      ability8.sprite = ResourceLoader.LoadSprite("SkillMoneygame", 1);
      ability8.name = "Fortune Game";
      ability8.description = "Destroy Left ally's item.\nHeal the Left ally 15 and produce 5-6 coins.\nif there's no item, apply 8 shield to Left ally's position instead.";
      ability8.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Yellow
      };
      ability8.effects = new Effect[4];
      ability8.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability8.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ReturnPreviousExitValueHealEffect>(), 15, new IntentType?((IntentType) 22), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance4);
      ability8.effects[2] = new Effect((EffectSO) instance9, 6, new IntentType?((IntentType) 105), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance4);
      ability8.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 8, new IntentType?((IntentType) 171), Slots.SlotTarget(new int[1]
      {
        -1
      }, true), (EffectConditionSO) instance5);
      ability8.animationTarget = Slots.SlotTarget(new int[1]
      {
        -1
      }, true);
      ability8.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[2].ability.visuals;
      AddPassiveIfDontContainePassiveEffect instance10 = ScriptableObject.CreateInstance<AddPassiveIfDontContainePassiveEffect>();
      instance10._passiveToAdd = (BasePassiveAbilitySO) instance1;
      instance10._passiveToCheck = (PassiveAbilityTypes) 46;
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("SkillTrinkets", 1);
      ability9.name = "Trinkets and Junk";
      ability9.description = "Give the Right party member construct and heal them 2 health, if right party member already has construct reroll their construct ability.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Blue
      };
      ability9.effects = new Effect[3];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConstructPassiveTriggerEffect>(), 1, new IntentType?(), AllySlots.Right);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?((IntentType) 20), AllySlots.Right);
      ability9.effects[2] = new Effect((EffectSO) instance10, 1, new IntentType?((IntentType) 100), AllySlots.Right);
      ability9.animationTarget = AllySlots.Right;
      ability9.visuals = LoadedAssetsHandler.GetEnemy("HickoryFuel_BOSS").abilities[0].ability.visuals;
      Ability ability10 = new Ability();
      ability10.sprite = ResourceLoader.LoadSprite("SkillTrinkets", 1);
      ability10.name = "Trinkets and Stuff";
      ability10.description = "Give the Right party member construct and heal them 3 health, if right party member already has construct reroll their construct ability.";
      ability10.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Blue
      };
      ability10.effects = new Effect[3];
      ability10.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConstructPassiveTriggerEffect>(), 1, new IntentType?(), AllySlots.Right);
      ability10.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 3, new IntentType?((IntentType) 20), AllySlots.Right);
      ability10.effects[2] = new Effect((EffectSO) instance10, 1, new IntentType?((IntentType) 100), AllySlots.Right);
      ability10.animationTarget = AllySlots.Right;
      ability10.visuals = LoadedAssetsHandler.GetEnemy("HickoryFuel_BOSS").abilities[0].ability.visuals;
      Ability ability11 = new Ability();
      ability11.sprite = ResourceLoader.LoadSprite("SkillTrinkets", 1);
      ability11.name = "Trinkets and Baubles";
      ability11.description = "Give the Right party member construct and heal them 4 health, if right party member already has construct reroll their construct ability.";
      ability11.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Blue
      };
      ability11.effects = new Effect[3];
      ability11.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConstructPassiveTriggerEffect>(), 1, new IntentType?(), AllySlots.Right);
      ability11.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), AllySlots.Right);
      ability11.effects[2] = new Effect((EffectSO) instance10, 1, new IntentType?((IntentType) 100), AllySlots.Right);
      ability11.animationTarget = AllySlots.Right;
      ability11.visuals = LoadedAssetsHandler.GetEnemy("HickoryFuel_BOSS").abilities[0].ability.visuals;
      Ability ability12 = new Ability();
      ability12.sprite = ResourceLoader.LoadSprite("SkillTrinkets", 1);
      ability12.name = "Trinkets and Thingamabobs";
      ability12.description = "Give the Right party member construct and heal them 5 health, if right party member already has construct reroll their construct ability.";
      ability12.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Blue
      };
      ability12.effects = new Effect[3];
      ability12.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ConstructPassiveTriggerEffect>(), 1, new IntentType?(), AllySlots.Right);
      ability12.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 5, new IntentType?((IntentType) 20), AllySlots.Right);
      ability12.effects[2] = new Effect((EffectSO) instance10, 1, new IntentType?((IntentType) 100), AllySlots.Right);
      ability12.animationTarget = AllySlots.Right;
      ability12.visuals = LoadedAssetsHandler.GetEnemy("HickoryFuel_BOSS").abilities[0].ability.visuals;
      character.AddLevel(10, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(11, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(12, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(13, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.ignoredAbilities = new List<int>() { 0 };
      character.AddCharacter();
      BrutalAPI.BrutalAPI.selCharsSO._dpsCharacters.Add(new CharacterRefString(character.charData._characterName), new CharacterIgnoredAbilities()
      {
        ignoredAbilities = new List<int>() { 1, 2 }
      });
      Zensuke.Sale = character;
    }
  }
}
