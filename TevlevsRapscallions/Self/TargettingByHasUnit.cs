// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingByHasUnit
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingByHasUnit : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO source;

    public override bool AreTargetAllies => this.source.AreTargetAllies;

    public override bool AreTargetSlots => this.source.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.source.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit)
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }

    public static TargettingByHasUnit Create(BaseCombatTargettingSO orig)
    {
      TargettingByHasUnit instance = ScriptableObject.CreateInstance<TargettingByHasUnit>();
      instance.source = orig;
      return instance;
    }
  }
}
