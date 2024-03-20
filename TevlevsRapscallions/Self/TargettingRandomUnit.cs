// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingRandomUnit
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingRandomUnit : BaseCombatTargettingSO
  {
    public bool getAllies;
    public bool ignoreCastSlot = false;
    public static TargetSlotInfo LastRandom;

    public override bool AreTargetAllies => this.getAllies;

    public override bool AreTargetSlots => false;

    public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
    {
      foreach (TargetSlotInfo target1 in targets)
      {
        if (target1.Unit == target.Unit)
          return true;
      }
      return false;
    }

    public bool IsCastSlot(int caster, TargetSlotInfo target)
    {
      return this.ignoreCastSlot && caster == target.SlotID;
    }

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
      if (this.getAllies & isCasterCharacter || !this.getAllies && !isCasterCharacter)
      {
        foreach (CombatSlot characterSlot in slots.CharacterSlots)
        {
          TargetSlotInfo targetSlotInformation = characterSlot.TargetSlotInformation;
          if (targetSlotInformation != null && targetSlotInformation.HasUnit && !TargettingRandomUnit.IsUnitAlreadyContained(targets, targetSlotInformation) && !this.IsCastSlot(casterSlotID, targetSlotInformation))
            targets.Add(targetSlotInformation);
        }
      }
      else
      {
        foreach (CombatSlot enemySlot in slots.EnemySlots)
        {
          TargetSlotInfo targetSlotInformation = enemySlot.TargetSlotInformation;
          if (targetSlotInformation != null && targetSlotInformation.HasUnit && !TargettingRandomUnit.IsUnitAlreadyContained(targets, targetSlotInformation) && !this.IsCastSlot(casterSlotID, targetSlotInformation))
            targets.Add(targetSlotInformation);
        }
      }
      if (targets.Count <= 0)
      {
        TargettingRandomUnit.LastRandom = (TargetSlotInfo) null;
        return new TargetSlotInfo[0];
      }
      TargetSlotInfo targetSlotInfo = targets[Random.Range(0, targets.Count)];
      TargettingRandomUnit.LastRandom = targetSlotInfo;
      return new TargetSlotInfo[1]{ targetSlotInfo };
    }
  }
}
