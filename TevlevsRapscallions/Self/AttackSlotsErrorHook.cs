// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AttackSlotsErrorHook
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class AttackSlotsErrorHook
  {
    public static void selectThisMove(
      Action<AttackListLayout, int, bool> orig,
      AttackListLayout self,
      int attackID,
      bool playSound)
    {
      if (self.CurrentAttackSelected >= self._attackSlots.Length)
        Debug.Log((object) "ITS FUCKED");
      else if (attackID >= self._attackSlots.Length)
        Debug.Log((object) "ITS FUCKED");
      else
        orig(self, attackID, playSound);
    }

    public static void Add()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (AttackListLayout).GetMethod("SelectAttack", ~BindingFlags.Default), typeof (AttackSlotsErrorHook).GetMethod("selectThisMove", ~BindingFlags.Default));
    }
  }
}
