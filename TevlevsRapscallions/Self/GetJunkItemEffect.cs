// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GetJunkItemEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class GetJunkItemEffect : EffectSO
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
      LootItemProbability lootItemProbability1;
      lootItemProbability1.itemName = "SharpJunk_EW";
      lootItemProbability1.probability = 1;
      LootItemProbability lootItemProbability2;
      lootItemProbability2.itemName = "SmoothJunk_EW";
      lootItemProbability2.probability = 1;
      LootItemProbability lootItemProbability3;
      lootItemProbability3.itemName = "RustyJunk_EW";
      lootItemProbability3.probability = 1;
      LootItemProbability lootItemProbability4;
      lootItemProbability4.itemName = "SharpJunk_EW";
      lootItemProbability4.probability = 1;
      //Debug.Log((object) "sillycaller");
      if (UnityEngine.Random.Range(0, 100) < entryVariable)
            {
                if (UnityEngine.Random.Range(0, 100) < 50) stats.AddTreasureLoot(1, false);
                else stats.AddShopItemLoot(1, false);
            }
            else
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        //Debug.Log((object) "cases and vases");
                        stats.AddExtraLootAddition(lootItemProbability1.itemName);
                        break;
                    case 1:
                        //Debug.Log((object) "cases and vases");
                        stats.AddExtraLootAddition(lootItemProbability2.itemName);
                        break;
                    case 2:
                        //Debug.Log((object) "cases and vases");
                        stats.AddExtraLootAddition(lootItemProbability3.itemName);
                        break;
                    case 3:
                        //Debug.Log((object) "cases and vases");
                        stats.AddExtraLootAddition(lootItemProbability4.itemName);
                        break;
                    default: goto case 0;
                }
            }
      //Debug.Log((object) "silly");
      return true;
    }
  }
}
