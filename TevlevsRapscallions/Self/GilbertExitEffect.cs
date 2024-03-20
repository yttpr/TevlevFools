// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GilbertExitEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class GilbertExitEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = caster.MaximumHealth;
      if (caster.HasFled)
        return false;
      List<int> intList = new List<int>();
      List<bool> boolList = new List<bool>();
      List<string> stringList = new List<string>();
      List<Sprite> spriteList = new List<Sprite>();
      intList.Add(caster.ID);
      boolList.Add(caster.IsUnitCharacter);
      stringList.Add(ShitBurg.Gilby._passiveName);
      spriteList.Add(ShitBurg.Gilby.passiveIcon);
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
      {
        if (characterCombat.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
        {
          intList.Add(characterCombat.ID);
          boolList.Add(characterCombat.IsUnitCharacter);
          stringList.Add(ShitBurg.Gilby._passiveName);
          spriteList.Add(ShitBurg.Gilby.passiveIcon);
        }
      }
      if (intList.Count > 0)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowMultiplePassiveInformationUIAction(intList.ToArray(), boolList.ToArray(), stringList.ToArray(), spriteList.ToArray()));
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
      {
        if (characterCombat.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
          characterCombat.MaximizeHealth(characterCombat.MaximumHealth + exitAmount);
      }
      return true;
    }
  }
}
