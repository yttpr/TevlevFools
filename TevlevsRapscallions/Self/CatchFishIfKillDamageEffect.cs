// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.CatchFishIfKillDamageEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class CatchFishIfKillDamageEffect : EffectSO
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
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 2;
    [SerializeField]
    public bool _returnKillAsSuccess;

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
      bool flag1 = false;
      bool flag2 = false;
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          int num1 = areTargetSlots ? targets[index].SlotID - targets[index].Unit.SlotID : -1;
          int num2 = entryVariable;
          DamageInfo damageInfo;
          if (this._indirect)
          {
            damageInfo = targets[index].Unit.Damage(num2, (IUnit) null, this._deathType, num1, false, false, true, (DamageType) 0);
          }
          else
          {
            int num3 = caster.WillApplyDamage(num2, targets[index].Unit);
            damageInfo = targets[index].Unit.Damage(num3, caster, this._deathType, num1, true, true, this._ignoreShield, (DamageType) 0);
          }
          flag1 |= damageInfo.beenKilled;
          exitAmount += damageInfo.damageAmount;
          flag2 = true;
        }
      }
      if (!flag2)
        return false;
      if (flag1)
      {
        int storedValue = caster.GetStoredValue(this._valueName);
        caster.SetStoredValue(this._valueName, storedValue + 1);
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return !this._returnKillAsSuccess ? exitAmount > 0 : flag1;
    }
  }
}
