// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.MoreDamageIfConstrictedEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class MoreDamageIfConstrictedEffect : EffectSO
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
    private float fnum = 1.5f;

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
      int num1 = 0;
      for (int index1 = 0; index1 < targets.Length; ++index1)
      {
        IUnit unit = targets[index1].Unit;
        if (targets[index1].HasUnit)
        {
          for (int index2 = 0; index2 < unit.Size; ++index2)
            num1 = !Constricter.InConstricting(stats, targets[index1].Unit) ? entryVariable : (int) ((double) entryVariable * (double) this.fnum);
        }
      }
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num2 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num3 = entryVariable;
          if (Constricter.InConstricting(stats, target.Unit))
            num3 = (int) ((double) entryVariable * (double) this.fnum);
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
        }
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
    }
  }
}
