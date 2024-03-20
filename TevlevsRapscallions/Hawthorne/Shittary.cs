// Decompiled with JetBrains decompiler
// Type: Hawthorne.Shittary
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace Hawthorne
{
  public static class Shittary
  {
    public static bool Done;

    public static void InitializeCombat(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      if (Shittary.Done)
        return;
      Shittary.Done = true;
      self.AddSubAction((CombatAction) new AddStatusToGameAction());
    }

    public static void Setup()
    {
      Shittary.Done = false;
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (Shittary).GetMethod("InitializeCombat", ~BindingFlags.Default));
    }
  }
}
