// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.HalveDamageCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class HalveDamageCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is DamageReceivedValueChangeException valueChangeException && valueChangeException.amount > 0)
        valueChangeException.AddModifier((IntValueModifier) new MultiplyFloatModifier(0.5f, false, false));
      return true;
    }
  }
}
