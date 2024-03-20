// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.PerformRandomAbilityEnemyEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class PerformRandomAbilityEnemyEffect : EffectSO
  {
    [SerializeField]
    public bool _increase = true;
    [SerializeField]
    public bool _entryAsPercentage;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (!(caster is EnemyCombat enemyCombat))
        return exitAmount > 0;
      if (enemyCombat.Abilities == null || enemyCombat.Abilities.Count <= 0)
        return false;
      int index = Random.Range(0, enemyCombat.Abilities.Count);
      AbilitySO ability = enemyCombat.Abilities[index].ability;
      CombatManager.Instance.AddSubAction((CombatAction) new ShowAttackInformationUIAction(enemyCombat.ID, enemyCombat.IsUnitCharacter, ability.GetAbilityLocData().text));
      CombatManager.Instance.AddSubAction((CombatAction) new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, (IUnit) enemyCombat));
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ability.effects, (IUnit) enemyCombat, 0));
      return true;
    }
  }
}
