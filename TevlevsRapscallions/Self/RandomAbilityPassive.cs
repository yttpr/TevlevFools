// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.RandomAbilityPassive
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;

#nullable disable
namespace TevlevsRapscallions
{
  public class RandomAbilityPassive : BasePassiveAbilitySO
  {
    private Dictionary<IUnit, ExtraAbilityInfo> extraAbilities;

    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
      IUnit key = sender as IUnit;
      ExtraAbilityInfo extraAbilityInfo;
      if (this.extraAbilities.TryGetValue(key, out extraAbilityInfo))
      {
        key.TryRemoveExtraAbility(extraAbilityInfo);
        this.extraAbilities.Remove(key);
      }
      ExtraAbilityInfo randomItemAbility = tevlevsRapscallions.GetRandomItemAbility();
      this.extraAbilities.Add(key, randomItemAbility);
      key.AddExtraAbility(this.extraAbilities[key]);
    }

    public override void OnPassiveConnected(IUnit unit)
    {
      if (this.extraAbilities == null)
        this.extraAbilities = new Dictionary<IUnit, ExtraAbilityInfo>();
      ExtraAbilityInfo randomItemAbility = tevlevsRapscallions.GetRandomItemAbility();
      this.extraAbilities.Add(unit, randomItemAbility);
      unit.AddExtraAbility(this.extraAbilities[unit]);
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
      ExtraAbilityInfo extraAbilityInfo;
      if (!this.extraAbilities.TryGetValue(unit, out extraAbilityInfo))
        return;
      unit.TryRemoveExtraAbility(extraAbilityInfo);
      this.extraAbilities.Remove(unit);
    }
  }
}
