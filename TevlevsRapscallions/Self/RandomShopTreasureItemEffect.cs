﻿// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.RandomShopTreasureItemEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class RandomShopTreasureItemEffect : EffectSO
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
      if (Random.Range(0, 100) < 50)
        stats.AddShopItemLoot(1, false);
      else
        stats.AddTreasureLoot(1, false);
      return true;
    }
  }
}
