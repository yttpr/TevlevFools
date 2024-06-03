// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.BubbleBlower
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class BubbleBlower
  {
    public static Character Retard;

    public static void Add()
    {
      PerformDoubleEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "MultiAttack (2)";
      ((BasePassiveAbilitySO) instance1).passiveIcon = Passives.Multiattack.passiveIcon;
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 13;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "This shouldn't be on an enemy.";
      ((BasePassiveAbilitySO) instance1)._characterDescription = "This party member can perform two abilities per turn.";
      ((BasePassiveAbilitySO) instance1).specialStoredValue = (UnitStoredValueNames) 77889;
      CasterSetStoredValueEffect instance2 = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
      instance2._valueName = (UnitStoredValueNames) 77889;
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect( instance2, 1, new IntentType?(), Slots.Self)
      });
      RefreshIfStoredValueNotZero instance3 = ScriptableObject.CreateInstance<RefreshIfStoredValueNotZero>();
      instance3._valueName = (UnitStoredValueNames) 77889;
      ScriptableObject.CreateInstance<CasterLowerStoredValueEffect>()._valueName = (UnitStoredValueNames) 77889;
      instance1._secondTriggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 14
      };
      instance1._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect( instance3, 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = false;
      instance1._secondDoesPerformPopUp = false;
      Character character = new Character()
      {
        name = nameof (BubbleBlower),
        healthColor = Pigments.Gray,
        entityID = (EntityIDs) 668243,
        levels = new CharacterRankedData[4],
        frontSprite = ResourceLoader.LoadSprite("BubbleBlowerFront"),
        backSprite = ResourceLoader.LoadSprite("BubbleBlowerBack"),
        overworldSprite = ResourceLoader.LoadSprite("BubbleBlowerOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        lockedSprite = ResourceLoader.LoadSprite("BubbleBlowerMenu"),
        unlockedSprite = ResourceLoader.LoadSprite("BubbleBlowerMenu"),
        menuChar = true,
        usesBaseAbility = true,
        isSupport = false,
        usesAllAbilities = false,
        appearsInShops = true,
        hurtSound = LoadedAssetsHandler.GetEnemy("Flarblet_EN").damageSound,
        deathSound = LoadedAssetsHandler.GetEnemy("Flarblet_EN").deathSound
      };
      character.dialogueSound = character.hurtSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance1
      };
      ApplyBubblesEffect instance4 = ScriptableObject.CreateInstance<ApplyBubblesEffect>();
      instance4._applyonethroughtwoFUCKYOUTEVLEVTHUMBSDOWNEMOJI = true;
      IncreaseBubblesEffect instance5 = ScriptableObject.CreateInstance<IncreaseBubblesEffect>();
      instance5._applyonethroughtwoFUCKYOUTEVLEVTHUMBSDOWNEMOJI = true;
      RemoveFieldStatusEffectEffect instance6 = ScriptableObject.CreateInstance<RemoveFieldStatusEffectEffect>();
      instance6.statusEffectType = (SlotStatusEffectType) 2;
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("SkillBubblespit");
      ability1.name = "Bubble Spit";
      ability1.description = "Inflict 1-2 Bubbles to the left ally's position and remove All Fire from the left ally's position.\nIncreases all Bubbles on both sides by 1.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Gray
      };
      ability1.effects = new Effect[4];
      ability1.effects[0] = new Effect( instance4, 1, new IntentType?((IntentType) 76443), AllySlots.Left);
      ability1.effects[1] = new Effect( instance6, 1, new IntentType?((IntentType) 212), AllySlots.Left);
      ability1.effects[2] = new Effect( ScriptableObject.CreateInstance<IncreaseBubblesEffect>(), 1, new IntentType?((IntentType) 104), AllySlots.AllPartyMembers);
      ability1.effects[3] = new Effect( ScriptableObject.CreateInstance<IncreaseBubblesEffect>(), 1, new IntentType?((IntentType) 104), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }));
      ability1.animationTarget = AllySlots.Left;
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("SkillBubblespit");
      ability2.name = "Bubble Spew";
      ability2.description = "Inflict 2 Bubbles to the left ally's position and remove All Fire from the left ally's position.\nIncreases all Bubbles on both sides by 1.";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Gray
      };
      ability2.effects = new Effect[4];
      ability2.effects[0] = new Effect( ScriptableObject.CreateInstance<ApplyBubblesEffect>(), 2, new IntentType?((IntentType) 76443), AllySlots.Left);
      ability2.effects[1] = new Effect( instance6, 1, new IntentType?((IntentType) 212), AllySlots.Left);
      ability2.effects[2] = new Effect( ScriptableObject.CreateInstance<IncreaseBubblesEffect>(), 1, new IntentType?((IntentType) 104), AllySlots.AllPartyMembers);
      ability2.effects[3] = new Effect( ScriptableObject.CreateInstance<IncreaseBubblesEffect>(), 1, new IntentType?((IntentType) 104), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }));
      ability2.animationTarget = AllySlots.Left;
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Bubble Vomit";
      ability3.description = "Inflict 3 Bubbles to the left ally's position and remove All Fire from the left ally's position.\nIncreases all Bubbles on both sides by 1.";
      ability3.effects[0]._entryVariable = 3;
      Ability ability4 = ability2.Duplicate();
      ability4.name = "Bubble Breath";
      ability4.description = "Inflict 4 Bubbles to the left ally's position and remove All Fire from the left ally's position.\nIncreases all Bubbles on both sides by 1.";
      ability4.effects[0]._entryVariable = 4;
      SwapToOneSideEffect instance7 = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
      instance7._swapRight = true;
      SwapToOneSideEffect instance8 = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
      instance8._swapRight = false;
      TargettingUnitsEitherSide instance9 = ScriptableObject.CreateInstance<TargettingUnitsEitherSide>();
      instance9.getAllies = false;
      instance9.right = false;
      TargettingUnitsEitherSide instance10 = ScriptableObject.CreateInstance<TargettingUnitsEitherSide>();
      instance10.getAllies = false;
      instance10.right = true;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("SkillExpelTheFluids", 1);
      ability5.name = "Expel the Fluids";
      ability5.description = "Inflict 1-2 Bubbles to the opposing position. Moves All enemies closer to this party member.\nIncreases all Bubbles on the enemy side by 1-2.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Gray
      };
      ability5.effects = new Effect[4];
      ability5.effects[0] = new Effect( instance4, 1, new IntentType?((IntentType) 76443), Slots.Front);
      ability5.effects[1] = new Effect( instance8, 1, new IntentType?((IntentType) 42), (BaseCombatTargettingSO) instance10);
      ability5.effects[2] = new Effect( instance7, 1, new IntentType?((IntentType) 41), (BaseCombatTargettingSO) instance9);
      ability5.effects[3] = new Effect( instance5, 1, new IntentType?((IntentType) 104), ExtendedSlots.AllEnemies);
      ability5.animationTarget = Slots.Front;
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("SkillExpelTheFluids", 1);
      ability6.name = "Expel the Blood";
      ability6.description = "Inflict 2 Bubbles to the opposing position. Moves All enemies closer to this party member.\nIncreases all Bubbles on the enemy side by 2.";
      ability6.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Gray
      };
      ability6.effects = new Effect[4];
      ability6.effects[0] = new Effect( ScriptableObject.CreateInstance<ApplyBubblesEffect>(), 2, new IntentType?((IntentType) 76443), Slots.Front);
      ability6.effects[1] = new Effect( instance8, 1, new IntentType?((IntentType) 42), (BaseCombatTargettingSO) instance10);
      ability6.effects[2] = new Effect( instance7, 1, new IntentType?((IntentType) 41), (BaseCombatTargettingSO) instance9);
      ability6.effects[3] = new Effect( ScriptableObject.CreateInstance<IncreaseBubblesEffect>(), 2, new IntentType?((IntentType) 104), ExtendedSlots.AllEnemies);
      ability6.animationTarget = Slots.Front;
      ability6.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Expel the Essence";
      ability7.description = "Inflict 3 Bubbles to the opposing position. Moves All enemies closer to this party member.\nIncreases all Bubbles on the enemy side by 3.";
      ability7.effects[0]._entryVariable = 3;
      ability7.effects[3]._entryVariable = 3;
      Ability ability8 = ability6.Duplicate();
      ability8.name = "Expel the Soul";
      ability8.description = "Inflict 4 Bubbles to the opposing position. Moves All enemies closer to this party member.\nIncreases all Bubbles on the enemy side by 4.";
      ability8.effects[0]._entryVariable = 4;
      ability8.effects[3]._entryVariable = 4;
      ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>().possibleMana = new ManaColorSO[4]
      {
        Pigments.Red,
        Pigments.Blue,
        Pigments.Yellow,
        Pigments.Purple
      };
      ApplyBubblesEffect instance11 = ScriptableObject.CreateInstance<ApplyBubblesEffect>();
      instance11.doChance = true;
      instance11.chance = 40;
      ApplyBubblesEffect instance12 = ScriptableObject.CreateInstance<ApplyBubblesEffect>();
      instance12.doChance = true;
      instance12.chance = 60;
      instance12._applyonethroughtwoFUCKYOUTEVLEVTHUMBSDOWNEMOJI = true;
      ApplyBubblesEffect instance13 = ScriptableObject.CreateInstance<ApplyBubblesEffect>();
      instance13.doChance = true;
      instance13.chance = 75;
      ApplyBubblesEffect instance14 = ScriptableObject.CreateInstance<ApplyBubblesEffect>();
      instance14.doChance = true;
      instance14.chance = 99;
      instance14._applyonethroughtwoFUCKYOUTEVLEVTHUMBSDOWNEMOJI = true;
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("SkillRainyDay", 1);
      ability9.name = "Rainy Day";
      ability9.description = "40% chance to Inflict 1 Bubbles to the Left, Right, and Opposing Enemies and Ally positions.";
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Gray,
        Pigments.Gray,
        Pigments.Gray
      };
      ability9.effects = new Effect[3];
      ability9.effects[0] = new Effect( instance11, 1, new IntentType?((IntentType) 76443), Slots.FrontLeftRight);
      ability9.effects[1] = new Effect( instance11, 1, new IntentType?((IntentType) 76443), Slots.SlotTarget(new int[2]
      {
        -1,
        1
      }, true));
      ability9.effects[2] = new Effect( CasterRootActionEffect.Create(new Effect[1]
      {
        new Effect(ability9.effects[1]._effect, 1, new IntentType?((IntentType) 76443), Slots.Self)
      }), 1, new IntentType?((IntentType) 76443), Slots.Self);
      ability9.animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create(Slots.FrontLeftRight, Slots.SlotTarget(new int[3]
      {
        -1,
        0,
        1
      }, true));
      ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Rainy Dusk";
      ability10.description = "60% chance to Inflict 1-2 Bubbles to the Left, Right, and Opposing Enemies and Ally positions.";
      ability10.effects[0] = new Effect( instance12, 1, new IntentType?((IntentType) 76443), Slots.FrontLeftRight);
      ability10.effects[1] = new Effect( instance12, 1, new IntentType?((IntentType) 76443), Slots.SlotTarget(new int[2]
      {
        -1,
        1
      }, true));
      ability10.effects[2] = new Effect( CasterRootActionEffect.Create(new Effect[1]
      {
        new Effect(ability10.effects[1]._effect, 1, new IntentType?((IntentType) 76443), Slots.Self)
      }), 1, new IntentType?((IntentType) 76443), Slots.Self);
      Ability ability11 = new Ability();
      ability11.sprite = ResourceLoader.LoadSprite("SkillRainyDay", 1);
      ability11.name = "Rainy Night";
      ability11.description = "75% chance to Inflict 2 Bubbles to the Left, Right, and Opposing Enemies and Ally positions.";
      ability11.cost = new ManaColorSO[3]
      {
        Pigments.Gray,
        Pigments.Gray,
        Pigments.Gray
      };
      ability11.effects = new Effect[3];
      ability11.effects[0] = new Effect( instance13, 2, new IntentType?((IntentType) 76443), Slots.FrontLeftRight);
      ability11.effects[1] = new Effect( instance13, 2, new IntentType?((IntentType) 76443), Slots.SlotTarget(new int[2]
      {
        -1,
        1
      }, true));
      ability11.effects[2] = new Effect( CasterRootActionEffect.Create(new Effect[1]
      {
        new Effect(ability11.effects[1]._effect, 2, new IntentType?((IntentType) 76443), Slots.Self)
      }), 2, new IntentType?((IntentType) 76443), Slots.Self);
      ability11.animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create(Slots.FrontLeftRight, Slots.SlotTarget(new int[3]
      {
        -1,
        0,
        1
      }, true));
      ability11.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;
      Ability ability12 = ability9.Duplicate();
      ability12.name = "Rainy Eternity";
      ability12.description = "99% chance to Inflict 2-3 Bubbles to the Left, Right, and Opposing Enemies and Ally positions.";
      ability12.effects[0] = new Effect( instance14, 2, new IntentType?((IntentType) 76443), Slots.FrontLeftRight);
      ability12.effects[1] = new Effect( instance14, 2, new IntentType?((IntentType) 76443), Slots.SlotTarget(new int[2]
      {
        -1,
        1
      }, true));
      ability12.effects[2] = new Effect( CasterRootActionEffect.Create(new Effect[1]
      {
        new Effect(ability12.effects[1]._effect, 2, new IntentType?((IntentType) 76443), Slots.Self)
      }), 2, new IntentType?((IntentType) 76443), Slots.Self);
      character.AddLevel(11, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(14, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(16, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(19, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.ignoredAbilities = new List<int>() { 0 };
      character.AddCharacter();
      BubbleBlower.Retard = character;
    }
  }
}
