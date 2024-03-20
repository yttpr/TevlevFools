// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.DoubleEffectCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class DoubleEffectCondition : EffectConditionSO
  {
    public EffectConditionSO first;
    public EffectConditionSO second;
    public bool And;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      return this.And ? this.first.MeetCondition(caster, effects, currentIndex) && this.second.MeetCondition(caster, effects, currentIndex) : this.first.MeetCondition(caster, effects, currentIndex) || this.second.MeetCondition(caster, effects, currentIndex);
    }

    public static DoubleEffectCondition Create(
      EffectConditionSO first,
      EffectConditionSO second,
      bool and)
    {
      DoubleEffectCondition instance = ScriptableObject.CreateInstance<DoubleEffectCondition>();
      instance.first = first;
      instance.second = second;
      instance.And = and;
      return instance;
    }
  }
}
