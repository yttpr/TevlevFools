// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AddPassiveIfDontContainePassiveEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class AddPassiveIfDontContainePassiveEffect : EffectSO
  {
    [SerializeField]
    public BasePassiveAbilitySO _passiveToAdd;
    [SerializeField]
    public PassiveAbilityTypes _passiveToCheck = (PassiveAbilityTypes) 46;

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
        if (target.HasUnit && !target.Unit.ContainsPassiveAbility(this._passiveToCheck) && target.Unit.AddPassiveAbility(this._passiveToAdd))
          ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
