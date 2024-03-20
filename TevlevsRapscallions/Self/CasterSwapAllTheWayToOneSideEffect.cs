// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.CasterSwapAllTheWayToOneSideEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class CasterSwapAllTheWayToOneSideEffect : EffectSO
  {
    [SerializeField]
    public bool _swapRight = true;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      bool flag1 = caster.SlotID == 4;
      bool flag2 = caster.SlotID == 0;
      if (caster.IsUnitCharacter)
      {
        int num = this._swapRight ? 1 : -1;
        if (caster.SlotID + num >= 0 && caster.SlotID + num < stats.combatSlots.CharacterSlots.Length && stats.combatSlots.SwapCharacters(caster.SlotID, caster.SlotID + num, true, (SwapType) 0))
        {
          if (this._swapRight)
          {
            if (!flag1)
            {
              this._swapRight = true;
              PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
            }
          }
          else if (!flag2)
          {
            this._swapRight = false;
            PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
          }
        }
      }
      else
      {
        int num1 = this._swapRight ? caster.Size : -1;
        int num2;
        int num3;
        if (stats.combatSlots.CanEnemiesSwap(caster.SlotID, caster.SlotID + num1, out num2, out num3) && stats.combatSlots.SwapEnemies(caster.SlotID, num2, caster.SlotID + num1, num3, false, (SwapType) 1))
        {
          if (this._swapRight)
          {
            if (!flag1)
            {
              this._swapRight = true;
              PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
            }
          }
          else if (!flag2)
          {
            this._swapRight = false;
            PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
