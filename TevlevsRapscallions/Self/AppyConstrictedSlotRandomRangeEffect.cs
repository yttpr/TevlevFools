// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AppyConstrictedSlotRandomRangeEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class AppyConstrictedSlotRandomRangeEffect : EffectSO
  {
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
      int num = Random.Range(this.minrange, entryVariable);
      SlotStatusEffectInfoSO statusEffectInfoSo;
      stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 1, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        Constricted_SlotStatusEffect slotStatusEffect = new Constricted_SlotStatusEffect(targets[index].SlotID, num, 0);
        slotStatusEffect.SetEffectInformation(statusEffectInfoSo);
        if (stats.combatSlots.ApplySlotStatusEffect(targets[index].SlotID, targets[index].IsTargetCharacterSlot, num, (ISlotStatusEffect) slotStatusEffect, 1))
          exitAmount += num;
      }
      return exitAmount > 0;
    }
  }
}
