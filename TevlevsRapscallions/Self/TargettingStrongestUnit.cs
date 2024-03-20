// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingStrongestUnit
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingStrongestUnit : Targetting_ByUnit_Side
  {
    public bool OnlyOne;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> list = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in base.GetTargets(slots, casterSlotID, isCasterCharacter))
      {
        if (target != null && target.HasUnit)
        {
          if (list.Count <= 0)
            list.Add(target);
          else if (list[0].Unit.CurrentHealth < target.Unit.CurrentHealth)
          {
            list.Clear();
            list.Add(target);
          }
          else if (list[0].Unit.CurrentHealth == target.Unit.CurrentHealth)
            list.Add(target);
        }
      }
      if (list.Count <= 0)
        return new TargetSlotInfo[0];
      if (!this.OnlyOne)
        return list.ToArray();
      return new TargetSlotInfo[1]
      {
        list.GetRandom<TargetSlotInfo>()
      };
    }
  }
}
