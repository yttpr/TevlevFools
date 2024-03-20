// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.CasterLowerStoredValueEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class CasterLowerStoredValueEffect : EffectSO
  {
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 2;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      int num = caster.GetStoredValue(this._valueName) - entryVariable;
      if (num < 0)
        num = 0;
      caster.SetStoredValue(this._valueName, num);
      return exitAmount > 0;
    }
  }
}
