// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ExtraLootForEachPassiveAmountList
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ExtraLootForEachPassiveAmountList : EffectSO
  {
    [SerializeField]
    [Range(0.0f, 100f)]
    public int _nothingPercentage = 40;
    [SerializeField]
    [Range(0.0f, 100f)]
    public int _shopPercentage = 1;
    [SerializeField]
    [Range(0.0f, 100f)]
    public int _treasurePercentage = 1;
    [SerializeField]
    public LootItemProbability[] _lockedLootableItems;
    [SerializeField]
    public LootItemProbability[] _lootableItems;
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 5;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      int num1 = 0 + (this._nothingPercentage + this._shopPercentage + this._treasurePercentage);
      foreach (LootItemProbability lockedLootableItem in this._lockedLootableItems)
      {
        if (stats.IsGameRun && stats.InfoHolder.Game.IsItemUnlocked(lockedLootableItem.itemName))
          num1 += lockedLootableItem.probability;
      }
      foreach (LootItemProbability lootableItem in this._lootableItems)
        num1 += lootableItem.probability;
      entryVariable = caster.GetStoredValue(this._valueName);
      for (int index = 0; index < entryVariable; ++index)
      {
        int num2 = Random.Range(0, num1);
        if (num2 >= this._nothingPercentage)
        {
          int num3 = num2 - this._nothingPercentage;
          if (num3 < this._shopPercentage)
          {
            stats.AddShopItemLoot(1, false);
            ++exitAmount;
          }
          else
          {
            int num4 = num3 - this._shopPercentage;
            if (num4 < this._treasurePercentage)
            {
              stats.AddTreasureLoot(1, false);
              ++exitAmount;
            }
            else
            {
              int num5 = num4 - this._treasurePercentage;
              foreach (LootItemProbability lockedLootableItem in this._lockedLootableItems)
              {
                if (!stats.IsGameRun || stats.InfoHolder.Game.IsItemUnlocked(lockedLootableItem.itemName))
                {
                  if (num5 < lockedLootableItem.probability)
                  {
                    stats.AddExtraLootAddition(lockedLootableItem.itemName);
                    ++exitAmount;
                    break;
                  }
                  num5 -= lockedLootableItem.probability;
                }
              }
              foreach (LootItemProbability lootableItem in this._lootableItems)
              {
                if (num5 < lootableItem.probability)
                {
                  stats.AddExtraLootAddition(lootableItem.itemName);
                  ++exitAmount;
                  break;
                }
                num5 -= lootableItem.probability;
              }
            }
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
