// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GilbertExtended
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BepInEx;
using BrutalAPI;
using EnemyPack.Effects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class GilbertExtended
  {
    public static bool AddNewGilbert(
      this CombatStats self,
      EnemySO enemy,
      int slot,
      bool givesExperience,
      SpawnType spawnType,
      int hp)
    {
      int emptyEnemyFieldId = self.GetFirstEmptyEnemyFieldID();
      if (emptyEnemyFieldId == -1)
        return false;
      int count = self.Enemies.Count;
      int health = enemy.health;
      enemy.health = hp;
      EnemyCombat enemy1 = new EnemyCombat(count, emptyEnemyFieldId, enemy, givesExperience);
      self.Enemies.Add(count, enemy1);
      self.AddEnemyToField(count, emptyEnemyFieldId);
      self.combatSlots.AddEnemyToSlot((IUnit) enemy1, slot);
      self.timeline.AddEnemyToTimeline((ITurn) enemy1);
      CombatManager.Instance.AddUIAction((CombatAction) new EnemySpawnUIAction(enemy1.ID, spawnType));
      enemy1.ConnectPassives();
      enemy1.InitializationEnd();
      CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new GilbertAddExtraAbilitiesSpawnAction(enemy1), false);
      enemy.health = health;
      return true;
    }

    public static ExtraAbilityInfo gilbExtra(ExtraAbilityInfo info)
    {
      try
      {
        if (File.Exists(Paths.BepInExRootPath + "/Plugins/EnemyPack.dll"))
          return GilbertExtended.gilbExtraToiletPaper(info);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) "what the fuck");
      }
      ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo()
      {
        rarity = info.rarity,
        cost = info.cost,
        ability = UnityEngine.Object.Instantiate<AbilitySO>(info.ability)
      };
      extraAbilityInfo.ability._description = Regex.Replace(extraAbilityInfo.ability._description, "Opposing", "Left and Right");
      extraAbilityInfo.ability._description = Regex.Replace(extraAbilityInfo.ability._description, "opposing", "left and right");
      extraAbilityInfo.ability._locID = "";
      List<EffectInfo> effectInfoList = new List<EffectInfo>();
      foreach (EffectInfo effect in info.ability.effects)
      {
        EffectInfo effectInfo = new EffectInfo()
        {
          entryVariable = effect.entryVariable,
          effect = effect.effect,
          condition = effect.condition,
          targets = effect.targets != null ? (BaseCombatTargettingSO) GilbertFlipTargetting.Create(effect.targets) : Slots.Self
        };
        if (effectInfo.effect is PerformRandomAbilityFromCharacterEffect)
          effectInfo.effect =  PerformRandomAbilityFromCharacterSwapTargetsEffect.Instance;
        effectInfoList.Add(effectInfo);
      }
      extraAbilityInfo.ability.effects = effectInfoList.ToArray();
      extraAbilityInfo.ability.animationTarget = (BaseCombatTargettingSO) GilbertFlipTargetting.Create(info.ability.animationTarget);
      List<IntentTargetInfo> intentTargetInfoList = new List<IntentTargetInfo>();
      foreach (IntentTargetInfo intent in info.ability.intents)
      {
        IntentTargetInfo intentTargetInfo = new IntentTargetInfo()
        {
          targetIntents = intent.targetIntents,
          targets = (BaseCombatTargettingSO) GilbertFlipTargetting.Create(intent.targets)
        };
        intentTargetInfoList.Add(intentTargetInfo);
      }
      extraAbilityInfo.ability.intents = intentTargetInfoList.ToArray();
      return extraAbilityInfo;
    }

    public static ExtraAbilityInfo gilbExtraToiletPaper(ExtraAbilityInfo info)
    {
      ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo()
      {
        rarity = info.rarity,
        cost = info.cost,
        ability = UnityEngine.Object.Instantiate<AbilitySO>(info.ability)
      };
      extraAbilityInfo.ability._description = Regex.Replace(extraAbilityInfo.ability._description, "Opposing", "Left and Right");
      extraAbilityInfo.ability._description = Regex.Replace(extraAbilityInfo.ability._description, "opposing", "left and right");
      List<EffectInfo> effectInfoList = new List<EffectInfo>();
      foreach (EffectInfo effect in info.ability.effects)
      {
        EffectInfo effectInfo = new EffectInfo()
        {
          entryVariable = effect.entryVariable,
          effect = effect.effect,
          condition = effect.condition,
          targets = effect.targets != null ? (BaseCombatTargettingSO) GilbertFlipTargetting.Create(effect.targets) : Slots.Self
        };
        if (effectInfo.effect is PerformRandomAbilityFromCharacterEffect)
          effectInfo.effect =  PerformRandomAbilityFromCharacterSwapTargetsEffect.Instance;
        try
        {
          if (effectInfo.effect is PerformRandomAbilityEnemyEffect)
            effectInfo.effect =  PerformRandomAbilityFromEnemySwapTargetsEffect.Instance;
        }
        catch (Exception ex)
        {
          Debug.LogWarning((object) "doesnt have tarpeepbaz enemy pack installed, so this doesnt matter wowiezowie");
        }
        effectInfoList.Add(effectInfo);
      }
      extraAbilityInfo.ability.effects = effectInfoList.ToArray();
      extraAbilityInfo.ability.animationTarget = (BaseCombatTargettingSO) GilbertFlipTargetting.Create(info.ability.animationTarget);
      List<IntentTargetInfo> intentTargetInfoList = new List<IntentTargetInfo>();
      foreach (IntentTargetInfo intent in info.ability.intents)
      {
        IntentTargetInfo intentTargetInfo = new IntentTargetInfo()
        {
          targetIntents = intent.targetIntents,
          targets = (BaseCombatTargettingSO) GilbertFlipTargetting.Create(intent.targets)
        };
        intentTargetInfoList.Add(intentTargetInfo);
      }
      extraAbilityInfo.ability.intents = intentTargetInfoList.ToArray();
      return extraAbilityInfo;
    }
  }
}
