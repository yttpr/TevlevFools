// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.FishWhisperPassive
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class FishWhisperPassive : PerformEffectPassiveAbility
  {
    public override void OnPassiveConnected(IUnit unit)
    {
      base.OnPassiveConnected(unit);
      CombatManager.Instance.AddSubAction((CombatAction) new FishWhisperAction());
    }
  }
}
