// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.BaddiesCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class BaddiesCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (!(args is DamageDealtValueChangeException valueChangeException))
        return true;
      int num = Random.Range(0, 11);
      if (effector is CharacterCombat characterCombat && characterCombat.HasUsableItem)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(characterCombat.ID, characterCombat.HeldItem._itemName + ": " + num.ToString(), false, characterCombat.HeldItem.wearableImage));
      else
        CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(effector.ID, "Boosting damage by: " + num.ToString(), false, (Sprite) null));
      valueChangeException.AddModifier((IntValueModifier) new AdditionValueModifier(true, num));
      return false;
    }
  }
}
