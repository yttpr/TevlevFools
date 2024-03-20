// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ApplyParasiteEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ApplyParasiteEffect : EffectSO
  {
    [SerializeField]
    public BasePassiveAbilitySO _passiveToAdd = Passives.Parasitism;

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
        if (targets[index].HasUnit)
        {
          if (!targets[index].Unit.ContainsPassiveAbility((PassiveAbilityTypes) 45))
            targets[index].Unit.AddPassiveAbility(this._passiveToAdd);
          int num = targets[index].Unit.GetStoredValue((UnitStoredValueNames) 14) + entryVariable;
          targets[index].Unit.SetStoredValue((UnitStoredValueNames) 14, num);
          exitAmount = num;
        }
      }
      return exitAmount > 0;
    }
  }
}
