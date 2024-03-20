// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.RemoveFieldStatusEffectEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class RemoveFieldStatusEffectEffect : EffectSO
  {
    public SlotStatusEffectType statusEffectType = (SlotStatusEffectType) 0;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].IsTargetCharacterSlot)
          exitAmount += stats.combatSlots.CharacterSlots[targets[index].SlotID].TryRemoveSlotStatusEffect(this.statusEffectType);
        else
          exitAmount += stats.combatSlots.EnemySlots[targets[index].SlotID].TryRemoveSlotStatusEffect(this.statusEffectType);
      }
      return exitAmount > 0;
    }
  }
}
