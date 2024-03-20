// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Pineapple
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace TevlevsRapscallions
{
  public static class Pineapple
  {
    public static bool ItemExists()
    {
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        if (characterCombat.HasUsableItem && characterCombat.HeldItem._itemName.Contains("Wicked Pineapple"))
          return true;
      }
      return false;
    }

    public static bool ApplySlotStatusEffect(
      Func<CombatSlot, ISlotStatusEffect, int, bool> orig,
      CombatSlot self,
      ISlotStatusEffect statusEffect,
      int amount)
    {
      if (statusEffect.EffectType == tevlevsRapscallions.Bubble.slotStatusEffectType || !Pineapple.ItemExists())
        return orig(self, statusEffect, amount);
      bool flag1 = false;
      int num1 = statusEffect.DeepCopy(0).JustRemoveAllContent();
      int defense = Math.Max(0, (int) Math.Ceiling((double) num1 / 2.0));
      int num2 = defense - num1;
      if (defense >= 1 && num2 < 0)
        statusEffect.TryAddContent(num2);
      bool flag2 = orig(self, statusEffect, defense < 1 || num2 >= 0 ? amount : defense);
      if (defense > 0)
      {
        Bubbles_SlotStatusEffect slotStatusEffect = new Bubbles_SlotStatusEffect(self.SlotID, defense, self.IsCharacter);
        slotStatusEffect.SetEffectInformation(tevlevsRapscallions.Bubble);
        flag1 = orig(self, (ISlotStatusEffect) slotStatusEffect, defense);
      }
      return flag2 | flag1;
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CombatSlot).GetMethod("ApplySlotStatusEffect", ~BindingFlags.Default), typeof (Pineapple).GetMethod("ApplySlotStatusEffect", ~BindingFlags.Default));
    }
  }
}
