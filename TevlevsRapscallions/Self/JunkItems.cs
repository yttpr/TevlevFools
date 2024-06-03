// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.JunkItems
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class JunkItems
  {
    public static TriggerCalls Call => (TriggerCalls) 282046;

    public static void add()
    {
      DamageEffect instance = ScriptableObject.CreateInstance<DamageEffect>();
      instance._indirect = true;
      EffectItem effectItem1 = new EffectItem();
      effectItem1.name = "Sharp Junk";
      effectItem1.flavorText = "\"Yeouch!\"";
      effectItem1.description = "Upon this item being consumed, deal 2 indirect damage to the Opposing enemy.";
      effectItem1.sprite = ResourceLoader.LoadSprite("JunkSharp");
      effectItem1.unlockableID = (UnlockableID) 87534;
      effectItem1.shopPrice = 0;
      effectItem1.namePopup = true;
      effectItem1.immediate = true;
      effectItem1.itemPools = ItemPools.Extra;
      effectItem1.effects = new Effect[1]
      {
        new Effect( instance, 2, new IntentType?(), Slots.Front)
      };
      effectItem1.trigger = JunkItems.Call;
      EffectItem effectItem2 = new EffectItem();
      effectItem2.name = "Smooth Junk";
      effectItem2.flavorText = "\"Calming aesthetic\"";
      effectItem2.description = "Upon this item being consumed, heal 2 health to this party member.";
      effectItem2.sprite = ResourceLoader.LoadSprite("JunkSmooth");
      effectItem2.unlockableID = (UnlockableID) 88534;
      effectItem2.shopPrice = 0;
      effectItem2.namePopup = true;
      effectItem2.immediate = true;
      effectItem2.itemPools = ItemPools.Extra;
      effectItem2.effects = new Effect[1]
      {
        new Effect( ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?(), Slots.Self)
      };
      effectItem2.trigger = JunkItems.Call;
      EffectItem effectItem3 = new EffectItem();
      effectItem3.name = "Rusty Junk";
      effectItem3.flavorText = "\"Ball of Tetanus\"";
      effectItem3.description = "Upon this item being consumed, inflict 2 of a random negative status effect to the Opposing enemy.";
      effectItem3.sprite = ResourceLoader.LoadSprite("JunkRusty");
      effectItem3.unlockableID = (UnlockableID) 89534;
      effectItem3.shopPrice = 0;
      effectItem3.namePopup = true;
      effectItem3.immediate = true;
      effectItem3.itemPools = ItemPools.Extra;
      effectItem3.effects = new Effect[1]
      {
        new Effect( ScriptableObject.CreateInstance<ApplyRandomStatusEffectEffect>(), 2, new IntentType?(), Slots.Front)
      };
      effectItem3.trigger = JunkItems.Call;
      EffectItem effectItem4 = new EffectItem();
      effectItem4.name = "Flashy Junk";
      effectItem4.flavorText = "\"Shiny Aluminum\"";
      effectItem4.description = "Upon this item being consumed, gain 2 coins.";
      effectItem4.sprite = ResourceLoader.LoadSprite("JunkShiny");
      effectItem4.unlockableID = (UnlockableID) 90534;
      effectItem4.shopPrice = 0;
      effectItem4.namePopup = true;
      effectItem4.immediate = true;
      effectItem4.itemPools = ItemPools.Extra;
      effectItem4.effects = new Effect[1]
      {
        new Effect( ScriptableObject.CreateInstance<GainPlayerCurrencyEffect>(), 2, new IntentType?(), Slots.Self)
      };
      effectItem4.trigger = JunkItems.Call;
      effectItem1.AddItem();
      effectItem2.AddItem();
      effectItem3.AddItem();
      effectItem4.AddItem();
    }
  }
}
