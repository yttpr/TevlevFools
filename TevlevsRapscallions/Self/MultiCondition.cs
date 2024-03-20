// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.MultiCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class MultiCondition : EffectConditionSO
  {
    public EffectConditionSO[] conditions;
    [SerializeField]
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

    public static MultiCondition Create(EffectConditionSO[] conditions)
    {
      MultiCondition instance = ScriptableObject.CreateInstance<MultiCondition>();
      instance.conditions = conditions;
      return instance;
    }
  }
}
