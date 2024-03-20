// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.FieldEffectFixHook
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
  public static class FieldEffectFixHook
  {
    public static bool ApplySlotStatusEffect(
      Func<CombatSlot, ISlotStatusEffect, int, bool> orig,
      CombatSlot self,
      ISlotStatusEffect statusEffect,
      int amount)
    {
      bool flag = false;
      int index1 = -1;
      for (int index2 = 0; index2 < self.StatusEffects.Count; ++index2)
      {
        if (self.StatusEffects[index2].EffectType == statusEffect.EffectType && self.StatusEffects[index2].GetType() != statusEffect.GetType())
        {
          flag = true;
          index1 = index2;
          break;
        }
      }
      if (flag)
      {
        foreach (MethodBase constructor in self.StatusEffects[index1].GetType().GetConstructors())
        {
          ParameterInfo[] parameters = constructor.GetParameters();
          if (parameters.Length == 4 && parameters[0].ParameterType == typeof (int) && parameters[1].ParameterType == typeof (int) && parameters[2].ParameterType == typeof (bool) && parameters[3].ParameterType == typeof (int))
            statusEffect = (ISlotStatusEffect) Activator.CreateInstance(self.StatusEffects[index1].GetType(), (object) self.SlotID, (object) amount, (object) self.IsCharacter, (object) statusEffect.Restrictor);
          else if (parameters.Length == 3 && parameters[0].ParameterType == typeof (int) && parameters[1].ParameterType == typeof (int) && parameters[2].ParameterType == typeof (int))
            statusEffect = (ISlotStatusEffect) Activator.CreateInstance(self.StatusEffects[index1].GetType(), (object) self.SlotID, (object) amount, (object) statusEffect.Restrictor);
        }
      }
      try
      {
        return orig(self, statusEffect, amount);
      }
      catch
      {
        Debug.LogError((object) "super epic field effect compatibility failure!");
        return false;
      }
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CombatSlot).GetMethod("ApplySlotStatusEffect", ~BindingFlags.Default), typeof (FieldEffectFixHook).GetMethod("ApplySlotStatusEffect", ~BindingFlags.Default));
    }
  }
}
