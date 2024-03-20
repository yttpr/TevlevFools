﻿// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.RootActionEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class RootActionEffect : EffectSO
  {
    public Effect[] effects;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      EffectInfo[] effectInfoArray = ExtensionMethods.ToEffectInfoArray(this.effects);
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          CombatManager.Instance.AddRootAction((CombatAction) new EffectAction(effectInfoArray, target.Unit, 0));
          ++exitAmount;
        }
      }
      return exitAmount > 0;
    }

    public static RootActionEffect Create(Effect[] e)
    {
      RootActionEffect instance = ScriptableObject.CreateInstance<RootActionEffect>();
      instance.effects = e;
      return instance;
    }
  }
}
