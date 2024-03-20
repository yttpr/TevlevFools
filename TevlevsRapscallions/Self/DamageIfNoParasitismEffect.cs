// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.DamageIfNoParasitismEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class DamageIfNoParasitismEffect : EffectSO
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
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          if (!target.Unit.ContainsPassiveAbility((PassiveAbilityTypes) 45))
            flag2 = true;
          int num1 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num2 = entryVariable;
          DamageInfo damageInfo;
          if (this._indirect)
          {
            damageInfo = target.Unit.Damage(num2, (IUnit) null, this._deathType, num1, false, false, true, (DamageType) 0);
          }
          else
          {
            int num3 = caster.WillApplyDamage(num2, target.Unit);
            damageInfo = target.Unit.Damage(num3, caster, this._deathType, num1, true, true, this._ignoreShield, (DamageType) 0);
          }
          flag1 |= damageInfo.beenKilled;
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (flag2 && caster.IsAlive)
      {
        int num4 = 6;
        int num5 = areTargetSlots ? caster.SlotID - caster.SlotID : -1;
        int num6 = caster.WillApplyDamage(num4, caster);
        caster.Damage(num6, caster, this._deathType, num5, true, true, this._ignoreShield, (DamageType) 0);
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return !this._returnKillAsSuccess ? exitAmount > 0 : flag1;
    }
  }
}
