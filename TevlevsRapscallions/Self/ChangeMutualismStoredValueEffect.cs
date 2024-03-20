// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ChangeMutualismStoredValueEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class ChangeMutualismStoredValueEffect : EffectSO
  {
    public bool _decrease;
    public bool _usePreviousExitValue = true;

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
        if (this._usePreviousExitValue)
          entryVariable *= this.PreviousExitValue;
        if (target.HasUnit && target.Unit.ContainsPassiveAbility((PassiveAbilityTypes) 45))
        {
          if (this._decrease)
          {
            int num = target.Unit.GetStoredValue((UnitStoredValueNames) 14) - entryVariable;
            target.Unit.SetStoredValue((UnitStoredValueNames) 14, num);
            exitAmount += entryVariable;
          }
          else
          {
            int num = target.Unit.GetStoredValue((UnitStoredValueNames) 14) + entryVariable;
            target.Unit.SetStoredValue((UnitStoredValueNames) 14, num);
            exitAmount += entryVariable;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
