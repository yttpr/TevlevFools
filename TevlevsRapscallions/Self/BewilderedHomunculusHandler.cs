// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.BewilderedHomunculusHandler
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class BewilderedHomunculusHandler
  {
    public static BasePassiveAbilitySO passive;

    public static PassiveAbilityTypes gil2 => (PassiveAbilityTypes) 772201;

    public static void Add()
    {
      PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance)._passiveName = "Gilbert";
      ((BasePassiveAbilitySO) instance)._enemyDescription = "This enemy is Gilbert.";
      ((BasePassiveAbilitySO) instance)._characterDescription = "This character is Gilbert.";
      ((BasePassiveAbilitySO) instance).type = BewilderedHomunculusHandler.gil2;
      ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 1000
      };
      ((BasePassiveAbilitySO) instance).doesPassiveTriggerInformationPanel = false;
      ((BasePassiveAbilitySO) instance).conditions = new EffectorConditionSO[0];
      instance.effects = new EffectInfo[0];
      ((BasePassiveAbilitySO) instance).passiveIcon = ShitBurg.Gilby.passiveIcon;
      BewilderedHomunculusHandler.passive = (BasePassiveAbilitySO) instance;
      Enemy enemy = new Enemy()
      {
        name = "Gilbert",
        health = UnityEngine.Random.Range(1, 100),
        size = 1,
        entityID = (EntityIDs) 3822708,
        healthColor = Pigments.Red,
        priority = 0,
        prefab = ShitBurg.Bilbert
      };
      enemy.prefab._gibs = ShitBurg.Giblert;
      enemy.prefab.SetDefaultParams();
      enemy.enemyID = "ExplosiveGilbert_EN";
      enemy.combatSprite = ResourceLoader.LoadSprite("GilbertIcon.png");
      enemy.overworldAliveSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.overworldDeadSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").damageSound;
      enemy.deathSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").deathSound;
      enemy.abilitySelector = (BaseAbilitySelectorSO) ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
      enemy.passives = new BasePassiveAbilitySO[3]
      {
        (BasePassiveAbilitySO) instance,
        Passives.Formless,
        Passives.Withering
      };
      Ability ability1 = new Ability();
      ability1.name = "March for No Reason";
      ability1.description = "This enemy forfeits its turn.";
      ability1.rarity = 15;
      ability1.visuals = (AttackVisualsSO) null;
      ability1.animationTarget = Slots.Self;
      ability1.effects = new Effect[0];
      Ability ability2 = new Ability();
      ability2.name = "Epitaph";
      ability2.description = "Deal half of this enemy's maximum health to a random enemy that isn't Gilbert. Instantly kill this enemy.";
      ability2.rarity = 5;
      ability2.visuals = (AttackVisualsSO) null;
      ability2.animationTarget = Slots.Self;
      ability2.effects = new Effect[2];
      ability2.effects[0] = new Effect((EffectSO) EZEffects.GetVisuals<HalfMaxHealthDamageRandomEffect>("Crush_A", false, Slots.Self), 1, new IntentType?((IntentType) 2), (BaseCombatTargettingSO) EZEffects.TargetSide<TargettingBy_NotGilbert>(true, false));
      ability2.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, new IntentType?((IntentType) 6), Slots.Self);
      enemy.abilities = new Ability[2]{ ability1, ability2 };
      enemy.AddEnemy();
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("EnemyDeath", ~BindingFlags.Default), typeof (BewilderedHomunculusHandler).GetMethod("EnemyDeath", ~BindingFlags.Default));
    }

    public static bool ItemExists(IUnit killer)
    {
      return killer is CharacterCombat characterCombat && characterCombat.HasUsableItem && characterCombat.HeldItem._itemName.Contains("Bewildered Homunculus");
    }

    public static bool AnyItemExists()
    {
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        if (characterCombat.HasUsableItem && characterCombat.HeldItem._itemName.Contains("Bewildered Homunculus"))
          return true;
      }
      return false;
    }

    public static void EnemyDeath(
      Action<EnemyCombat, DeathReference, DeathType> orig,
      EnemyCombat self,
      DeathReference deathReference,
      DeathType deathType)
    {
      int slotId = self.SlotID;
      orig(self, deathReference, deathType);
      try
      {
        if (((IEnumerable<BasePassiveAbilitySO>) self.Enemy.passiveAbilities).Contains<BasePassiveAbilitySO>(ShitBurg.Gilby) || ((IEnumerable<BasePassiveAbilitySO>) self.Enemy.passiveAbilities).Contains<BasePassiveAbilitySO>(BewilderedHomunculusHandler.passive) || !BewilderedHomunculusHandler.AnyItemExists() || !LoadedAssetsHandler.LoadedEnemies.ContainsKey("ExplosiveGilbert_EN") || deathReference.witheringDeath || !CombatManager.Instance._stats.EnemiesAlive)
          return;
        CombatManager.Instance.AddSubAction((CombatAction) new RootActionAction((CombatAction) new SpawnEnemyExplodeGilbertAction(LoadedAssetsHandler.GetEnemy("ExplosiveGilbert_EN"), slotId, false, true, (SpawnType) 1, self.MaximumHealth)));
      }
      catch
      {
        Debug.LogWarning((object) "probably withering or somefuckshit");
      }
    }
  }
}
