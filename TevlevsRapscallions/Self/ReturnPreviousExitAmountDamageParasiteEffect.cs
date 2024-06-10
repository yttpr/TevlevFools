// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ReturnPreviousExitAmountDamageParasiteEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System.Collections;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ReturnPreviousExitAmountDamageParasiteEffect : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = (DeathType) 1;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect;
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
      exitAmount = this.PreviousExitValue;
      int num1 = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num2 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num3 = entryVariable;
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
          num1 += damageInfo.damageAmount;
          if (damageInfo.damageAmount > 0)
          {
            IUnit unit = target.Unit;
            //if (!unit.ContainsPassiveAbility((PassiveAbilityTypes) 45))
              //unit.AddPassiveAbility(this._passiveToAdd);
            //int num5 = unit.GetStoredValue((UnitStoredValueNames) 14) + num1;
            //unit.SetStoredValue((UnitStoredValueNames) 14, num5);
                        CombatManager.Instance.AddSubAction(new AddParasitismSubAction(unit, num1, this._passiveToAdd));
          }
        }
      }
      if (!this._indirect && num1 > 0)
        caster.DidApplyDamage(num1);
      return exitAmount > 0;
    }
  }
    public class AddParasitismSubAction : CombatAction
    {
        public IUnit unit;
        public int amount;
        public BasePassiveAbilitySO passive;
        public AddParasitismSubAction(IUnit unit, int amount, BasePassiveAbilitySO passive)
        {
            this.unit = unit;
            this.amount = amount;
            this.passive = passive;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            unit.AddPassiveAbility(passive);
            int num5 = unit.GetStoredValue((UnitStoredValueNames)14) + amount;
            unit.SetStoredValue((UnitStoredValueNames)14, num5);
            yield return null;
        }
    }
}
