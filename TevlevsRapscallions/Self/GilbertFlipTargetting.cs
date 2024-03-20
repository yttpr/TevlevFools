// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GilbertFlipTargetting
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class GilbertFlipTargetting : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO origin;

    public override bool AreTargetAllies
    {
      get
      {
        try
        {
          return !this.origin.AreTargetAllies;
        }
        catch (Exception ex)
        {
          return true;
        }
      }
    }

    public override bool AreTargetSlots
    {
      get
      {
        try
        {
          return this.origin.AreTargetSlots;
        }
        catch (Exception ex)
        {
          return true;
        }
      }
    }

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      try
      {
        TargetSlotInfo[] targets = this.origin.GetTargets(slots, casterSlotID, !isCasterCharacter);
        List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
        foreach (TargetSlotInfo targetSlotInfo in targets)
        {
          if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.SlotID == casterSlotID && targetSlotInfo.Unit.IsUnitCharacter == isCasterCharacter && AreTargetSlots)
          {
            foreach (TargetSlotInfo target in Slots.Sides.GetTargets(slots, casterSlotID, isCasterCharacter))
              targetSlotInfoList.Add(target);
          }
          else
            targetSlotInfoList.Add(targetSlotInfo);
        }
        return targetSlotInfoList.ToArray();
      }
      catch (Exception ex)
      {
        Debug.LogError((object) "GIlbert swap targetting epic failure.....");
        return Slots.Sides.GetTargets(slots, casterSlotID, isCasterCharacter);
      }
    }

    public static GilbertFlipTargetting Create(BaseCombatTargettingSO orig)
    {
      GilbertFlipTargetting instance = ScriptableObject.CreateInstance<GilbertFlipTargetting>();
      instance.origin = orig;
      return instance;
    }
  }
}
