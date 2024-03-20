// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ApplyBubblesEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ApplyBubblesEffect : EffectSO
  {
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _applyonethroughtwoFUCKYOUTEVLEVTHUMBSDOWNEMOJI;
    [SerializeField]
    public int _previousExtraAddition;
    public bool _useRandomBetweenPrevious;
    [SerializeField]
    public bool doChance;
    public int chance;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (!this._applyonethroughtwoFUCKYOUTEVLEVTHUMBSDOWNEMOJI)
        ;
      if (this._usePreviousExitValue)
        entryVariable = this._previousExtraAddition + entryVariable * this.PreviousExitValue;
      exitAmount = 0;
      bool flag1 = entryVariable <= 0;
      int num = entryVariable;
      if (this._useRandomBetweenPrevious)
        num = UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1);
      bool flag2;
      if (flag1)
      {
        flag2 = false;
      }
      else
      {
        SlotStatusEffectInfoSO statusEffectInfoSo;
        stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 866795, out statusEffectInfoSo);
        for (int index1 = 0; index1 < targets.Length; ++index1)
        {
          if (!this.doChance || UnityEngine.Random.Range(0, 100) <= this.chance)
          {
            int defense = num;
            if (this._applyonethroughtwoFUCKYOUTEVLEVTHUMBSDOWNEMOJI)
              defense += UnityEngine.Random.Range(0, 2);
            ISlotStatusEffect islotStatusEffect = (ISlotStatusEffect) new Bubbles_SlotStatusEffect(targets[index1].SlotID, defense, targets[index1].IsTargetCharacterSlot);
            ISlotStatusEffector islotStatusEffector = targets[index1] as ISlotStatusEffector;
            if (targets[index1].IsTargetCharacterSlot)
            {
              foreach (CombatSlot characterSlot in stats.combatSlots._characterSlots)
              {
                if (characterSlot.SlotID == targets[index1].SlotID)
                  islotStatusEffector = (ISlotStatusEffector) characterSlot;
              }
            }
            else
            {
              foreach (CombatSlot enemySlot in stats.combatSlots._enemySlots)
              {
                if (enemySlot.SlotID == targets[index1].SlotID)
                  islotStatusEffector = (ISlotStatusEffector) enemySlot;
              }
            }
            bool flag3 = false;
            int index2 = 999;
            for (int index3 = 0; index3 < islotStatusEffector.StatusEffects.Count; ++index3)
            {
              if (islotStatusEffector.StatusEffects[index3].EffectType == islotStatusEffect.EffectType)
              {
                index2 = index3;
                flag3 = true;
              }
            }
            if (flag3)
            {
              foreach (MethodBase constructor in islotStatusEffector.StatusEffects[index2].GetType().GetConstructors())
              {
                if (constructor.GetParameters().Length == 4)
                  islotStatusEffect = (ISlotStatusEffect) Activator.CreateInstance(islotStatusEffector.StatusEffects[index2].GetType(), (object) targets[index1].SlotID, (object) defense, (object) targets[index1].IsTargetCharacterSlot, (object) 0);
              }
            }
            islotStatusEffect.SetEffectInformation(statusEffectInfoSo);
            if (stats.combatSlots.ApplySlotStatusEffect(targets[index1].SlotID, targets[index1].IsTargetCharacterSlot, defense, islotStatusEffect, 1))
              exitAmount += num;
          }
        }
        flag2 = exitAmount > 0;
      }
      return flag2;
    }
  }
}
