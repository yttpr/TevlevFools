// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.PlayAbilityAnimationGivenAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;

#nullable disable
namespace TevlevsRapscallions
{
  public class PlayAbilityAnimationGivenAction : CombatAction
  {
    public TargetSlotInfo[] _targetting;
    public AttackVisualsSO _visuals;
    public IUnit _caster;
    public bool aretargetSlots;

    public PlayAbilityAnimationGivenAction(
      AttackVisualsSO visuals,
      TargetSlotInfo[] targetting,
      IUnit caster,
      bool aretargetSlots)
    {
      this._visuals = visuals;
      this._targetting = targetting;
      this._caster = caster;
      this.aretargetSlots = aretargetSlots;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      TargetSlotInfo[] targets = (TargetSlotInfo[]) null;
      bool areTargetSlots = true;
      if (this._targetting != null)
      {
        targets = this._targetting;
        areTargetSlots = this.aretargetSlots;
      }
      yield return (object) stats.combatUI.PlayAbilityAnimation(this._visuals, targets, areTargetSlots);
    }
  }
}
