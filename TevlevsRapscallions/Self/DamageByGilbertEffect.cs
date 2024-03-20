// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.DamageByGilbertEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class DamageByGilbertEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      int num1 = 0;
      for (int index = 0; index < targets.Length; ++index)
      {
        TargetSlotInfo target = targets[index];
        if (target.HasUnit && !target.Unit.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
        {
          foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
          {
            if (enemyCombat.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
            {
              num1 += enemyCombat.MaximumHealth;
              enemyCombat.DirectDeath(caster, false);
            }
          }
          int num2 = caster.WillApplyDamage(num1, target.Unit);
          DamageInfo damageInfo = target.Unit.Damage(num2, caster, (DeathType) 1, areTargetSlots ? target.SlotID - target.Unit.SlotID : -1, true, true, false, (DamageType) 0);
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
