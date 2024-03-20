// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingByConditionStatus
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingByConditionStatus : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO orig;
    public StatusEffectType status = (StatusEffectType) 1;
    public bool Has;

    public override bool AreTargetAllies => this.orig.AreTargetAllies;

    public override bool AreTargetSlots => this.orig.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.orig.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit && this.Has == targetSlotInfo.Unit.ContainsStatusEffect(this.status, 0))
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }

    public static TargettingByConditionStatus Create(
      BaseCombatTargettingSO orig,
      StatusEffectType status,
      bool Has = true)
    {
      TargettingByConditionStatus instance = ScriptableObject.CreateInstance<TargettingByConditionStatus>();
      instance.orig = orig;
      instance.status = status;
      instance.Has = Has;
      return instance;
    }
  }
}
