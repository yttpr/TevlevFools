// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ChangeHealthColorEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class ChangeHealthColorEffect : EffectSO
  {
    public ManaColorSO _color;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit && targets[index].Unit.ChangeHealthColor(this._color))
          ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
