// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.HalfMaxHealthDamageRandomEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace TevlevsRapscallions
{
  public class HalfMaxHealthDamageRandomEffect : AnimationVisualsEffect
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
      List<TargetSlotInfo> list = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
          list.Add(target);
      }
      if (list.Count <= 0)
        return false;
      TargetSlotInfo random = list.GetRandom<TargetSlotInfo>();
      int num;
      base.PerformEffect(stats, caster, random.SelfArray<TargetSlotInfo>(), areTargetSlots, 1, out num);
      exitAmount += random.Unit.Damage(caster.WillApplyDamage((int)Math.Ceiling((double)caster.MaximumHealth / 2.0), random.Unit), (IUnit) null, (DeathType) 1, -1, true, true, false).damageAmount;
            caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
