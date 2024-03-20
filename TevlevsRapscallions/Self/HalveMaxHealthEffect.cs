// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.HalveMaxHealthEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System;

#nullable disable
namespace TevlevsRapscallions
{
  public class HalveMaxHealthEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int maximumHealth = caster.MaximumHealth;
      int num = (int) Math.Ceiling((double) ((float) maximumHealth / 2f));
      caster.MaximizeHealth(num);
      exitAmount = maximumHealth - num;
      return true;
    }
  }
}
