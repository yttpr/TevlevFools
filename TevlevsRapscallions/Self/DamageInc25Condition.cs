// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.DamageInc25Condition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class DamageInc25Condition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is DamageDealtValueChangeException valueChangeException)
        valueChangeException.AddModifier((IntValueModifier) new MultiplyFloatModifier(1.25f, true, true));
      return true;
    }
  }
}
