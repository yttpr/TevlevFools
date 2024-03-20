// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ApplyScarsIfRutpuredEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ApplyScarsIfRutpuredEffect : EffectSO
  {
    [SerializeField]
    public bool _justOneTarget;
    [SerializeField]
    public bool _randomBetweenPrevious;
    [SerializeField]
    public bool _NailsRandomEffect;

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
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit && !targets[index].Unit.ContainsStatusEffect((StatusEffectType) 2, 0))
          return false;
      }
      if (this._NailsRandomEffect)
        entryVariable = Random.Range(1, 2);
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 11, out statusEffectInfoSo);
      if (this._justOneTarget)
      {
        List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>((IEnumerable<TargetSlotInfo>) targets);
        for (int index = targetSlotInfoList.Count - 1; index >= 0; --index)
        {
          if (!targetSlotInfoList[index].HasUnit)
            targetSlotInfoList.RemoveAt(index);
        }
        if (targetSlotInfoList.Count > 0)
        {
          int index = Random.Range(0, targetSlotInfoList.Count);
          int num = this._randomBetweenPrevious ? Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
          Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(num, 0);
          scarsStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targetSlotInfoList[index].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, num))
            exitAmount += num;
        }
      }
      else
      {
        for (int index = 0; index < targets.Length; ++index)
        {
          if (targets[index].HasUnit)
          {
            int num = this._randomBetweenPrevious ? Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
            Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(num, 0);
            scarsStatusEffect.SetEffectInformation(statusEffectInfoSo);
            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, num))
              ++exitAmount;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
