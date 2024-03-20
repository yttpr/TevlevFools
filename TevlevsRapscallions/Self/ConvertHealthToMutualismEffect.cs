// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ConvertHealthToMutualismEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class ConvertHealthToMutualismEffect : EffectSO
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
        if (target.HasUnit && target.Unit.ContainsPassiveAbility((PassiveAbilityTypes) 45))
        {
          int num1 = target.Unit.CurrentHealth - entryVariable;
          if (num1 <= 0)
          {
            target.Unit.ReduceHealthTo(0);
            CombatManager.Instance.AddSubAction((CombatAction) new CharacterDeathAction(target.Unit.ID, target.Unit, (DeathType) 0));
            return false;
          }
          target.Unit.ReduceHealthTo(num1);
          int num2 = target.Unit.GetStoredValue((UnitStoredValueNames) 14) + entryVariable;
          target.Unit.SetStoredValue((UnitStoredValueNames) 14, num2);
        }
      }
      return exitAmount > 0;
    }
  }
}
