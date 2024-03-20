// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingUnitsEitherSide
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingUnitsEitherSide : BaseCombatTargettingSO
  {
    public bool getAllies;
    public bool right;
    public bool ignoreDirectNextAllyOnly = true;
    private Targetting_ByUnit_Side source = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();

    public override bool AreTargetAllies => this.getAllies;

    public override bool AreTargetSlots => false;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      this.source.getAllies = this.getAllies;
      this.source.getAllUnitSlots = false;
      this.source.ignoreCastSlot = true;
      foreach (TargetSlotInfo target in ((BaseCombatTargettingSO) this.source).GetTargets(slots, casterSlotID, isCasterCharacter))
      {
        if (this.right)
        {
          if (target.SlotID > casterSlotID && target.HasUnit)
          {
            if (this.getAllies)
            {
              if (!this.ignoreDirectNextAllyOnly || target.SlotID != casterSlotID + 1)
                targetSlotInfoList.Add(target);
            }
            else
              targetSlotInfoList.Add(target);
          }
        }
        else if (target.SlotID < casterSlotID && target.HasUnit)
        {
          if (this.getAllies)
          {
            if (!this.ignoreDirectNextAllyOnly || target.SlotID != casterSlotID - target.Unit.Size)
              targetSlotInfoList.Add(target);
          }
          else
            targetSlotInfoList.Add(target);
        }
      }
      if (!this.right)
        targetSlotInfoList.Reverse();
      return targetSlotInfoList.ToArray();
    }
  }
}
