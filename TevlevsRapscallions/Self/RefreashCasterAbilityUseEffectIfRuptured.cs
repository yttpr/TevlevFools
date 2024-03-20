// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.RefreashCasterAbilityUseEffectIfRuptured
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class RefreashCasterAbilityUseEffectIfRuptured : EffectSO
  {
    [SerializeField]
    public bool _doesExhaustInstead;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit && targets[index].Unit.ContainsStatusEffect((StatusEffectType) 2, 0) && (this._doesExhaustInstead ? caster.ExhaustAbilityUse() : caster.RefreshAbilityUse()))
          ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
