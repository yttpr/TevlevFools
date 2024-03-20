// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.TargettingUnitsWithStatusEffectAll
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;

#nullable disable
namespace TevlevsRapscallions
{
  public class TargettingUnitsWithStatusEffectAll : BaseCombatTargettingSO
  {
    public bool ignoreCastSlot = false;
    public StatusEffectType targetStatus;

    public override bool AreTargetAllies => false;

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
      foreach (CombatSlot characterSlot in slots.CharacterSlots)
      {
        TargetSlotInfo targetSlotInformation = characterSlot.TargetSlotInformation;
        if (targetSlotInformation != null && targetSlotInformation.HasUnit && !TargettingUnitsWithStatusEffectAll.IsUnitAlreadyContained(targets, targetSlotInformation) && !this.IsCastSlot(casterSlotID, targetSlotInformation) && targetSlotInformation.Unit.ContainsStatusEffect(this.targetStatus, 0))
          targets.Add(targetSlotInformation);
      }
      foreach (CombatSlot enemySlot in slots.EnemySlots)
      {
        TargetSlotInfo targetSlotInformation = enemySlot.TargetSlotInformation;
        if (targetSlotInformation != null && targetSlotInformation.HasUnit && !TargettingUnitsWithStatusEffectAll.IsUnitAlreadyContained(targets, targetSlotInformation) && !this.IsCastSlot(casterSlotID, targetSlotInformation) && targetSlotInformation.Unit.ContainsStatusEffect(this.targetStatus, 0))
          targets.Add(targetSlotInformation);
      }
      return targets.ToArray();
    }
  }
}
