// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.CharacterDeathFleeAnimationAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;

#nullable disable
namespace TevlevsRapscallions
{
  public class CharacterDeathFleeAnimationAction : CombatAction
  {
    public int _characterID;
    public IUnit _killer;
    public DeathType _deathType;

    public CharacterDeathFleeAnimationAction(int characterID, IUnit killer, DeathType deathType)
    {
      this._characterID = characterID;
      this._killer = killer;
      this._deathType = deathType;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      CharacterCombat characterCombat = stats.TryGetCharacterOnField(this._characterID);
      if (characterCombat != null && (!characterCombat.IsAlive || characterCombat.CurrentHealth <= 0) && characterCombat.CanUnitDie)
      {
        DeathReference deathReference = new DeathReference(this._killer, false);
        bool canBeRemoved;
        characterCombat.CharacterDeathFleeAnim(deathReference, this._deathType, out canBeRemoved);
        if (canBeRemoved)
          stats.RemoveCharacter(this._characterID);
        deathReference = (DeathReference) null;
        yield break;
      }
    }
  }
}
