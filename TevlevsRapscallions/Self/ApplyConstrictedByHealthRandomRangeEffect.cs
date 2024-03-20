// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ApplyConstrictedByHealthRandomRangeEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ApplyConstrictedByHealthRandomRangeEffect : EffectSO
  {
    [SerializeField]
    public bool _applyWeakest;
    [SerializeField]
    public int minrange = 1;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      SlotStatusEffectInfoSO statusEffectInfoSo;
      stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 1, out statusEffectInfoSo);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      int num1 = -1;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.IsAlive)
        {
          if (num1 < 0)
          {
            targetSlotInfoList.Add(target);
            num1 = target.Unit.CurrentHealth;
          }
          else if (!this._applyWeakest && target.Unit.CurrentHealth > num1)
          {
            targetSlotInfoList.Clear();
            targetSlotInfoList.Add(target);
            num1 = target.Unit.CurrentHealth;
          }
          else if (this._applyWeakest && target.Unit.CurrentHealth < num1)
          {
            targetSlotInfoList.Clear();
            targetSlotInfoList.Add(target);
            num1 = target.Unit.CurrentHealth;
          }
        }
      }
      int num2 = Random.Range(this.minrange, entryVariable);
      foreach (TargetSlotInfo targetSlotInfo in targetSlotInfoList)
      {
        Constricted_SlotStatusEffect slotStatusEffect = new Constricted_SlotStatusEffect(targetSlotInfo.SlotID, num2, 0);
        slotStatusEffect.SetEffectInformation(statusEffectInfoSo);
        if (stats.combatSlots.ApplySlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, num2, (ISlotStatusEffect) slotStatusEffect, 1))
          exitAmount += num2;
      }
      return exitAmount > 0;
    }
  }
}
