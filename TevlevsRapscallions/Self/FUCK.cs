// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.FUCK
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public static class FUCK
  {
    public static void PermaFlee(this CharacterCombat self)
    {
      int currentHealth = self.CurrentHealth;
      self.CurrentHealth = 0;
      CombatManager.Instance.AddSubAction((CombatAction) new WhateverTheFuckAction(self.ID));
    }

    public static void CharacterDeathFleeAnim(
      this CharacterCombat self,
      DeathReference deathReference,
      DeathType deathType,
      out bool canBeRemoved)
    {
      self.IsAlive = false;
      self.DeathBy = deathType;
      if (deathReference.HasKiller && deathReference.killer.IsUnitCharacter)
        self.DeathBy = (DeathType) 3;
      CombatManager instance1 = CombatManager.Instance;
      TriggerCalls triggerCalls = (TriggerCalls) 10;
      string str1 = triggerCalls.ToString();
      CharacterCombat characterCombat1 = self;
      DeathReference deathReference1 = deathReference;
      instance1.PostNotification(str1, (object) characterCombat1, (object) deathReference1);
      if (deathReference.HasKiller)
      {
        CombatManager instance2 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 24;
        string str2 = triggerCalls.ToString();
        IUnit killer = deathReference.killer;
        CharacterCombat characterCombat2 = self;
        instance2.PostNotification(str2, (object) killer, (object) characterCombat2);
      }
      bool flag = deathType == (DeathType)4;
      CombatManager.Instance.AddUIAction((CombatAction) new CharacterFleetingUIAction(self.ID));
      canBeRemoved = self.CanRemoveCharacter;
      if (!canBeRemoved)
        return;
      self.DisconnectPassives();
      self.RemoveAllStatusEffects(false);
      self.FinalizeDeadConnections();
    }
  }
}
