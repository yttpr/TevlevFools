// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.MortarCycleEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class MortarCycleEffect : DamageEffect
  {
    public static UnitStoredValueNames value => (UnitStoredValueNames) 7314243;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int num = caster.GetStoredValue(MortarCycleEffect.value);
      if (num <= 0)
        num = 1;
      TargetSlotInfo[] targetSlotInfoArray = new TargetSlotInfo[0];
      foreach (TargetSlotInfo target in targets)
      {
        if (target.SlotID == num - 1)
          targetSlotInfoArray = target.SelfArray<TargetSlotInfo>();
      }
      caster.SetStoredValue(MortarCycleEffect.value, num >= 5 ? 1 : num + 1);
      return base.PerformEffect(stats, caster, targetSlotInfoArray, areTargetSlots, entryVariable, out exitAmount);
    }
  }
}
