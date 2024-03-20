// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ExtraJunkListEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ExtraJunkListEffect : EffectSO
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
      switch (Random.Range(0, 4))
      {
        case 0:
          stats.AddExtraLootAddition("SharpJunk_EW");
          return true;
        case 1:
          stats.AddExtraLootAddition("SmoothJunk_EW");
          return true;
        case 2:
          stats.AddExtraLootAddition("RustyJunk_EW");
          return true;
        case 4:
          stats.AddExtraLootAddition("FlashyJunk_EW");
          return true;
        default:
          return exitAmount > 0;
      }
    }
  }
}
