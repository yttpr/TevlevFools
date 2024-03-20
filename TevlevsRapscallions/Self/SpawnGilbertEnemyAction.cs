// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SpawnGilbertEnemyAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;

#nullable disable
namespace TevlevsRapscallions
{
  public class SpawnGilbertEnemyAction : CombatAction
  {
    public int _preferredSlot;
    public EnemySO _enemy;
    public bool _givesExperience;
    public bool _trySpawnAnyways;
    public SpawnType _spawnType;
    public int health;

    public SpawnGilbertEnemyAction(
      EnemySO enemy,
      int preferredSlot,
      bool givesExperience,
      bool trySpawnAnyways,
      SpawnType spawnType,
      int health)
    {
      this._preferredSlot = preferredSlot;
      this._givesExperience = givesExperience;
      this._enemy = enemy;
      this._trySpawnAnyways = trySpawnAnyways;
      this._spawnType = spawnType;
      this.health = health;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      int num;
      if (this._preferredSlot >= 0)
      {
        num = stats.combatSlots.GetEnemyFitSlot(this._preferredSlot, this._enemy.size);
        if (num == -1 && this._trySpawnAnyways)
          num = stats.GetRandomEnemySlot(this._enemy.size);
      }
      else
        num = stats.GetRandomEnemySlot(this._enemy.size);
      if (num != -1)
        stats.AddNewGilbert(this._enemy, num, this._givesExperience, this._spawnType, this.health);
      yield return (object) null;
    }
  }
}
