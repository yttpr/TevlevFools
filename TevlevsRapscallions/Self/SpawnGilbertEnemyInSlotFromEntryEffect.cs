// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SpawnGilbertEnemyInSlotFromEntryEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class SpawnGilbertEnemyInSlotFromEntryEffect : EffectSO
  {
    public bool givesExperience;
    public bool trySpawnAnywhereIfFail;
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
      int index1 = Random.Range(0, 4);
      int maximumHealth = caster.MaximumHealth;
      if (caster is CharacterCombat characterCombat)
        index1 = characterCombat.Rank;
      EnemySO enemy = LoadedAssetsHandler.GetEnemy(ShitBurg.Gilberts[index1]);
      for (int index2 = targets.Length - 1; index2 >= 0; --index2)
      {
        if (!targets[index2].HasUnit)
          ++exitAmount;
        int preferredSlot = entryVariable + targets[index2].SlotID;
        CombatManager.Instance.AddSubAction((CombatAction) new SpawnGilbertEnemyAction(enemy, preferredSlot, this.givesExperience, this.trySpawnAnywhereIfFail, this._spawnType, maximumHealth));
      }
      return exitAmount > 0;
    }
  }
}
