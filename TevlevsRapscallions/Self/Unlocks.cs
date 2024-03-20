// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Unlocks
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class Unlocks
  {
    private static bool debugging => tevlevsRapscallions.Debugging;

    public static UnlockableID start => (UnlockableID) 343102;

    public static Achievement ach => (Achievement) Unlocks.start;

    public static void Add()
    {
      EZExtensions.PCall(new Action(FoolBossUnlockSystem.Setup), "Fool boss unlocks");
      EZExtensions.PCall(new Action(HooksGeneral.Setup), "generic hooks");
      EZExtensions.PCall(new Action(Unlocks.Brian), "brian unlocks");
      EZExtensions.PCall(new Action(Unlocks.Carpy), "carpy unlocks");
      EZExtensions.PCall(new Action(Unlocks.Nials), "nails unlocks");
      EZExtensions.PCall(new Action(Unlocks.ShitMeat), "meatshot unlocks");
      EZExtensions.PCall(new Action(Unlocks.Dollar), "zensuke unlocks");
      EZExtensions.PCall(new Action(Unlocks.Buggy), "Lovebug unlocks");
      EZExtensions.PCall(new Action(Unlocks.Bub), "bubblefuck unlocks");
      EZExtensions.PCall(new Action(Unlocks.GibbleDibble), "gilbert unlocks");
    }

    public static void Template()
    {
      int num = 0;
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Speeding Ticket";
      heavenUnlock.flavorText = "\"Stop right there criminal scum!\"";
      heavenUnlock.description = "If an enemy moves more than twice in one turn, deal 8 damage and inflict 2 Constricted on them.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("SpeedingTicket.png");
      heavenUnlock.unlockableID = (UnlockableID) (Unlocks.start + num);
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.shopPrice = 5;
      heavenUnlock.startsLocked = false;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.namePopup = false;
      heavenUnlock.trigger = (TriggerCalls) 1000;
      heavenUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<SpeederCondition>()
      };
      heavenUnlock.immediate = false;
      heavenUnlock.effects = new Effect[0];
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      DoubleEffectItem osmanUnlock = new DoubleEffectItem();
      osmanUnlock.name = "Skull Banksy";
      osmanUnlock.flavorText = "\"Are we the baddies?\"";
      osmanUnlock.description = "Increase this party member's damage by 0-10. On killing an enemy, take 0-10 damage.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("SkullBanksy.png");
      osmanUnlock.unlockableID = (UnlockableID) (Unlocks.start + 100 + num);
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 8;
      osmanUnlock.startsLocked = false;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.namePopup = true;
      osmanUnlock.trigger = (TriggerCalls) 16;
      osmanUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<BaddiesCondition>()
      };
      osmanUnlock._firsteEffectImmediate = true;
      osmanUnlock.firstPopUp = false;
      osmanUnlock.firstEffects = new Effect[0];
      osmanUnlock.secondEffects = new Effect[1]
      {
        new Effect((EffectSO) DamageEffect0ToEntry.Create(false), 10, new IntentType?(), Slots.Self)
      };
      osmanUnlock.secondPopUp = true;
      osmanUnlock.SecondTrigger = new TriggerCalls[1]
      {
        (TriggerCalls) 24
      };
      osmanUnlock.secondTriggerConditions = new EffectorConditionSO[0];
      osmanUnlock._secondImmediateEffect = false;
      if (Unlocks.debugging)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        Character cop = Brain.Cop;
        new FoolBossUnlockSystem.FoolItemPairs(cop, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + num), (AchievementUnlockType) 5, "Speeding Ticket", "Unlocked a new item.", ResourceLoader.LoadSprite("SpeedingTicketUnlockBG.png")).Prepare(cop.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 100 + num), (AchievementUnlockType) 4, "Skull Banksy", "Unlocked a new item.", ResourceLoader.LoadSprite("SkullBanksyUnlockBG.png")).Prepare(cop.entityID, (BossType) 9);
      }
    }

    public static void Brian()
    {
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Speeding Ticket";
      heavenUnlock.flavorText = "\"Stop right there criminal scum!\"";
      heavenUnlock.description = "If an enemy moves more than twice in one turn, deal 8 damage and inflict 2 Constricted on them.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("SpeedingTicket.png");
      heavenUnlock.unlockableID = (UnlockableID) (Unlocks.start + 1);
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.shopPrice = 5;
      heavenUnlock.startsLocked = false;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.namePopup = false;
      heavenUnlock.trigger = SpeederHandler.call;
      heavenUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<SpeederCondition>()
      };
      heavenUnlock.immediate = false;
      heavenUnlock.effects = new Effect[0];
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      DoubleEffectItem osmanUnlock = new DoubleEffectItem();
      osmanUnlock.name = "Skull Banksy";
      osmanUnlock.flavorText = "\"Are we the baddies?\"";
      osmanUnlock.description = "Increase this party member's damage by 0-10. On killing an enemy, take 0-10 damage.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("SkullBanksy.png");
      osmanUnlock.unlockableID = (UnlockableID) (Unlocks.start + 101);
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 8;
      osmanUnlock.startsLocked = false;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.namePopup = true;
      osmanUnlock.trigger = (TriggerCalls) 16;
      osmanUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<BaddiesCondition>()
      };
      osmanUnlock._firsteEffectImmediate = true;
      osmanUnlock.firstPopUp = false;
      osmanUnlock.firstEffects = new Effect[0];
      osmanUnlock.secondEffects = new Effect[1]
      {
        new Effect((EffectSO) DamageEffect0ToEntry.Create(false), 10, new IntentType?(), Slots.Self)
      };
      osmanUnlock.secondPopUp = true;
      osmanUnlock.SecondTrigger = new TriggerCalls[1]
      {
        (TriggerCalls) 24
      };
      osmanUnlock.secondTriggerConditions = new EffectorConditionSO[0];
      osmanUnlock._secondImmediateEffect = false;
      if (Unlocks.debugging)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(Brain.Cop, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 1), (AchievementUnlockType) 5, "Speeding Ticket", "Unlocked a new item.", ResourceLoader.LoadSprite("SpeedingTicketUnlockBG.png")).Prepare(Brain.Cop.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 101), (AchievementUnlockType) 4, "Skull Banksy", "Unlocked a new item.", ResourceLoader.LoadSprite("SkullBanksyUnlockBG.png")).Prepare(Brain.Cop.entityID, (BossType) 9);
      }
    }

    public static void Carpy()
    {
      EffectItem effectItem1 = new EffectItem();
      effectItem1.name = "Ocean Man";
      effectItem1.flavorText = "\"You caught a... Fish? It can roll.\"";
      effectItem1.description = "Upon performing an action inflict 10 random Status or Field effects on the Opposing enemy. This item is destroyed upon activation.";
      effectItem1.sprite = ResourceLoader.LoadSprite("OceanMan.png");
      effectItem1.unlockableID = (UnlockableID) (Unlocks.start + 2);
      effectItem1.itemPools = ItemPools.Fish;
      effectItem1.shopPrice = 2;
      effectItem1.startsLocked = false;
      effectItem1.consumedOnUse = true;
      effectItem1.consumeTrigger = (TriggerCalls) 1000;
      effectItem1.consumeConditions = new EffectorConditionSO[0];
      effectItem1.namePopup = true;
      effectItem1.trigger = (TriggerCalls) 14;
      effectItem1.triggerConditions = new EffectorConditionSO[0];
      effectItem1.immediate = false;
      ApplyRandomStatusEffectEffect instance1 = ScriptableObject.CreateInstance<ApplyRandomStatusEffectEffect>();
      instance1._repeatAmount = 10;
      effectItem1.effects = new Effect[1]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Front)
      };
      effectItem1.equippedModifiers = new WearableStaticModifierSetterSO[0];
      Ability ability = new Ability();
      ability.name = "Pescetarian Pierce";
      ability.description = "Deal 8-16 damage to the Opposing enemy. Deal double if the Opposing enemy is a Fish. \nThis ability fails if the character does not have a usable item.";
      ability.sprite = ResourceLoader.LoadSprite("PescatarianPierceSkill.png");
      ability.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability.visuals = LoadedAssetsHandler.LoadEnemyAbility("Domination_A").visuals;
      ability.animationTarget = Slots.Front;
      ability.effects = new Effect[1];
      ability.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<FishItemDamageEffect>(), 16, new IntentType?((IntentType) 4), Slots.Front, (EffectConditionSO) ScriptableObject.CreateInstance<HasUsableItemCondition>());
      ExtraAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
      instance2._extraAbility = ability.CharacterAbility();
      //EZExtensions.AddToDollPool((WearableStaticModifierSetterSO) instance2);
      EffectItem effectItem2 = new EffectItem();
      effectItem2.name = "Jumblus";
      effectItem2.flavorText = "\"En Garde!\"";
      effectItem2.description = "Adds the ability \"Pescatarian Pierce\", a vanishing powerful ability.\nOn turn end 33% chance to destroy this item.";
      effectItem2.sprite = ResourceLoader.LoadSprite("Jumblus.png");
      effectItem2.unlockableID = (UnlockableID) (Unlocks.start + 102);
      effectItem2.itemPools = ItemPools.Fish;
      effectItem2.shopPrice = 4;
      effectItem2.startsLocked = false;
      effectItem2.consumedOnUse = false;
      effectItem2.consumeTrigger = (TriggerCalls) 7;
      effectItem2.consumeConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) EZEffects.Condition<PercentageEffectorCondition>(33)
      };
      effectItem2.namePopup = false;
      effectItem2.trigger = (TriggerCalls) 1000;
      effectItem2.triggerConditions = new EffectorConditionSO[0];
      effectItem2.immediate = false;
      effectItem2.effects = new Effect[0];
      effectItem2.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance2
      };
      if (Unlocks.debugging)
      {
        effectItem1.AddItem();
        FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item) effectItem1), 3);
        effectItem2.AddItem();
        FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item) effectItem2), 1);
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(TevlevsRapscallions.Carpy.Fish, (Item) effectItem1, (Item) effectItem2, 3, 1).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 2), (AchievementUnlockType) 5, "Ocean Man", "Unlocked a new item.", ResourceLoader.LoadSprite("OceanManUnlockBG.png")).Prepare(TevlevsRapscallions.Carpy.Fish.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 102), (AchievementUnlockType) 4, "Jumblus", "Unlocked a new item.", ResourceLoader.LoadSprite("JumblusUnlockBG.png")).Prepare(TevlevsRapscallions.Carpy.Fish.entityID, (BossType) 9);
      }
    }

    public static void Nials()
    {
      int num = 3;
      Ability ability = new Ability();
      ability.name = "Meatgrind";
      ability.description = "Deal 0-8 damage and inflict 1-3 Ruptured on the Opposing enemy, this attack ignores Shield. \nRepeat this 3 times.";
      ability.sprite = ResourceLoader.LoadSprite("MeatgrindSkill.png");
      ability.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability.visuals = (AttackVisualsSO) null;
      ability.animationTarget = Slots.Front;
      MultiAnimationEffect instance1 = ScriptableObject.CreateInstance<MultiAnimationEffect>();
      instance1.visuals = new AnimationVisualsEffect[4]
      {
        EZEffects.GetVisuals<AnimationVisualsEffect>("Purify_1_A", true, Slots.Front),
        EZEffects.GetVisuals<AnimationVisualsEffect>("Domination_A", false, Slots.Front),
        EZEffects.GetVisuals<AnimationVisualsEffect>("Cacophony_1_A", true, Slots.Front),
        EZEffects.GetVisuals<AnimationVisualsEffect>("Expire_1_A", true, Slots.Front)
      };
      DamageEffect0ToEntry effect1 = DamageEffect0ToEntry.Create(true);
      effect1.IgnoreShield = true;
      CasterSubActionEffect effect2 = CasterSubActionEffect.Create(new Effect[3]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Front),
        new Effect((EffectSO) effect1, 8, new IntentType?((IntentType) 2), Slots.Front),
        new Effect((EffectSO) ScriptableObject.CreateInstance<Rupture1ToEntryEffect>(), 3, new IntentType?((IntentType) 151), Slots.Front)
      });
      ability.effects = new Effect[6];
      ability.effects[0] = new Effect((EffectSO) effect2, 1, new IntentType?((IntentType) 2), Slots.Front);
      ability.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?((IntentType) 151), Slots.Front);
      ability.effects[2] = ability.effects[0];
      ability.effects[3] = ability.effects[1];
      ability.effects[4] = ability.effects[0];
      ability.effects[5] = ability.effects[1];
      ExtraAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
      instance2._extraAbility = ability.CharacterAbility();
      EZExtensions.AddToDollPool((WearableStaticModifierSetterSO) instance2);
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Meatgrinder";
      heavenUnlock.flavorText = "\"A violent and fierce weapon.\"";
      heavenUnlock.description = "Adds \"Meatgrind\" as an additional ability, an inconsistent rampaging rupture attack.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("Meatgrinder.png");
      heavenUnlock.unlockableID = (UnlockableID) (Unlocks.start + num);
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 4;
      heavenUnlock.startsLocked = false;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.namePopup = false;
      heavenUnlock.trigger = (TriggerCalls) 1000;
      heavenUnlock.triggerConditions = new EffectorConditionSO[0];
      heavenUnlock.immediate = false;
      heavenUnlock.effects = new Effect[0];
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance2
      };
      HealthColorChange_Wearable_SMS instance3 = ScriptableObject.CreateInstance<HealthColorChange_Wearable_SMS>();
      instance3._healthColor = Pigments.Red;
      DoubleEffectItem osmanUnlock = new DoubleEffectItem();
      osmanUnlock.name = "Old Lipstick";
      osmanUnlock.flavorText = "\"Keep your beauty on duty.\"";
      osmanUnlock.description = "This party member's health color is now Red. \nReduce incoming direct damage by 50%. On taking damage inflict 1-2 Ruptured on this party member.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("OldLipstick.png");
      osmanUnlock.unlockableID = (UnlockableID) (Unlocks.start + 100 + num);
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 4;
      osmanUnlock.startsLocked = false;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.namePopup = true;
      osmanUnlock.trigger = (TriggerCalls) 6;
      osmanUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<HalveDamageCondition>()
      };
      osmanUnlock._firsteEffectImmediate = true;
      osmanUnlock.firstPopUp = false;
      osmanUnlock.firstEffects = new Effect[0];
      osmanUnlock.secondEffects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<Rupture1ToEntryEffect>(), 2, new IntentType?(), Slots.Self)
      };
      osmanUnlock.secondPopUp = true;
      osmanUnlock.SecondTrigger = new TriggerCalls[1]
      {
        (TriggerCalls) 5
      };
      osmanUnlock.secondTriggerConditions = new EffectorConditionSO[0];
      osmanUnlock._secondImmediateEffect = false;
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance3
      };
      if (Unlocks.debugging)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        Character nail = Nails.Nail;
        new FoolBossUnlockSystem.FoolItemPairs(nail, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + num), (AchievementUnlockType) 5, "Meatgrinder", "Unlocked a new item.", ResourceLoader.LoadSprite("MeatgrinderUnlockBG.png")).Prepare(nail.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 100 + num), (AchievementUnlockType) 4, "Old Lipstick", "Unlocked a new item.", ResourceLoader.LoadSprite("OldLipstickUnlockBG.png")).Prepare(nail.entityID, (BossType) 9);
      }
    }

    public static void ShitMeat()
    {
      int num = 4;
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Throwing Darts";
      heavenUnlock.flavorText = "\"Throw them in the dark.\"";
      heavenUnlock.description = "Increase damage by 25%. All of this party member's attacks target random enemies.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("ThrowingDarts.png");
      heavenUnlock.unlockableID = (UnlockableID) (Unlocks.start + num);
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 8;
      heavenUnlock.startsLocked = false;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.namePopup = false;
      heavenUnlock.trigger = (TriggerCalls) 16;
      heavenUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<DamageInc25Condition>()
      };
      heavenUnlock.immediate = true;
      heavenUnlock.effects = new Effect[0];
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Rusty Mortar";
      osmanUnlock.flavorText = "\"Large hunk of iron.\"";
      osmanUnlock.description = "on Turn end deal 10 damage to the Leftmost Position. \nMove its targetting 1 position Right each turn looping back to its original position once the Rightmost position is reached.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("RustyMortar.png");
      osmanUnlock.unlockableID = (UnlockableID) (Unlocks.start + 100 + num);
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 8;
      osmanUnlock.startsLocked = false;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.namePopup = true;
      osmanUnlock.trigger = (TriggerCalls) 7;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<MortarCycleEffect>(), 10, new IntentType?(), Slots.SlotTarget(new int[9]
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
        }))
      };
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      if (Unlocks.debugging)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        Character gun = Meatshot.Gun;
        new FoolBossUnlockSystem.FoolItemPairs(gun, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + num), (AchievementUnlockType) 5, "Throwing Darts", "Unlocked a new item.", ResourceLoader.LoadSprite("ThrowingDartsUnlockBG.png")).Prepare(gun.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 100 + num), (AchievementUnlockType) 4, "Rusty Mortar", "Unlocked a new item.", ResourceLoader.LoadSprite("RustyMortarUnlockBG.png")).Prepare(gun.entityID, (BossType) 9);
      }
    }

    public static void Dollar()
    {
      int num = 5;
      DoubleEffectItem heavenUnlock = new DoubleEffectItem();
      heavenUnlock.name = "Sea Shells";
      heavenUnlock.flavorText = "\"Laws of supply and demand.\"";
      heavenUnlock.description = "Upon receiving any damage destroy this item and produce a random treasure item.\n25% chance to find a copy of this item at the end of combat if it hasn't been destroyed.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("Seashells.png");
      heavenUnlock.unlockableID = (UnlockableID) (Unlocks.start + num);
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 4;
      heavenUnlock.startsLocked = false;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.namePopup = false;
      heavenUnlock.trigger = (TriggerCalls) 31;
      heavenUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) EZEffects.Condition<PercentageEffectorCondition>(25)
      };
      ExtraLootOptionsEffect instance1 = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
      instance1._itemName = "SeaShells_TW";
      heavenUnlock.firstPopUp = true;
      heavenUnlock._firsteEffectImmediate = false;
      heavenUnlock.firstEffects = new Effect[1]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self)
      };
      heavenUnlock.SecondTrigger = new TriggerCalls[1]
      {
        (TriggerCalls) 5
      };
      heavenUnlock.secondTriggerConditions = new EffectorConditionSO[0];
      heavenUnlock.secondPopUp = false;
      heavenUnlock.secondEffects = new Effect[2]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<RandomShopTreasureItemEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.Self)
      };
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      EZExtensions.PCall(new Action(R4IN_DMG.Add), "rainer damager");
      CopyAndSpawnCustomCharacterAnywhereEffect instance2 = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
      instance2._characterCopy = "R4IN-DMG_CH";
      instance2._permanentSpawn = false;
      instance2._rank = 0;
      instance2._extraModifiers = new WearableStaticModifierSetterSO[0];
      Ability ability = new Ability();
      ability.name = "Remote Control";
      ability.description = "Make all allies with Construct perform 3 random abilites back to back.";
      ability.sprite = ResourceLoader.LoadSprite("RemoteControlSkill.png");
      ability.cost = new ManaColorSO[1]{ Pigments.Yellow };
      ability.visuals = LoadedAssetsHandler.LoadCharacterAbility("Slap_A").visuals;
      ability.animationTarget = Slots.Self;
      ability.effects = new Effect[3];
      ability.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?((IntentType) 100), (BaseCombatTargettingSO) EZEffects.TargetSide<TargetUnitsWithConstruct>(true, false));
      ability.effects[1] = new Effect(ability.effects[0]._effect, 1, new IntentType?(), ability.effects[0]._target);
      ability.effects[2] = ability.effects[1];
      ExtraAbility_Wearable_SMS instance3 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
      instance3._extraAbility = ability.CharacterAbility();
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Diver Artifact";
      osmanUnlock.flavorText = "\"War without reason.\"";
      osmanUnlock.description = "On combat start summon R4IN-DMG.\nThis party member now has \"Remote Control\" as an additional ability.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("DiverArtifact.png");
      osmanUnlock.unlockableID = (UnlockableID) (Unlocks.start + 100 + num);
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.startsLocked = false;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.namePopup = true;
      osmanUnlock.trigger = (TriggerCalls) 25;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
      };
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance3
      };
      if (Unlocks.debugging)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        Character sale = Zensuke.Sale;
        new FoolBossUnlockSystem.FoolItemPairs(sale, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + num), (AchievementUnlockType) 5, "Sea Shells", "Unlocked a new item.", ResourceLoader.LoadSprite("SeashellsUnlockBG.png")).Prepare(sale.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 100 + num), (AchievementUnlockType) 4, "Diver Artifact", "Unlocked a new item.", ResourceLoader.LoadSprite("DiverArtifactUnlockBG.png")).Prepare(sale.entityID, (BossType) 9);
      }
    }

    public static void Buggy()
    {
      int num = 6;
      DoubleEffectItem heavenUnlock = new DoubleEffectItem();
      heavenUnlock.name = "Scarab Jewel";
      heavenUnlock.flavorText = "\"Nibbling greed. Downfall of man.\"";
      heavenUnlock.description = "This party member is permanently Focused. At the start of each turn, inflict 3 Parasitism on this party member.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("ScarabJewel.png");
      heavenUnlock.unlockableID = (UnlockableID) (Unlocks.start + num);
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 5;
      heavenUnlock.startsLocked = false;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.namePopup = false;
      heavenUnlock.trigger = (TriggerCalls) 25;
      heavenUnlock.triggerConditions = new EffectorConditionSO[0];
      heavenUnlock.firstPopUp = false;
      heavenUnlock._firsteEffectImmediate = false;
      heavenUnlock.firstEffects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPermenantFocusedEffect>(), 1, new IntentType?(), Slots.Self)
      };
      heavenUnlock.SecondTrigger = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      heavenUnlock.secondTriggerConditions = new EffectorConditionSO[0];
      heavenUnlock.secondPopUp = true;
      heavenUnlock._secondImmediateEffect = false;
      heavenUnlock.secondEffects = new Effect[1]
      {
        new Effect((EffectSO) LoveBug.AddPara, 3, new IntentType?(), Slots.Self)
      };
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      EZExtensions.PCall(new Action(Scuttle.Minor), "maggot");
      EZExtensions.PCall(new Action(Scuttle.Major), "monkey");
      CopyAndSpawnCustomCharacterAnywhereEffect instance = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
      instance._characterCopy = "ScuttleMaggot_CH";
      instance._permanentSpawn = true;
      instance._rank = 0;
      instance._extraModifiers = new WearableStaticModifierSetterSO[0];
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Sea Monkeys";
      osmanUnlock.flavorText = "\"The world's only instant pets!\"";
      osmanUnlock.description = "At the beginning of combat summon as many ScuttleMaggots on the ally side as possible. This item is destroyed upon activation.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("SeaMonkeys.png");
      osmanUnlock.unlockableID = (UnlockableID) (Unlocks.start + 100 + num);
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 10;
      osmanUnlock.startsLocked = false;
      osmanUnlock.consumedOnUse = true;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.namePopup = true;
      osmanUnlock.trigger = (TriggerCalls) 25;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) instance, 5, new IntentType?(), Slots.Self)
      };
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      if (Unlocks.debugging)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        Character bug = LoveBug.Bug;
        new FoolBossUnlockSystem.FoolItemPairs(bug, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + num), (AchievementUnlockType) 5, "Scarab Jewel", "Unlocked a new item.", ResourceLoader.LoadSprite("ScarabJewelUnlockBG.png")).Prepare(bug.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 100 + num), (AchievementUnlockType) 4, "Sea Monkeys", "Unlocked a new item.", ResourceLoader.LoadSprite("SeaMonkeysUnlockBG.png")).Prepare(bug.entityID, (BossType) 9);
      }
    }

    public static void Bub()
    {
      int num = 7;
      EZExtensions.PCall(new Action(Pineapple.Setup), "wicked pinappel setlt up");
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Wicked Pineapple";
      heavenUnlock.flavorText = "\"That terrible Pineapple under the deep sea....\"";
      heavenUnlock.description = "At the start of each turn, inflict 1 Bubbles on this party member's position. \nAll Field effects are replaced with 50% Bubbles.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("WickedPineapple.png");
      heavenUnlock.unlockableID = (UnlockableID) (Unlocks.start + num);
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 8;
      heavenUnlock.startsLocked = false;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.namePopup = false;
      heavenUnlock.trigger = (TriggerCalls) 21;
      heavenUnlock.triggerConditions = new EffectorConditionSO[0];
      heavenUnlock.immediate = false;
      heavenUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyBubblesEffect>(), 1, new IntentType?(), Slots.Self)
      };
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      Ability ability = new Ability();
      ability.name = "Leander";
      ability.description = "Inflict 0-4 Bubbles to all enemy positions.\nInflict 0-2 Bubbles to all ally positions. ";
      ability.sprite = ResourceLoader.LoadSprite("SkillLeander.png");
      ability.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Blue
      };
      ability.visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;
      ability.animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create(Slots.SlotTarget(new int[9]
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
      }), Slots.SlotTarget(new int[9]
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
      ability.effects = new Effect[3];
      ability.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<Bubbles0ToEntryEffect>(), 4, new IntentType?((IntentType) 76443), Slots.SlotTarget(new int[9]
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
      ability.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 2, new IntentType?((IntentType) 76443), Slots.SlotTarget(new int[9]
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
      ability.effects[2] = new Effect((EffectSO) CasterRootActionEffect.Create(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<Bubbles0ToEntryEffect>(), 2, new IntentType?(), Slots.SlotTarget(new int[9]
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
        }, true))
      }), 2, new IntentType?(), Slots.Self);
      ExtraAbility_Wearable_SMS instance = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
      instance._extraAbility = ability.CharacterAbility();
      EZExtensions.AddToDollPool((WearableStaticModifierSetterSO) instance);
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Engulfed Nymph";
      osmanUnlock.flavorText = "\"Lover's tomb.\"";
      osmanUnlock.description = "Adds \"Leander\" as an additional ability, a random mass Bubbles based attack.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("EngulfedNymph.png");
      osmanUnlock.unlockableID = (UnlockableID) (Unlocks.start + 100 + num);
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 8;
      osmanUnlock.startsLocked = false;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.namePopup = true;
      osmanUnlock.trigger = (TriggerCalls) 1000;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[0];
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance
      };
      if (Unlocks.debugging)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        Character retard = BubbleBlower.Retard;
        new FoolBossUnlockSystem.FoolItemPairs(retard, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + num), (AchievementUnlockType) 5, "Wicked Pineapple", "Unlocked a new item.", ResourceLoader.LoadSprite("WickedPineappleUnlockBG.png")).Prepare(retard.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 100 + num), (AchievementUnlockType) 4, "Engulfed Nypmh", "Unlocked a new item.", ResourceLoader.LoadSprite("EngulfedNymphUnlockBG.png")).Prepare(retard.entityID, (BossType) 9);
      }
    }

    public static void GibbleDibble()
    {
      int num = 8;
      EZExtensions.PCall(new Action(BewilderedHomunculusHandler.Add), "bewlidered homuncolus");
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Bewildered Homunculus";
      heavenUnlock.flavorText = "\"Out for blood. Maybe.\"";
      heavenUnlock.description = "Upon killing an enemy, summon an Explosive Gilbert with the max health of the victim in its place.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("BewilderedHomunculus.png");
      heavenUnlock.unlockableID = (UnlockableID) (Unlocks.start + num);
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 5;
      heavenUnlock.startsLocked = false;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.namePopup = true;
      heavenUnlock.trigger = SpawnEnemyExplodeGilbertAction.Call;
      heavenUnlock.triggerConditions = new EffectorConditionSO[0];
      heavenUnlock.immediate = true;
      heavenUnlock.effects = new Effect[0];
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Starless";
      osmanUnlock.flavorText = "\"Sundown dazzling day.\"";
      osmanUnlock.description = "On Turn start replace one of this party member's moves with random party member moves of the same level.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("Starless.png");
      osmanUnlock.unlockableID = (UnlockableID) (Unlocks.start + 100 + num);
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 4;
      osmanUnlock.startsLocked = false;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.namePopup = true;
      osmanUnlock.trigger = (TriggerCalls) 21;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[3];
      osmanUnlock.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveRandomAbilityEffect>(), 1, new IntentType?(), Slots.Self);
      osmanUnlock.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<CharacterCasterAddRandomCharacterAbilityEffect>(), 1, new IntentType?(), Slots.Self);
      osmanUnlock.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<UpdateCharacterUIEffect>(), 1, new IntentType?(), Slots.Self);
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      if (Unlocks.debugging)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        Character itHim = ShitBurg.ItHim;
        new FoolBossUnlockSystem.FoolItemPairs(itHim, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + num), (AchievementUnlockType) 5, "Bewildered Homunculus", "Unlocked a new item.", ResourceLoader.LoadSprite("BewilderedHomunculusUnlockBG.png")).Prepare(itHim.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (Unlocks.ach + 100 + num), (AchievementUnlockType) 4, "Starless", "Unlocked a new item.", ResourceLoader.LoadSprite("StarlessUnlockBG.png")).Prepare(itHim.entityID, (BossType) 9);
      }
    }
  }
}
