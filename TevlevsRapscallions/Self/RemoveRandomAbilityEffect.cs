// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.RemoveRandomAbilityEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class RemoveRandomAbilityEffect : EffectSO
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
        if (target.Unit is CharacterCombat unit1)
        {
          unit1.CombatAbilities.RemoveAt(Random.Range(0, unit1.CombatAbilities.Count));
          ++exitAmount;
        }
        if (target.Unit is EnemyCombat unit2)
        {
          unit2.Abilities.RemoveAt(Random.Range(0, unit2.Abilities.Count));
          ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
