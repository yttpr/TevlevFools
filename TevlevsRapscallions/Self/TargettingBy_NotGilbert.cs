// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingBy_NotGilbert
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingBy_NotGilbert : Targetting_ByUnit_Side
  {
    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = base.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (!targetSlotInfo.HasUnit || !targetSlotInfo.Unit.ContainsPassiveAbility(ShitBurg.Gilby.type) && !targetSlotInfo.Unit.ContainsPassiveAbility((PassiveAbilityTypes) (ShitBurg.Gilby.type + 1)))
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }
  }
}
