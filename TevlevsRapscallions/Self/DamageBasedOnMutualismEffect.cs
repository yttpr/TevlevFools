// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.DamageBasedOnMutualismEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class DamageBasedOnMutualismEffect : EffectSO
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
    public float _reduceamount = 10f;

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
      int num1 = 0;
      if (caster.ContainsPassiveAbility((PassiveAbilityTypes) 45))
      {
        int storedValue = caster.GetStoredValue((UnitStoredValueNames) 14);
        int num2 = Mathf.Max(1, Mathf.FloorToInt((float) ((double) this._reduceamount * 1.0 * (double) storedValue / 100.0)));
        num1 = num2;
        int num3 = storedValue - num2;
        caster.SetStoredValue((UnitStoredValueNames) 14, num3);
        if (num3 <= 0)
          caster.TryRemovePassiveAbility((PassiveAbilityTypes) 45, true);
      }
      exitAmount = 0;
      bool flag = false;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num4 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num5 = entryVariable + num1;
          DamageInfo damageInfo;
          if (this._indirect)
          {
            damageInfo = target.Unit.Damage(num5, (IUnit) null, this._deathType, num4, false, false, true, (DamageType) 0);
          }
          else
          {
            int num6 = caster.WillApplyDamage(num5, target.Unit);
            damageInfo = target.Unit.Damage(num6, caster, this._deathType, num4, true, true, this._ignoreShield, (DamageType) 0);
          }
          flag |= damageInfo.beenKilled;
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
    }
  }
}
