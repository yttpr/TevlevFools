// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.MultiAnimationEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class MultiAnimationEffect : EffectSO
  {
    public AnimationVisualsEffect[] visuals;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (this.visuals == null || this.visuals.Length == 0)
        return false;
      bool flag = false;
      for (int index = 0; index < entryVariable; ++index)
      {
        int num;
        if (((EffectSO) this.visuals.GetRandom<AnimationVisualsEffect>()).PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out num))
        {
          flag = true;
          exitAmount += num;
        }
      }
      return flag;
    }
  }
}
