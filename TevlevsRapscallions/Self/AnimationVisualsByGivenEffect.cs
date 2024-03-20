// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AnimationVisualsByGivenEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class AnimationVisualsByGivenEffect : AnimationVisualsEffect
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      CombatManager.Instance.AddUIAction((CombatAction) new PlayAbilityAnimationGivenAction(this._visuals, targets, caster, areTargetSlots));
      exitAmount = 0;
      return true;
    }
  }
}
