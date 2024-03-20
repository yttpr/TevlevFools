// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.CharacterCasterAddRandomCharacterAbilityEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
    public class CharacterCasterAddRandomCharacterAbilityEffect : EffectSO
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
            if (!(caster is CharacterCombat))
                return false;
            CharacterCombat characterCombat = caster as CharacterCombat;
            CharacterDataBase characterDb = LoadedAssetsHandler.GetCharacterDB();
            if ((Object)characterDb == (Object)null || characterDb.Equals((object)null))
                return false;
            foreach (CharacterSO randomCharacter in characterDb.GetRandomCharacters(entryVariable))
            {
                int index = randomCharacter.ClampRank(characterCombat.Rank);
                CharacterAbility random = randomCharacter.rankedData[index].rankAbilities.GetRandom<CharacterAbility>();
                characterCombat.CombatAbilities.Add(new CombatAbility(random));
                ++exitAmount;
            }
            return exitAmount > 0;
        }
    }
}
