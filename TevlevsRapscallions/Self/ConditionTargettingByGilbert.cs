// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ConditionTargettingByGilbert
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;

#nullable disable
namespace TevlevsRapscallions
{
  public class ConditionTargettingByGilbert : BaseCombatTargettingSO
  {
    public bool IsFrontGilbert(int slotid, bool chara)
    {
      bool flag = false;
      foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, slotid, chara))
      {
        if (target.HasUnit && target.Unit.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
          flag = true;
      }
      return flag;
    }

    public bool IsFrontEmpty(int slotid, bool chara)
    {
      bool flag = true;
      foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, slotid, chara))
      {
        if (target.HasUnit)
          flag = false;
      }
      return flag;
    }

    public override bool AreTargetAllies => false;

    public override bool AreTargetSlots => true;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      return this.IsFrontGilbert(casterSlotID, isCasterCharacter) || this.IsFrontEmpty(casterSlotID, isCasterCharacter) ? ((BaseCombatTargettingSO) Gilfects.GilbEny).GetTargets(slots, casterSlotID, isCasterCharacter) : Slots.Front.GetTargets(slots, casterSlotID, isCasterCharacter);
    }
  }
}
