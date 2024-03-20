// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.FishItemDamageEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class FishItemDamageEffect : DamageEffect
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
        if (target.HasUnit)
        {
          int num1 = target.Unit.UnitType == (UnitType)1 ? Random.Range(16, 33) : Random.Range(8, 17);
          int num2;
          base.PerformEffect(stats, caster, target.SelfArray<TargetSlotInfo>(), areTargetSlots, num1, out num2);
          exitAmount += num2;
        }
      }
      return exitAmount > 0;
    }
  }
}
