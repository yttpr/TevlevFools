// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GilbertAddExtraAbilitiesSpawnAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class GilbertAddExtraAbilitiesSpawnAction : IImmediateAction
  {
    public EnemyCombat enemy;

    public GilbertAddExtraAbilitiesSpawnAction(EnemyCombat enemy) => this.enemy = enemy;

    public void Execute(CombatStats stats)
    {
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
      {
        if (characterCombat.ContainsPassiveAbility(GilbertPassiveStuff.Gilb))
        {
          foreach (CombatAbility combatAbility in characterCombat.CombatAbilities)
          {
            string abilityName = combatAbility.ability._abilityName;
            if ((!abilityName.Contains("Liquid") || abilityName.ToCharArray().Length <= 10) && (!abilityName.Contains("Baloooo") || abilityName.ToCharArray().Length <= 10) && (!abilityName.Contains("Pyre") || abilityName.ToCharArray().Length <= 6) && !(abilityName == "Slap"))
            {
              bool flag = true;
              foreach (CombatAbility ability in this.enemy.Abilities)
              {
                if (ability.ability._abilityName.Contains(abilityName) || ability.ability._abilityName == abilityName)
                  flag = false;
              }
              if (flag)
                this.enemy.AddExtraAbility(GilbertExtended.gilbExtra(new ExtraAbilityInfo()
                {
                  ability = combatAbility.ability,
                  cost = combatAbility.cost,
                  rarity = AddExtraAbilityGilbertEnemyAction.Rarity
                }));
            }
          }
        }
      }
    }
  }
}
