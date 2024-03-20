// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.PerformRandomAbilityFromCharacterSwapTargetsEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
    public class PerformRandomAbilityFromCharacterSwapTargetsEffect : EffectSO
    {
        private static PerformRandomAbilityFromCharacterSwapTargetsEffect _instance;

        public static PerformRandomAbilityFromCharacterSwapTargetsEffect Instance
        {
            get
            {
                if ((Object)PerformRandomAbilityFromCharacterSwapTargetsEffect._instance == (Object)null)
                    PerformRandomAbilityFromCharacterSwapTargetsEffect._instance = ScriptableObject.CreateInstance<PerformRandomAbilityFromCharacterSwapTargetsEffect>();
                return PerformRandomAbilityFromCharacterSwapTargetsEffect._instance;
            }
        }

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            AbilityDataBase abilityDb = LoadedAssetsHandler.GetAbilityDB();
            if ((Object)abilityDb == (Object)null || abilityDb.Equals((object)null))
                return false;
            foreach (AbilitySO characterAbility in abilityDb.GetRandomCharacterAbilities(entryVariable))
            {
                CombatManager.Instance.AddSubAction((CombatAction)new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, characterAbility.GetAbilityLocData().text));
                CombatManager.Instance.AddSubAction((CombatAction)new PlayAbilityAnimationSwapSidesAction(characterAbility.visuals, characterAbility.animationTarget, caster));
                CombatManager.Instance.AddSubAction((CombatAction)new SwapSidesEffectAction(characterAbility.effects, caster));
                caster.SetVolatileUpdateUIAction(false);
            }
            return true;
        }
    }
}
