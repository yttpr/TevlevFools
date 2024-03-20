// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SpawnSelfGilbertEnemyAnywhereEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class SpawnSelfGilbertEnemyAnywhereEffect : EffectSO
  {
    public bool givesExperience;
    [SerializeField]
    public SpawnType _spawnType = (SpawnType) 1;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (caster.IsUnitCharacter)
        return false;
      EnemySO enemy = (caster as EnemyCombat).Enemy;
      for (int index = 0; index < entryVariable; ++index)
        CombatManager.Instance.AddSubAction((CombatAction) new SpawnGilbertEnemyAction(enemy, -1, this.givesExperience, false, this._spawnType, caster.MaximumHealth));
      exitAmount = entryVariable;
      return true;
    }
  }
}
