﻿// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.MultiEffectorCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class MultiEffectorCondition : EffectConditionSO
  {
    public EffectConditionSO[] conditions;
    public bool And = true;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      foreach (EffectConditionSO condition in this.conditions)
      {
        bool flag = condition.MeetCondition(caster, effects, currentIndex);
        if (this.And && !flag)
          return false;
        if (!this.And & flag)
          return true;
      }
      return this.And;
    }

    public static MultiCondition Create(EffectConditionSO[] cond, bool and = true)
    {
      MultiCondition instance = ScriptableObject.CreateInstance<MultiCondition>();
      instance.conditions = cond;
      instance.And = and;
      return instance;
    }

    public static MultiCondition Create(
      EffectConditionSO first,
      EffectConditionSO second,
      bool and = true)
    {
      MultiCondition instance = ScriptableObject.CreateInstance<MultiCondition>();
      instance.conditions = new EffectConditionSO[2]
      {
        first,
        second
      };
      instance.And = and;
      return instance;
    }
  }
}
