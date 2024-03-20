// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ReturnBackToSlotBasedOnPreviousExitAmountEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class ReturnBackToSlotBasedOnPreviousExitAmountEffect : EffectSO
  {
    private int ReturnSlot;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      this.ReturnSlot = this.PreviousExitValue;
      if (this.ReturnSlot == 5)
        this.ReturnSlot = 0;
      if (caster.IsAlive && stats.combatSlots.SwapCharacters(caster.SlotID, this.ReturnSlot, true, (SwapType) 0))
        ++exitAmount;
      return true;
    }
  }
}
