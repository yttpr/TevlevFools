// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AddedSlotsFrontTimelineUIAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class AddedSlotsFrontTimelineUIAction : CombatAction
  {
    public TurnUIInfo[] _enemyTurns;

    public AddedSlotsFrontTimelineUIAction(TurnUIInfo[] enemyTurns)
    {
      this._enemyTurns = enemyTurns;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      Debug.Log((object) "Added slots front timeline ui action");
      yield return (object) stats.combatUI.AddFrontTimelineSlots(this._enemyTurns);
    }
  }
}
