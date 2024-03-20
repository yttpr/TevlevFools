// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GilbertPassiveStuff
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace TevlevsRapscallions
{
  public class GilbertPassiveStuff
  {
    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("AddExtraAbility", ~BindingFlags.Default), typeof (GilbertPassiveStuff).GetMethod("AddExtraAbility", ~BindingFlags.Default));
    }

    public static void AddExtraAbility(
      Action<CharacterCombat, ExtraAbilityInfo> orig,
      CharacterCombat self,
      ExtraAbilityInfo info)
    {
      orig(self, info);
      if (!self.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
        return;
      foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
      {
        if (enemy.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
          CombatManager.Instance.AddSubAction((CombatAction) new AddExtraAbilityGilbertEnemyAction(enemy, info));
      }
    }

    public static PassiveAbilityTypes Gilb => (PassiveAbilityTypes) 739071;

    public static TriggerCalls extra => (TriggerCalls) 372910;
  }
}
