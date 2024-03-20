// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.DealRandomAmountDamageConvertToParasiteEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class DealRandomAmountDamageConvertToParasiteEffect : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = (DeathType) 1;
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect;
    [SerializeField]
    public bool _returnKillAsSuccess;
    [SerializeField]
    public int _minAmount = 1;
    [SerializeField]
    public BasePassiveAbilitySO _passiveToAdd = Passives.Parasitism;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this._usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      bool flag = false;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num1 = Random.Range(this._minAmount, entryVariable);
          int num2 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num3 = num1;
          DamageInfo damageInfo;
          if (this._indirect)
          {
            damageInfo = target.Unit.Damage(num3, (IUnit) null, this._deathType, num2, false, false, true, (DamageType) 0);
          }
          else
          {
            int num4 = caster.WillApplyDamage(num3, target.Unit);
            damageInfo = target.Unit.Damage(num4, caster, this._deathType, num2, true, true, this._ignoreShield, (DamageType) 0);
          }
          flag |= damageInfo.beenKilled;
          exitAmount += damageInfo.damageAmount;
          if (damageInfo.damageAmount > 0)
          {
            int damageAmount = damageInfo.damageAmount;
            IUnit unit = target.Unit;
            if (!unit.ContainsPassiveAbility((PassiveAbilityTypes) 45))
              unit.AddPassiveAbility(this._passiveToAdd);
            int num5 = unit.GetStoredValue((UnitStoredValueNames) 14) + damageAmount;
            unit.SetStoredValue((UnitStoredValueNames) 14, num5);
          }
        }
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
    }
  }
}
