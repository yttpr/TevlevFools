// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AddExtraAbilitiesEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class AddExtraAbilitiesEffect : EffectSO
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
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          for (int index = 0; index < entryVariable && target.Unit.AbilityCount < 6; ++index)
          {
            target.Unit.AddExtraAbility(tevlevsRapscallions.GetRandomItemAbility());
            ++exitAmount;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
