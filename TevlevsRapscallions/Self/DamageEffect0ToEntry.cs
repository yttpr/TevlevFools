// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.DamageEffect0ToEntry
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class DamageEffect0ToEntry : EffectSO
  {
    public bool Dealing;
    public bool IgnoreShield;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      int num = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          ++num;
          exitAmount += target.Unit.Damage(this.Dealing ? caster.WillApplyDamage(Random.Range(0, entryVariable + 1), target.Unit) : Random.Range(0, entryVariable + 1), this.Dealing ? caster : (IUnit) null, (DeathType) 1, areTargetSlots ? target.SlotID - target.Unit.SlotID : -1, true, true, this.IgnoreShield, (DamageType) 0).damageAmount;
        }
      }
      return num > 0;
    }

    public static DamageEffect0ToEntry Create(bool Dealing)
    {
      DamageEffect0ToEntry instance = ScriptableObject.CreateInstance<DamageEffect0ToEntry>();
      instance.Dealing = Dealing;
      return instance;
    }
  }
}
