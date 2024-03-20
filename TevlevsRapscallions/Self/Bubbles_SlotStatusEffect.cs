// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Bubbles_SlotStatusEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System;

#nullable disable
namespace TevlevsRapscallions
{
  public class Bubbles_SlotStatusEffect : ISlotStatusEffect, ITriggerEffect<IUnit>
  {
    public int Attack = 0;

    public int Restrictor { get; set; }

    public bool CanBeRemoved => this.Restrictor <= 0;

    public bool IsPositive => true;

    public string DisplayText
    {
      get
      {
        string displayText = "";
        if (this.Defense > 0)
          displayText += this.Defense.ToString();
        if (this.Restrictor > 0)
          displayText = displayText + "(" + this.Restrictor.ToString() + ")";
        return displayText;
      }
    }

    public int Defense { get; set; }

    public int SlotID { get; set; }

    public bool IsCharacterSlot { get; set; }

    public ISlotStatusEffector Effector { get; set; }

    public SlotStatusEffectType EffectType => (SlotStatusEffectType) 866795;

    public SlotStatusEffectInfoSO EffectInfo { get; set; }

    public Bubbles_SlotStatusEffect(
      int slotID,
      int defense,
      bool isCharacterSlot,
      int restrictors = 0)
    {
      this.SlotID = slotID;
      this.Defense = defense;
      this.Restrictor = restrictors;
      this.IsCharacterSlot = isCharacterSlot;
    }

    public void SetEffectInformation(SlotStatusEffectInfoSO effectInfo)
    {
      this.EffectInfo = effectInfo;
    }

    public ISlotStatusEffect DeepCopy(int newSlotID)
    {
      Bubbles_SlotStatusEffect slotStatusEffect = new Bubbles_SlotStatusEffect(newSlotID, this.Defense, this.IsCharacterSlot, this.Restrictor);
      slotStatusEffect.SetEffectInformation(this.EffectInfo);
      return (ISlotStatusEffect) slotStatusEffect;
    }

    public bool AddContent(ISlotStatusEffect content)
    {
      this.Defense += (content as Bubbles_SlotStatusEffect).Defense;
      this.Restrictor += content.Restrictor;
      return true;
    }

    public bool TryAddContent(int amount)
    {
      if (this.Defense <= 0)
        return false;
      this.Defense += amount;
      return true;
    }

    public int JustRemoveAllContent()
    {
      int defense = this.Defense;
      this.Defense = 0;
      return defense;
    }

    public void OnTriggerAttached(IUnit caller)
    {
      caller.AddFieldEffect(this.EffectType);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 5).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnSecondStatusTriggered), ((TriggerCalls) 14).ToString(), (object) caller);
    }

    public void OnTriggerDettached(IUnit caller)
    {
      caller.RemoveFieldEffect(this.EffectType);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 5).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnSecondStatusTriggered), ((TriggerCalls) 14).ToString(), (object) caller);
    }

    public void OnEffectorTriggerAttached(ISlotStatusEffector caller)
    {
      this.Effector = caller;
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) 7).ToString(), (object) this.Effector);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) 866795).ToString(), (object) this.Effector);
    }

    public void OnEffectorTriggerDettached()
    {
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) 7).ToString(), (object) this.Effector);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) 866795).ToString(), (object) this.Effector);
    }

    public void OnSubActionTrigger(object sender, object args)
    {
      IUnit iunit = sender as IUnit;
      if (iunit.Damage(this.Attack, (IUnit) null, (DeathType) 1, 0, false, true, true, (DamageType) 866795).damageAmount <= 0)
        return;
      CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new AddManaToManaBarAction(PYMNHere.Mentos.GetRandom<ManaColorSO>(), 1, iunit.IsUnitCharacter, iunit.ID), false);
      if (iunit.IsUnitCharacter)
        return;
      CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new AddManaToManaBarAction(PYMNHere.Mentos.GetRandom<ManaColorSO>(), 1, iunit.IsUnitCharacter, iunit.ID), false);
    }

    public void OnStatusTick(object sender, object args)
    {
      int defense = this.Defense;
      ++this.Defense;
      if (this.TryRemoveSlotStatusEffect())
        return;
      this.Effector.SlotStatusEffectValuesChanged(this.EffectType, false, this.Defense - defense, false);
    }

    public void OnStatusTriggered(object sender, object args)
    {
      this.Attack = this.Defense;
      CombatManager.Instance.AddSubAction((CombatAction) new PerformSlotStatusEffectAction((ISlotStatusEffect) this, sender, args));
      this.Effector.RemoveSlotStatusEffect(this.EffectType);
    }

    public void OnSecondStatusTriggered(object sender, object args)
    {
      IUnit iunit = sender as IUnit;
      if (!iunit.IsUnitCharacter)
        return;
      iunit.Heal(this.Defense, (HealType) 866795, true);
      this.Effector.RemoveSlotStatusEffect(this.EffectType);
    }

    public void DettachRestrictor()
    {
      --this.Restrictor;
      if (this.TryRemoveSlotStatusEffect())
        return;
      this.Effector.SlotStatusEffectValuesChanged(this.EffectType, false, 0, false);
    }

    public bool TryRemoveSlotStatusEffect()
    {
      if (this.Defense > 0 || !this.CanBeRemoved)
        return false;
      this.Effector.RemoveSlotStatusEffect(this.EffectType);
      return true;
    }
  }
}
