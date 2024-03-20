// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.PermaFleeCasterEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class PermaFleeCasterEffect : EffectSO
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
      if (caster is CharacterCombat characterCombat)
      {
        characterCombat.SilentCharacterDeath((DeathType) 0);
        CombatManager.Instance.AddSubAction((CombatAction) new CharacterDeathFleeAnimationAction(characterCombat.ID, (IUnit) null, (DeathType) 0));
      }
      return true;
    }
  }
}
