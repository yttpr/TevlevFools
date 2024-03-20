// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SwapToSidesReturnCurrentSlotEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class SwapToSidesReturnCurrentSlotEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      List<IUnit> iunitList1 = new List<IUnit>();
      List<IUnit> iunitList2 = new List<IUnit>();
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          IUnit unit = targets[index].Unit;
          if (unit.IsUnitCharacter && !iunitList1.Contains(unit))
            iunitList1.Add(unit);
          else if (!unit.IsUnitCharacter && !iunitList2.Contains(unit))
            iunitList2.Add(unit);
        }
      }
      exitAmount = caster.SlotID != 0 ? caster.SlotID : 5;
      foreach (IUnit iunit in iunitList1)
      {
        int num1 = Random.Range(0, 2) * 2 - 1;
        if (iunit.SlotID + num1 >= 0 && iunit.SlotID + num1 < stats.combatSlots.CharacterSlots.Length)
        {
          if (!stats.combatSlots.SwapCharacters(iunit.SlotID, iunit.SlotID + num1, true, (SwapType) 0))
            ;
        }
        else
        {
          int num2 = num1 * -1;
          if (iunit.SlotID + num2 < 0 || iunit.SlotID + num2 >= stats.combatSlots.CharacterSlots.Length || !stats.combatSlots.SwapCharacters(iunit.SlotID, iunit.SlotID + num2, true, (SwapType) 0))
            ;
        }
      }
      foreach (IUnit iunit in iunitList2)
      {
        int num3 = Random.Range(0, 2) * (iunit.Size + 1) - 1;
        int num4;
        int num5;
        if (stats.combatSlots.CanEnemiesSwap(iunit.SlotID, iunit.SlotID + num3, out num4, out num5))
        {
          if (!stats.combatSlots.SwapEnemies(iunit.SlotID, num4, iunit.SlotID + num3, num5, false, (SwapType) 1))
            ;
        }
        else
        {
          int num6 = num3 < 0 ? iunit.Size : -1;
          if (!stats.combatSlots.CanEnemiesSwap(iunit.SlotID, iunit.SlotID + num6, out num4, out num5) || !stats.combatSlots.SwapEnemies(iunit.SlotID, num4, iunit.SlotID + num6, num5, false, (SwapType) 1))
            ;
        }
      }
      return exitAmount > 0;
    }
  }
}
