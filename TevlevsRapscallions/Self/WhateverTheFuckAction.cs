// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.WhateverTheFuckAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;

#nullable disable
namespace TevlevsRapscallions
{
  public class WhateverTheFuckAction : CombatAction
  {
    public int _characterID;

    public WhateverTheFuckAction(int characterID) => this._characterID = characterID;

    public override IEnumerator Execute(CombatStats stats)
    {
      CharacterCombat characterCombat = stats.TryGetCharacterOnField(this._characterID);
      if (characterCombat != null)
      {
        characterCombat.IsAlive = false;
        characterCombat.DisconnectPassives();
        characterCombat.RemoveAllStatusEffects(false);
        characterCombat.FinalizeDeadConnections();
        characterCombat.FleeCharacter();
        CombatManager.Instance.AddUIAction((CombatAction) new CharacterFleetingUIAction(characterCombat.ID));
        stats.RemoveCharacter(this._characterID);
      }
      yield return (object) null;
    }
  }
}
