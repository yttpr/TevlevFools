﻿// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ApplyPermenantFocusedEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class ApplyPermenantFocusedEffect : EffectSO
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
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 8, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          Focused_StatusEffect focusedStatusEffect = new Focused_StatusEffect(1);
          focusedStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) focusedStatusEffect, 0))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
