using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TevlevsRapscallions
{
    // Token: 0x020000A0 RID: 160
    public class AddExtraAbilityGilbertEnemyAction : CombatAction
    {
        // Token: 0x06000286 RID: 646 RVA: 0x0001B15A File Offset: 0x0001935A
        public AddExtraAbilityGilbertEnemyAction(EnemyCombat enemy, ExtraAbilityInfo info)
        {
            this.enemy = enemy;
            this.info = info;
        }

        // Token: 0x06000287 RID: 647 RVA: 0x0001B172 File Offset: 0x00019372
        public override IEnumerator Execute(CombatStats stats)
        {
            bool add = true;
            foreach (CombatAbility ability in this.enemy.Abilities)
            {
                bool flag = ability.ability._abilityName == this.info.ability._abilityName;
                if (flag)
                {
                    add = false;
                }
            }
            List<CombatAbility>.Enumerator enumerator = default(List<CombatAbility>.Enumerator);
            bool flag2 = add;
            if (flag2)
            {
                bool flag3 = this.info.rarity == null;
                if (flag3)
                {
                    this.info.rarity = AddExtraAbilityGilbertEnemyAction.Rarity;
                }
                this.enemy.AddExtraAbility(GilbertExtended.gilbExtra(this.info));
            }
            yield return null;
            yield break;
        }

        // Token: 0x170000C6 RID: 198
        // (get) Token: 0x06000288 RID: 648 RVA: 0x0001B188 File Offset: 0x00019388
        public static RaritySO Rarity
        {
            get
            {
                bool flag = AddExtraAbilityGilbertEnemyAction._rarity == null;
                if (flag)
                {
                    AddExtraAbilityGilbertEnemyAction._rarity = ScriptableObject.CreateInstance<RaritySO>();
                    AddExtraAbilityGilbertEnemyAction._rarity.rarityValue = 5;
                    AddExtraAbilityGilbertEnemyAction._rarity.canBeRerolled = true;
                }
                return AddExtraAbilityGilbertEnemyAction._rarity;
            }
        }

        // Token: 0x0400017A RID: 378
        public EnemyCombat enemy;

        // Token: 0x0400017B RID: 379
        public ExtraAbilityInfo info;

        // Token: 0x0400017C RID: 380
        private static RaritySO _rarity;
    }
}
