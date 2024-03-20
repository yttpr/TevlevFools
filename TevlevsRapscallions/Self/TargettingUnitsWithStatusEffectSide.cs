﻿// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingUnitsWithStatusEffectSide
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingUnitsWithStatusEffectSide : Targetting_ByUnit_Side
  {
    public StatusEffectType targetStatus;

    public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
    {
      foreach (TargetSlotInfo target1 in targets)
      {
        if (target1.Unit == target.Unit)
          return true;
      }
      return false;
    }

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in base.GetTargets(slots, casterSlotID, isCasterCharacter))
      {
        if (target != null && target.HasUnit && !TargettingUnitsWithStatusEffectSide.IsUnitAlreadyContained(targets, target) && target.Unit.ContainsStatusEffect(this.targetStatus, 0))
          targets.Add(target);
      }
      return targets.ToArray();
    }
  }
}
