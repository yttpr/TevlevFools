// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.EnterCasterMutalismEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class EnterCasterMutalismEffect : EffectSO
  {
    [SerializeField]
    public BasePassiveAbilitySO _passiveToAdd = Passives.Mutualism;
    [SerializeField]
    public UnboxUnitHandlerSO unboxHandler = ((CasterBoxingEffect) LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[6].effect)._unboxHandler;

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
        if (targets[index].HasUnit)
        {
          if (targets[index].HasUnit && targets[index].Unit.ContainsPassiveAbility((PassiveAbilityTypes) 45))
            targets[index].Unit.TryRemovePassiveAbility((PassiveAbilityTypes) 45, true);
          if (caster.ContainsPassiveAbility((PassiveAbilityTypes) 45))
            caster.TryRemovePassiveAbility((PassiveAbilityTypes) 45, true);
          if (caster.IsAlive && caster.AddPassiveAbility(this._passiveToAdd))
          {
            int num1 = Mathf.Max(1, targets[index].Unit.CurrentHealth);
            int num2 = targets[index].Unit.IsUnitCharacter ? 1 + targets[index].Unit.ID : -(1 + targets[index].Unit.ID);
            caster.SetStoredValue((UnitStoredValueNames) 13, num2);
            caster.SetStoredValue((UnitStoredValueNames) 14, num1);
            exitAmount += num2;
          }
          if (targets[index].Unit.IsUnitCharacter)
          {
            int id = caster.ID;
            bool isUnitCharacter = caster.IsUnitCharacter;
            CombatManager.Instance.AddUIAction((CombatAction) new PlaySpriteJumpUIAction(targets[index].Unit.UnitTurnSprite, stats.GenerateUnitJumpInformation(targets[index].Unit.ID, targets[index].Unit.IsUnitCharacter), id, isUnitCharacter));
            stats.TryBoxCharacter(targets[index].Unit.ID, this.unboxHandler, (UnitExitType) 2);
          }
          else
          {
            int id = caster.ID;
            bool isUnitCharacter = caster.IsUnitCharacter;
            CombatManager.Instance.AddUIAction((CombatAction) new PlaySpriteJumpUIAction(targets[index].Unit.UnitTurnSprite, stats.GenerateUnitJumpInformation(targets[index].Unit.ID, targets[index].Unit.IsUnitCharacter), id, isUnitCharacter));
            stats.TryBoxEnemy(targets[index].Unit.ID, this.unboxHandler, (UnitExitType) 2);
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
