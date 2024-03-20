// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingByTargetting
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingByTargetting : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO first;
    public BaseCombatTargettingSO second;
    public bool OnlyIfUnit;

    public override bool AreTargetSlots => this.second.AreTargetSlots;

    public override bool AreTargetAllies
    {
      get
      {
        if (this.first.AreTargetAllies && this.second.AreTargetAllies)
          return true;
        return !this.first.AreTargetAllies && !this.second.AreTargetAllies;
      }
    }

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.first.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit || !this.OnlyIfUnit)
        {
          foreach (TargetSlotInfo target in this.second.GetTargets(slots, targetSlotInfo.HasUnit ? targetSlotInfo.Unit.SlotID : targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot))
            targetSlotInfoList.Add(target);
        }
      }
      return targetSlotInfoList.ToArray();
    }

    public static TargettingByTargetting Create(
      BaseCombatTargettingSO first,
      BaseCombatTargettingSO second)
    {
      TargettingByTargetting instance = ScriptableObject.CreateInstance<TargettingByTargetting>();
      instance.first = first;
      instance.second = second;
      return instance;
    }
  }
}
