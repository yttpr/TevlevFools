// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ConsumeItemNotifacationEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class ConsumeItemNotifacationEffect : EffectSO
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
        CombatManager.Instance.PostNotification(JunkItems.Call.ToString(), (object) target.Unit, (object) null);
        if (target.HasUnit && target.Unit.TryConsumeWearable())
          ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
