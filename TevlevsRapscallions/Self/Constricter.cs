// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Constricter
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public static class Constricter
  {
    public static bool InConstricting(CombatStats stats, IUnit unit)
    {
      bool flag = false;
      for (int slotId = unit.SlotID; slotId < unit.SlotID + unit.Size; ++slotId)
      {
        if (stats.combatSlots.SlotContainsSlotStatusEffect(slotId, unit.IsUnitCharacter, (SlotStatusEffectType) 1))
          flag = true;
      }
      return flag;
    }
  }
}
