// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AbilityNameFix
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class AbilityNameFix
  {
    public static global::CharacterAbility CharacterAbility(
      Func<Ability, global::CharacterAbility> orig,
      Ability self)
    {
      global::CharacterAbility characterAbility = orig(self);
      characterAbility.ability._abilityName = self.name;
      characterAbility.ability._description = self.description;
      ( characterAbility.ability).name = self.name;
      return characterAbility;
    }

    public static EnemyAbilityInfo EnemyAbility(Func<Ability, EnemyAbilityInfo> orig, Ability self)
    {
      EnemyAbilityInfo enemyAbilityInfo = orig(self);
      enemyAbilityInfo.ability._abilityName = self.name;
      enemyAbilityInfo.ability._description = self.description;
      ( enemyAbilityInfo.ability).name = self.name;
      return enemyAbilityInfo;
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (Ability).GetMethod("CharacterAbility", ~BindingFlags.Default), typeof (AbilityNameFix).GetMethod("CharacterAbility", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (Ability).GetMethod("EnemyAbility", ~BindingFlags.Default), typeof (AbilityNameFix).GetMethod("EnemyAbility", ~BindingFlags.Default));
    }
  }
}
