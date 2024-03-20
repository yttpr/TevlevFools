// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AddGilbertSpecificAbilityEnemyTimelineAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class AddGilbertSpecificAbilityEnemyTimelineAction : CombatAction
  {
    public EnemyCombat enemy;
    public string Ability;

    public AddGilbertSpecificAbilityEnemyTimelineAction(EnemyCombat enemy, string Ability)
    {
      this.enemy = enemy;
      this.Ability = Ability;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      List<EnemyCombat> units = new List<EnemyCombat>();
      List<int> abilitySlots = new List<int>();
      int abilityIdFromName = this.enemy.GetGilbertAbilityIDFromName(this.Ability);
      if (abilityIdFromName >= 0)
      {
        units.Add(this.enemy);
        abilitySlots.Add(abilityIdFromName);
      }
      try
      {
        if (abilitySlots.Count > 0)
          stats.timeline.AddFrontExtraEnemyTurns(units, abilitySlots);
        else
          stats.timeline.TryAddNewFrontExtraEnemyTurns((ITurn) this.enemy, 1);
      }
      catch (Exception ex1)
      {
        Exception ex = ex1;
        Debug.LogError((object) "failed to add gilbert to front of timeline");
        if (abilitySlots.Count > 0)
          stats.timeline.AddExtraEnemyTurns(units, abilitySlots);
        else
          stats.timeline.TryAddNewExtraEnemyTurns((ITurn) this.enemy, 1);
      }
      yield return (object) null;
    }
  }
}
