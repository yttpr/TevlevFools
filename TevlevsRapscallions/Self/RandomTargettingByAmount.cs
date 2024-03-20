// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.RandomTargettingByAmount
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
    public class RandomTargettingByAmount : Targetting_ByUnit_Side
    {
        public BaseCombatTargettingSO source;

        public virtual bool AreTargetAllies
        {
            get => (Object)this.source != (Object)null && this.source.AreTargetAllies;
        }

        public virtual bool AreTargetSlots => false;

        public virtual TargetSlotInfo[] GetTargets(
          SlotsCombat slots,
          int casterSlotID,
          bool isCasterCharacter)
        {
            this.getAllUnitSlots = false;
            this.ignoreCastSlot = false;
            TargetSlotInfo[] targetSlotInfoArray = (Object)this.source != (Object)null ? this.source.GetTargets(slots, casterSlotID, isCasterCharacter) : new TargetSlotInfo[0];
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            this.getAllies = true;
            TargetSlotInfo[] targets1 = base.GetTargets(slots, casterSlotID, true);
            TargetSlotInfo[] targets2 = base.GetTargets(slots, casterSlotID, false);
            foreach (TargetSlotInfo targetSlotInfo in targetSlotInfoArray)
            {
                if (targetSlotInfo.IsTargetCharacterSlot)
                    targetSlotInfoList.Add(targets1.GetRandom<TargetSlotInfo>());
                else
                    targetSlotInfoList.Add(targets2.GetRandom<TargetSlotInfo>());
            }
            return targetSlotInfoList.ToArray();
        }

        public static RandomTargettingByAmount Create(BaseCombatTargettingSO orig)
        {
            RandomTargettingByAmount instance = ScriptableObject.CreateInstance<RandomTargettingByAmount>();
            instance.source = orig;
            return instance;
        }
    }
}
