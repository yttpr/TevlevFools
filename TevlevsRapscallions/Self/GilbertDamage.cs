// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GilbertDamage
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class GilbertDamage
  {
    public static int WillApplyDamageCH(
      Func<CharacterCombat, int, IUnit, int> orig,
      CharacterCombat self,
      int amount,
      IUnit targetUnit)
    {
      if (self.ContainsPassiveAbility(GilbertPassiveStuff.Gilb) && targetUnit.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
      {
        if (amount > 0)
          amount = Math.Max(1, (int) Math.Floor((double) ((float) amount / 2f)));
        List<int> intList = new List<int>()
        {
          self.ID,
          targetUnit.ID
        };
        List<bool> boolList = new List<bool>()
        {
          self.IsUnitCharacter,
          targetUnit.IsUnitCharacter
        };
        List<string> stringList = new List<string>()
        {
          ShitBurg.Gilby._passiveName,
          ShitBurg.Gilby._passiveName
        };
        List<Sprite> spriteList = new List<Sprite>()
        {
          ShitBurg.Gilby.passiveIcon,
          ShitBurg.Gilby.passiveIcon
        };
        CombatManager.Instance.AddUIAction((CombatAction) new ShowMultiplePassiveInformationUIAction(intList.ToArray(), boolList.ToArray(), stringList.ToArray(), spriteList.ToArray()));
      }
      return orig(self, amount, targetUnit);
    }

    public static int WillApplyDamageEN(
      Func<EnemyCombat, int, IUnit, int> orig,
      EnemyCombat self,
      int amount,
      IUnit targetUnit)
    {
      if (self.ContainsPassiveAbility(GilbertPassiveStuff.Gilb) && targetUnit.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
      {
        if (amount > 0)
          amount = Math.Max(1, (int) Math.Floor((double) ((float) amount / 2f)));
        List<int> intList = new List<int>()
        {
          self.ID,
          targetUnit.ID
        };
        List<bool> boolList = new List<bool>()
        {
          self.IsUnitCharacter,
          targetUnit.IsUnitCharacter
        };
        List<string> stringList = new List<string>()
        {
          ShitBurg.Gilby._passiveName,
          ShitBurg.Gilby._passiveName
        };
        List<Sprite> spriteList = new List<Sprite>()
        {
          ShitBurg.Gilby.passiveIcon,
          ShitBurg.Gilby.passiveIcon
        };
        CombatManager.Instance.AddUIAction((CombatAction) new ShowMultiplePassiveInformationUIAction(intList.ToArray(), boolList.ToArray(), stringList.ToArray(), spriteList.ToArray()));
      }
      return orig(self, amount, targetUnit);
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (GilbertDamage).GetMethod("WillApplyDamageCH", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (GilbertDamage).GetMethod("WillApplyDamageEN", ~BindingFlags.Default));
    }
  }
}
