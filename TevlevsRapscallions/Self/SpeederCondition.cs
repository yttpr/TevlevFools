// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SpeederCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class SpeederCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is ObjectHolder objectHolder && objectHolder.args is EnemyCombat args1 && effector is CharacterCombat characterCombat)
      {
                if (args1.GetStoredValue(SpeederHandler.moved) > 2)
                {
                    if (characterCombat.HasUsableItem)
                        CombatManager.Instance.AddUIAction((CombatAction)new ShowItemInformationUIAction(characterCombat.ID, characterCombat.HeldItem._itemName, false, characterCombat.HeldItem.wearableImage));
                    int num2 = characterCombat.WillApplyDamage(8, (IUnit)args1);
                    args1.Damage(num2, (IUnit)characterCombat, (DeathType)1, -1, true, true, false, (DamageType)0);
                    Constricted_SlotStatusEffect slotStatusEffect = new Constricted_SlotStatusEffect(args1.SlotID, 2, 0);
                    try
                    {
                        slotStatusEffect.SetEffectInformation(CombatManager.Instance._stats.slotStatusEffectDataBase[(SlotStatusEffectType)1]);
                    }
                    catch
                    {
                    }
                    CombatManager.Instance._stats.combatSlots.ApplySlotStatusEffect(args1.SlotID, args1.IsUnitCharacter, 2, (ISlotStatusEffect)slotStatusEffect, args1.Size);
                }
            }
      
      return false;
    }
  }
}
