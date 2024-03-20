// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SpawnEnemyExplodeGilbertAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class SpawnEnemyExplodeGilbertAction : CombatAction
  {
    public int _preferredSlot;
    public EnemySO _enemy;
    public bool _givesExperience;
    public bool _trySpawnAnyways;
    public SpawnType _spawnType;
    public int health;
    public static TriggerCalls Call = (TriggerCalls) 899130;

    public static void CallAll()
    {
      foreach (EnemyCombat enemyCombat in CombatManager.Instance._stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(SpawnEnemyExplodeGilbertAction.Call.ToString(), (object) enemyCombat, (object) null);
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(SpawnEnemyExplodeGilbertAction.Call.ToString(), (object) characterCombat, (object) null);
    }

    public SpawnEnemyExplodeGilbertAction(
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
      try
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
        {
          int orig = this._enemy.health;
          this._enemy.health = this.health;
          SpawnEnemyExplodeGilbertAction.CallAll();
          stats.AddNewEnemy(this._enemy, num, this._givesExperience, this._spawnType);
          this._enemy.health = orig;
        }
      }
      catch
      {
        Debug.LogWarning((object) "withering or somefuckshit");
      }
      yield return (object) null;
    }
  }
}
