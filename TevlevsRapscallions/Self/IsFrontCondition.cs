// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.IsFrontCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;

#nullable disable
namespace TevlevsRapscallions
{
  public class IsFrontCondition : EffectConditionSO
  {
    public bool HasUnit;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      bool flag = false;
      foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter))
      {
        if (target.HasUnit)
          flag = true;
      }
      return this.HasUnit == flag;
    }
  }
}
