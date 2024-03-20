// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.RefreshIfStoredValueNotZero
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class RefreshIfStoredValueNotZero : EffectSO
  {
    [SerializeField]
    public bool _doesExhaustInstead;
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
      if (caster.GetStoredValue(this._valueName) != 0)
      {
        for (int index = 0; index < targets.Length; ++index)
        {
          if (targets[index].HasUnit && (this._doesExhaustInstead ? targets[index].Unit.ExhaustAbilityUse() : targets[index].Unit.RefreshAbilityUse()))
          {
            ++exitAmount;
            int num = caster.GetStoredValue(this._valueName) - entryVariable;
            if (num < 0)
              num = 0;
            caster.SetStoredValue(this._valueName, num);
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
