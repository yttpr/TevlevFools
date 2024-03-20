// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.FunnySillyYay
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine.InputSystem;

#nullable disable
namespace TevlevsRapscallions
{
  public static class FunnySillyYay
  {
    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (Keyboard).GetMethod("OnTextInput", ~BindingFlags.Default), typeof (FunnySillyYay).GetMethod("KeyPressed", ~BindingFlags.Default));
    }

    public static void KeyPressed(Action<Keyboard, char> orig, Keyboard self, char c)
    {
      orig(self, c);
      if (c != 'k')
        return;
      try
      {
        GilbStensionsTwo.ReadOutRound(CombatManager.Instance._stats.timeline.Round);
        CombatManager.Instance._stats.combatUI.ReadOutUI(CombatManager.Instance._stats.combatUI._timelineSlotInfo);
      }
      catch (Exception ex)
      {
      }
    }
  }
}
