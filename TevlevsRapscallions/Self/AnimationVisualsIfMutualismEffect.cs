// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AnimationVisualsIfMutualismEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class AnimationVisualsIfMutualismEffect : EffectSO
  {
    [Header("Visual")]
    [SerializeField]
    public AttackVisualsSO _visuals;
    [SerializeField]
    public BaseCombatTargettingSO _animationTarget;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.ContainsPassiveAbility((PassiveAbilityTypes) 45))
        {
          CombatManager.Instance.AddUIAction((CombatAction) new PlayAbilityAnimationAction(this._visuals, this._animationTarget, caster));
          return true;
        }
      }
      return false;
    }
  }
}
