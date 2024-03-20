// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.UpdateCharacterUIEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class UpdateCharacterUIEffect : EffectSO
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
      if (!caster.IsUnitCharacter)
        return false;
      foreach (CharacterCombatUIInfo characterCombatUiInfo in stats.combatUI._charactersInCombat.Values)
      {
        if (characterCombatUiInfo.SlotID == caster.SlotID)
        {
          characterCombatUiInfo.UpdateAttacks((caster as CharacterCombat).CombatAbilities.ToArray());
          ++exitAmount;
          break;
        }
      }
      if (stats.combatUI.UnitInInfoID == caster.ID && stats.combatUI.IsInfoFromCharacter == caster.IsUnitCharacter)
        CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new OnCharacterClickedImmediateAction(caster.ID), false);
      return exitAmount > 0;
    }
  }
}
