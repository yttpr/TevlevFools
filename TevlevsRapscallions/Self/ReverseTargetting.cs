// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ReverseTargetting
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;

#nullable disable
namespace TevlevsRapscallions
{
  public class ReverseTargetting : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO source;
    public BaseCombatTargettingSO secondary;

    public override bool AreTargetAllies => !this.secondary.AreTargetAllies;

    public override bool AreTargetSlots => this.secondary.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.source.GetTargets(slots, casterSlotID, isCasterCharacter);
      if (targets.Length == 0)
        return new TargetSlotInfo[0];
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        foreach (TargetSlotInfo target in this.secondary.GetTargets(slots, targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot))
          targetSlotInfoList.Add(target);
      }
      return targetSlotInfoList.ToArray();
    }
  }
}
