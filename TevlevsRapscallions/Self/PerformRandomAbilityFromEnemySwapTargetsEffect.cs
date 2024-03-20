// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.PerformRandomAbilityFromEnemySwapTargetsEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class PerformRandomAbilityFromEnemySwapTargetsEffect : EffectSO
  {
    private static PerformRandomAbilityFromEnemySwapTargetsEffect _instance;

    public static PerformRandomAbilityFromEnemySwapTargetsEffect Instance
    {
      get
      {
        if (_instance == null)
          PerformRandomAbilityFromEnemySwapTargetsEffect._instance = ScriptableObject.CreateInstance<PerformRandomAbilityFromEnemySwapTargetsEffect>();
        return PerformRandomAbilityFromEnemySwapTargetsEffect._instance;
      }
    }

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      try
      {
        int index1 = UnityEngine.Random.Range(0, EnemyPack.EnemyPack.Enemies.Count);
        EnemySO enemy = EnemyPack.EnemyPack.Enemies[index1];
        if (enemy != null)
        {
          if (enemy.abilities == null || enemy.abilities.Length == 0)
            return false;
          int index2 = UnityEngine.Random.Range(0, enemy.abilities.Length);
          AbilitySO ability = enemy.abilities[index2].ability;
          CombatManager.Instance.AddSubAction((CombatAction) new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, ability.GetAbilityLocData().text));
          CombatManager.Instance.AddSubAction((CombatAction) new PlayAbilityAnimationSwapSidesAction(ability.visuals, ability.animationTarget, caster));
          CombatManager.Instance.AddSubAction((CombatAction) new SwapSidesEffectAction(ability.effects, caster));
          return true;
        }
      }
      catch (Exception ex)
      {
        Debug.LogError((object) "tairpeep enemy pack not installed how the hell did you even get this effect to trigger wtf");
      }
      return exitAmount > 0;
    }
  }
}
