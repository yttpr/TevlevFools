﻿// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingClosestUnits
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingClosestUnits : BaseCombatTargettingSO
  {
    public bool getAllies;
    public bool ignoreCastSlot = true;

    public override bool AreTargetAllies => this.getAllies;

    public override bool AreTargetSlots => true;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      CombatSlot combatSlot1 = (CombatSlot) null;
      CombatSlot combatSlot2 = (CombatSlot) null;
      if (isCasterCharacter && this.getAllies || !isCasterCharacter && !this.getAllies)
      {
        foreach (CombatSlot characterSlot in slots.CharacterSlots)
        {
          if (characterSlot.HasUnit && characterSlot.SlotID > casterSlotID && (!this.ignoreCastSlot || casterSlotID != characterSlot.SlotID))
          {
            if (combatSlot1 == null)
              combatSlot1 = characterSlot;
            else if (characterSlot.SlotID < combatSlot1.SlotID)
              combatSlot1 = characterSlot;
          }
          else if (characterSlot.HasUnit && characterSlot.SlotID < casterSlotID && (!this.ignoreCastSlot || casterSlotID != characterSlot.SlotID))
          {
            if (combatSlot2 == null)
              combatSlot2 = characterSlot;
            else if (characterSlot.SlotID > combatSlot2.SlotID)
              combatSlot2 = characterSlot;
          }
        }
      }
      else
      {
        foreach (CombatSlot enemySlot in slots.EnemySlots)
        {
          if (enemySlot.HasUnit && enemySlot.SlotID > casterSlotID && (!this.ignoreCastSlot || casterSlotID != enemySlot.SlotID))
          {
            if (combatSlot1 == null)
              combatSlot1 = enemySlot;
            else if (enemySlot.SlotID < combatSlot1.SlotID)
              combatSlot1 = enemySlot;
          }
          else if (enemySlot.HasUnit && enemySlot.SlotID < casterSlotID && (!this.ignoreCastSlot || casterSlotID != enemySlot.SlotID))
          {
            if (combatSlot2 == null)
              combatSlot2 = enemySlot;
            else if (enemySlot.SlotID > combatSlot2.SlotID)
              combatSlot2 = enemySlot;
          }
        }
      }
      if (combatSlot1 != null)
        targetSlotInfoList.Add(combatSlot1.TargetSlotInformation);
      if (combatSlot2 != null)
        targetSlotInfoList.Add(combatSlot2.TargetSlotInformation);
      return targetSlotInfoList.ToArray();
    }
  }
}
