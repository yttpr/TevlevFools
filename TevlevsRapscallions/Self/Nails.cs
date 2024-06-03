// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Nails
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class Nails
  {
    public static Character Nail;

    public static void Add()
    {
      Character character = new Character();
      character.name = nameof (Nails);
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 798293;
      character.levels = new CharacterRankedData[4];
      character.frontSprite = ResourceLoader.LoadSprite("NailsFront");
      character.backSprite = ResourceLoader.LoadSprite("NailsBack");
      character.overworldSprite = ResourceLoader.LoadSprite("NailsOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = ResourceLoader.LoadSprite("NailsMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("NailsMenu");
      character.menuChar = true;
      character.usesBaseAbility = true;
      character.isSupport = true;
      character.usesAllAbilities = false;
      character.appearsInShops = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").dxSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        Passives.Delicate
      };
      ScriptableObject.CreateInstance<DamageEffect>()._indirect = true;
      HealEffect instance = ScriptableObject.CreateInstance<HealEffect>();
      instance.usePreviousExitValue = true;
      Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("SkillNailing", 1);
      ability1.name = "Art of Pain";
      ability1.description = "Deal 2 damage to the Left ally.\nHeal this party member and the Left ally for the amount of damage done.\nMake Left ally perform a random ability.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect( ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?((IntentType) 0), AllySlots.Left);
      ability1.effects[1] = new Effect( instance, 1, new IntentType?((IntentType) 20), AllySlots.SelfLeft);
      ability1.effects[2] = new Effect( ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?((IntentType) 100), AllySlots.Left);
      ability1.animationTarget = AllySlots.Left;
      ability1.visuals = LoadedAssetsHandler.GetCharcater("Fennec_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("SkillNailing", 1);
      ability2.name = "Art of Misery";
      ability2.description = "Deal 3 damage to the Left ally.\nHeal this party member and the Left ally for the amount of damage done.\nMake Left ally perform a random ability.";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect( ScriptableObject.CreateInstance<DamageEffect>(), 3, new IntentType?((IntentType) 1), AllySlots.Left);
      ability2.effects[1] = new Effect( instance, 1, new IntentType?((IntentType) 20), AllySlots.SelfLeft);
      ability2.effects[2] = new Effect( ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?((IntentType) 100), AllySlots.Left);
      ability2.animationTarget = AllySlots.Left;
      ability2.visuals = LoadedAssetsHandler.GetCharcater("Fennec_CH").rankedData[0].rankAbilities[1].ability.visuals;
      ScriptableObject.CreateInstance<ApplyScarsIfRutpuredEffect>()._NailsRandomEffect = true;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("SkillNailing", 1);
      ability3.name = "Art of Torment";
      ability3.description = "Deal 5 damage to the Left ally.\nHeal this party member and the Left ally for the amount of damage done.\nMake Left ally perform a random ability.";
      ability3.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability3.effects = new Effect[3];
      ability3.effects[0] = new Effect( ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?((IntentType) 1), AllySlots.Left);
      ability3.effects[1] = new Effect( instance, 1, new IntentType?((IntentType) 20), AllySlots.SelfLeft);
      ability3.effects[2] = new Effect( ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?((IntentType) 100), AllySlots.Left);
      ability3.animationTarget = AllySlots.Left;
      ability3.visuals = LoadedAssetsHandler.GetCharcater("Fennec_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability4 = new Ability();
      ability4.sprite = ResourceLoader.LoadSprite("SkillNailing", 1);
      ability4.name = "Art of War";
      ability4.description = "Deal 6 damage to the Left ally.\nHeal this party member and the Left ally for the amount of damage done.\nMake Left ally perform a random ability.";
      ability4.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability4.effects = new Effect[3];
      ability4.effects[0] = new Effect( ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?((IntentType) 1), AllySlots.Left);
      ability4.effects[1] = new Effect( instance, 1, new IntentType?((IntentType) 20), AllySlots.SelfLeft);
      ability4.effects[2] = new Effect( ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?((IntentType) 100), AllySlots.Left);
      ability4.animationTarget = AllySlots.Left;
      ability4.visuals = LoadedAssetsHandler.GetCharcater("Fennec_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("SkillOrderCharge", 1);
      ability5.name = "Order, Do Something!";
      ability5.description = "Refresh the Right ally abilities. Inflicts 1 scar to the right ally and heal them for their amount of Scars.\n20% chance to refresh this party member's abilities.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Purple
      };
      ability5.effects = new Effect[4];
      ability5.effects[0] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability5.effects[1] = new Effect( ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?((IntentType) 159), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability5.effects[2] = new Effect( ScriptableObject.CreateInstance<HealBasedOnStatusEffect>(), 1, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability5.effects[3] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self,  Conditions.Chance(20));
      ability5.animationTarget = Slots.Front;
      ability5.visuals = LoadedAssetsHandler.GetCharcater("Clive_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("SkillOrderCharge", 1);
      ability6.name = "Order, Attack!";
      ability6.description = "Refresh the Right ally abilities. Inflicts 1 scar to the right ally and heal them for their amount of Scars.\n25% chance to refresh this party member's abilities.";
      ability6.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Purple
      };
      ability6.effects = new Effect[4];
      ability6.effects[0] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability6.effects[1] = new Effect( ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?((IntentType) 159), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability6.effects[2] = new Effect( ScriptableObject.CreateInstance<HealBasedOnStatusEffect>(), 1, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability6.effects[3] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self,  Conditions.Chance(25));
      ability6.animationTarget = Slots.SlotTarget(new int[1]
      {
        1
      }, true);
      ability6.visuals = LoadedAssetsHandler.GetCharcater("Clive_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability7 = new Ability();
      ability7.sprite = ResourceLoader.LoadSprite("SkillOrderCharge", 1);
      ability7.name = "Order, Charge!";
      ability7.description = "Refresh the Right ally abilities. Inflicts 1 scar to the right ally and heal them for their amount of Scars.\n30% chance to refresh this party member's abilities.";
      ability7.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Purple
      };
      ability7.effects = new Effect[4];
      ability7.effects[0] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability7.effects[1] = new Effect( ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?((IntentType) 159), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability7.effects[2] = new Effect( ScriptableObject.CreateInstance<HealBasedOnStatusEffect>(), 1, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability7.effects[3] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self,  Conditions.Chance(30));
      ability7.animationTarget = Slots.SlotTarget(new int[1]
      {
        1
      }, true);
      ability7.visuals = LoadedAssetsHandler.GetCharcater("Clive_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability8 = new Ability();
      ability8.sprite = ResourceLoader.LoadSprite("SkillOrderCharge", 1);
      ability8.name = "Order, KILL!";
      ability8.description = "Refresh the Right ally abilities. Inflicts 1 scar to the right ally and heal them for their amount of Scars.\n40% chance to refresh this party member's abilities.";
      ability8.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Purple
      };
      ability8.effects = new Effect[4];
      ability8.effects[0] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability8.effects[1] = new Effect( ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?((IntentType) 159), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability8.effects[2] = new Effect( ScriptableObject.CreateInstance<HealBasedOnStatusEffect>(), 1, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability8.effects[3] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self,  Conditions.Chance(40));
      ability8.animationTarget = Slots.SlotTarget(new int[1]
      {
        1
      }, true);
      ability8.visuals = LoadedAssetsHandler.GetCharcater("Clive_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("SkillOrderRetreat", 1);
      ability9.name = "Order, Run!";
      ability9.description = "Refreshes this party member and the Left and Right allies' movement.\nHeal all allies 1-2 health.\n30% chance to refresh this party member's abilites.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability9.effects = new Effect[4];
      ability9.effects[0] = new Effect( ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, new IntentType?((IntentType) 85), AllySlots.LeftRight);
      ability9.effects[1] = new Effect( ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Self);
      ability9.effects[2] = new Effect( ScriptableObject.CreateInstance<RandomHealBetweenPreviousAndEntryEffect>(), 2, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[9]
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
      }, true));
      ability9.effects[3] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self,  Conditions.Chance(30));
      ability9.animationTarget = Slots.SlotTarget(new int[2]
      {
        -1,
        1
      }, true);
      ability9.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[1].ability.visuals;
      Ability ability10 = new Ability();
      ability10.sprite = ResourceLoader.LoadSprite("SkillOrderRetreat", 1);
      ability10.name = "Order, Move!";
      ability10.description = "Refreshes all allies' movement.\nHeal all allies 2-3 health.\n35% chance to refresh this party member's abilites.";
      ability10.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability10.effects = new Effect[4];
      ability10.effects[0] = new Effect( ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.SlotTarget(new int[9]
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
      }, true));
      ability10.effects[1] = new Effect( ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 2, new IntentType?(), Slots.Self);
      ability10.effects[2] = new Effect( ScriptableObject.CreateInstance<RandomHealBetweenPreviousAndEntryEffect>(), 3, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[9]
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
      }, true));
      ability10.effects[3] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self,  Conditions.Chance(35));
      ability10.animationTarget = Slots.SlotTarget(new int[2]
      {
        -1,
        1
      }, true);
      ability10.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[1].ability.visuals;
      Ability ability11 = new Ability();
      ability11.sprite = ResourceLoader.LoadSprite("SkillOrderRetreat", 1);
      ability11.name = "Order, Scatter!";
      ability11.description = "Refreshes all allies' movement.\nHeal all allies 2-4 health.\n40% chance to refresh this party member's abilites.";
      ability11.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability11.effects = new Effect[4];
      ability11.effects[0] = new Effect( ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.SlotTarget(new int[9]
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
      }, true));
      ability11.effects[1] = new Effect( ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 2, new IntentType?(), Slots.Self);
      ability11.effects[2] = new Effect( ScriptableObject.CreateInstance<RandomHealBetweenPreviousAndEntryEffect>(), 4, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[9]
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
      }, true));
      ability11.effects[3] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self,  Conditions.Chance(40));
      ability11.animationTarget = Slots.SlotTarget(new int[2]
      {
        -1,
        1
      }, true);
      ability11.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[1].ability.visuals;
      Ability ability12 = new Ability();
      ability12.sprite = ResourceLoader.LoadSprite("SkillOrderRetreat", 1);
      ability12.name = "Order, Retreat!";
      ability12.description = "Refreshes all allies' movement.\nHeal all allies 2-6 health.\n50% chance to refresh this party member's abilites.";
      ability12.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability12.effects = new Effect[4];
      ability12.effects[0] = new Effect( ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.SlotTarget(new int[3]
      {
        -1,
        0,
        1
      }, true));
      ability12.effects[1] = new Effect( ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 2, new IntentType?(), Slots.Self);
      ability12.effects[2] = new Effect( ScriptableObject.CreateInstance<RandomHealBetweenPreviousAndEntryEffect>(), 6, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[9]
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
      }, true));
      ability12.effects[3] = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self,  Conditions.Chance(50));
      ability12.animationTarget = Slots.SlotTarget(new int[2]
      {
        -1,
        1
      }, true);
      ability12.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[1].ability.visuals;
      character.AddLevel(9, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(12, new Ability[3]
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
      character.AddLevel(18, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Nails.Nail = character;
    }
  }
}
