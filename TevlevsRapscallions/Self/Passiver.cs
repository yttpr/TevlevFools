// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Passiver
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class Passiver
  {
    private static BasePassiveAbilitySO _noStallWithering;

    public static BasePassiveAbilitySO Fleeting(int amount)
    {
      FleetingPassiveAbility fleetingPassiveAbility = Object.Instantiate<FleetingPassiveAbility>(Passives.Fleeting as FleetingPassiveAbility);
      ((BasePassiveAbilitySO) fleetingPassiveAbility)._passiveName = "Fleeting (" + amount.ToString() + ")";
      ((BasePassiveAbilitySO) fleetingPassiveAbility)._characterDescription = "After " + amount.ToString() + " rounds this party member will flee... Coward.";
      ((BasePassiveAbilitySO) fleetingPassiveAbility)._enemyDescription = "After " + amount.ToString() + " rounds this enemy will flee.";
      fleetingPassiveAbility._turnsBeforeFleeting = amount;
      return (BasePassiveAbilitySO) fleetingPassiveAbility;
    }

    public static BasePassiveAbilitySO Overexert(int amount)
    {
      IntegerReferenceOverEqualValueEffectorCondition instance = ScriptableObject.CreateInstance<IntegerReferenceOverEqualValueEffectorCondition>();
      instance.compareValue = amount;
      BasePassiveAbilitySO passiveAbilitySo = Object.Instantiate<BasePassiveAbilitySO>(LoadedAssetsHandler.GetEnemy("Scrungie_EN").passiveAbilities[2]);
      passiveAbilitySo._passiveName = "Overexert (" + amount.ToString() + ")";
      passiveAbilitySo._characterDescription = "Won't work with this version.";
      passiveAbilitySo._enemyDescription = "Upon receiving " + amount.ToString() + " or more direct damage, cancel 1 of this enemy's actions.";
      passiveAbilitySo.conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) instance
      };
      return passiveAbilitySo;
    }

    public static BasePassiveAbilitySO Leaky(int amount)
    {
      PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance)._passiveName = "Leaky (" + amount.ToString() + ")";
      ((BasePassiveAbilitySO) instance).passiveIcon = Passives.Leaky.passiveIcon;
      ((BasePassiveAbilitySO) instance)._enemyDescription = "Upon receiving direct damage, this enemy generates " + amount.ToString() + " extra pigment of its health color.";
      ((BasePassiveAbilitySO) instance)._characterDescription = "Upon receiving direct damage, this character generates " + amount.ToString() + " extra pigment of its health color.";
      ((BasePassiveAbilitySO) instance).type = (PassiveAbilityTypes) 32;
      ((BasePassiveAbilitySO) instance).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 12
      };
      instance.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), amount, new IntentType?(), Slots.Self)
      });
      return (BasePassiveAbilitySO) instance;
    }

    public static BasePassiveAbilitySO Multiattack(int amount)
    {
      IntegerSetterPassiveAbility setterPassiveAbility = Object.Instantiate<IntegerSetterPassiveAbility>(Passives.Multiattack as IntegerSetterPassiveAbility);
      ((BasePassiveAbilitySO) setterPassiveAbility)._passiveName = "Multi Attack (" + amount.ToString() + ")";
      ((BasePassiveAbilitySO) setterPassiveAbility)._characterDescription = "won't work boowomp";
      ((BasePassiveAbilitySO) setterPassiveAbility)._enemyDescription = "This enemy will perform " + amount.ToString() + " actions each turn.";
      setterPassiveAbility.integerValue = amount - 1;
      return (BasePassiveAbilitySO) setterPassiveAbility;
    }

    public static BasePassiveAbilitySO Inferno(int amount)
    {
      PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance)._passiveName = "Inferno (" + amount.ToString() + ")";
      ((BasePassiveAbilitySO) instance).passiveIcon = Passives.Inferno.passiveIcon;
      ((BasePassiveAbilitySO) instance)._enemyDescription = "On turn start, this enemy inflicts " + amount.ToString() + " Fire on their position.";
      ((BasePassiveAbilitySO) instance)._characterDescription = "On turn start, this character inflicts " + amount.ToString() + " Fire on their position.";
      ((BasePassiveAbilitySO) instance).type = (PassiveAbilityTypes) 28;
      ((BasePassiveAbilitySO) instance).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), amount, new IntentType?(), Slots.Self)
      });
      return (BasePassiveAbilitySO) instance;
    }

    public static BasePassiveAbilitySO Abomination
    {
      get => LoadedAssetsHandler.GetEnemy("OneManBand_EN").passiveAbilities[1];
    }

    public static BasePassiveAbilitySO NoStallWithering
    {
      get
      {
        if (_noStallWithering == null)
        {
          Passiver._noStallWithering = (BasePassiveAbilitySO) ScriptableObject.CreateInstance<NoStallWItheringPassiveAbility>();
          Passiver._noStallWithering._passiveName = Passives.Withering._passiveName;
          Passiver._noStallWithering.passiveIcon = Passives.Withering.passiveIcon;
          Passiver._noStallWithering._characterDescription = "If all remaining party members also have Withering, this party member will die.\nThis check is run repeatedly throughout combat.";
          Passiver._noStallWithering._enemyDescription = "If all remaining enemies also have Withering, this enemy will die.\nThis check is run repeatedly throughout combat.";
          Passiver._noStallWithering._triggerOn = new List<TriggerCalls>((IEnumerable<TriggerCalls>) Passives.Withering._triggerOn)
          {
            (TriggerCalls) 21,
            (TriggerCalls) 7,
            (TriggerCalls) 47,
            (TriggerCalls) 45,
            (TriggerCalls) 48
          }.ToArray();
          Passiver._noStallWithering.type = Passives.Withering.type;
          Passiver._noStallWithering.doesPassiveTriggerInformationPanel = false;
          Passiver._noStallWithering.conditions = new EffectorConditionSO[0];
        }
        return Passiver._noStallWithering;
      }
    }
  }
}
