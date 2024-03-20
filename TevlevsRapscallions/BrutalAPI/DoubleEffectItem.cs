﻿// Decompiled with JetBrains decompiler
// Type: BrutalAPI.DoubleEffectItem
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace BrutalAPI
{
  public class DoubleEffectItem : Item
  {
    public Effect[] firstEffects = new Effect[0];
    public Effect[] secondEffects = new Effect[0];
    public bool _firsteEffectImmediate = false;
    public bool _secondImmediateEffect = false;
    public TriggerCalls[] SecondTrigger = new TriggerCalls[0];
    public TriggerCalls[] FirstTrigger = new TriggerCalls[0];
    public bool firstPopUp = true;
    public bool secondPopUp = true;
    public EffectorConditionSO[] secondTriggerConditions = new EffectorConditionSO[0];

    public override BaseWearableSO Wearable()
    {
      CustomDoublePerformEffectWearable instance = ScriptableObject.CreateInstance<CustomDoublePerformEffectWearable>();
      ((BaseWearableSO) instance).BaseWearable((Item) this);
      instance._firstEffects = ExtensionMethods.ToEffectInfoArray(this.firstEffects);
      instance._firstImmediateEffect = this._firsteEffectImmediate;
      ((BaseWearableSO) instance).doesItemPopUp = this.firstPopUp;
      instance._secondEffects = ExtensionMethods.ToEffectInfoArray(this.secondEffects);
      instance._secondImmediateEffect = this._firsteEffectImmediate;
      instance._secondPerformTriggersOn = this.SecondTrigger;
      instance._secondDoesPerformItemPopUp = this.secondPopUp;
      instance._secondPerformConditions = this.secondTriggerConditions;
      return (BaseWearableSO) instance;
    }
  }
}
