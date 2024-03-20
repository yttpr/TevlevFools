// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Rupture1ToEntryEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class Rupture1ToEntryEffect : ApplyRupturedEffect
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
        int num;
        base.PerformEffect(stats, caster, target.SelfArray<TargetSlotInfo>(), areTargetSlots, Random.Range(1, entryVariable + 1), out num);
        exitAmount += num;
      }
      return exitAmount > 0;
    }
  }
}
