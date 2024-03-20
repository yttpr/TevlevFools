// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ConstructPassiveTriggerEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class ConstructPassiveTriggerEffect : EffectSO
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
        if (target.HasUnit)
          CombatManager.Instance.PostNotification(((TriggerCalls) 889532).ToString(), (object) target.Unit, (object) null);
      }
      return exitAmount > 0;
    }
  }
}
