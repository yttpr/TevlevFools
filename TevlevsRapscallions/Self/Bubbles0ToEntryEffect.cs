// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Bubbles0ToEntryEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class Bubbles0ToEntryEffect : ApplyBubblesEffect
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
        int exitAmount1;
        base.PerformEffect(stats, caster, target.SelfArray<TargetSlotInfo>(), areTargetSlots, Random.Range(0, entryVariable + 1), out exitAmount1);
        exitAmount += exitAmount1;
      }
      return exitAmount > 0;
    }
  }
}
