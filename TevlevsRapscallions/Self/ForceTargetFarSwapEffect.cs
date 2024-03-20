// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ForceTargetFarSwapEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ForceTargetFarSwapEffect : EffectSO
  {
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
        if (target.HasUnit)
        {
          int num = Random.Range(0, 100);
          if (target.SlotID == 4)
          {
            CasterSwapAllTheWayToOneSideEffect instance = ScriptableObject.CreateInstance<CasterSwapAllTheWayToOneSideEffect>();
            instance._swapRight = false;
            CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
              new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self)
            }), target.Unit, 0));
            ++exitAmount;
          }
          else if (num <= 50 || target.SlotID == 0)
          {
            CasterSwapAllTheWayToOneSideEffect instance = ScriptableObject.CreateInstance<CasterSwapAllTheWayToOneSideEffect>();
            instance._swapRight = true;
            CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
              new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self)
            }), target.Unit, 0));
            ++exitAmount;
          }
          else
          {
            CasterSwapAllTheWayToOneSideEffect instance = ScriptableObject.CreateInstance<CasterSwapAllTheWayToOneSideEffect>();
            instance._swapRight = false;
            CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
              new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self)
            }), target.Unit, 0));
            ++exitAmount;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
