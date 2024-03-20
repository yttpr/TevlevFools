using System;
using System.Collections;

namespace TevlevsRapscallions
{
    // Token: 0x020000BE RID: 190
    public class PlayAbilityAnimationSwapSidesAction : CombatAction
    {
        // Token: 0x060002DE RID: 734 RVA: 0x0001D441 File Offset: 0x0001B641
        public PlayAbilityAnimationSwapSidesAction(AttackVisualsSO visuals, BaseCombatTargettingSO targetting, IUnit caster)
        {
            this._visuals = visuals;
            this._targetting = targetting;
            this._caster = caster;
        }

        // Token: 0x060002DF RID: 735 RVA: 0x0001D460 File Offset: 0x0001B660
        public override IEnumerator Execute(CombatStats stats)
        {
            TargetSlotInfo[] targets = new TargetSlotInfo[0];
            bool areTargetSlots = true;
            bool flag = this._targetting != null;
            if (flag)
            {
                try
                {
                    GilbertFlipTargetting newer = SwapSidesEffectAction.Choice;
                    newer.origin = this._targetting;
                    targets = newer.GetTargets(stats.combatSlots, this._caster.SlotID, this._caster.IsUnitCharacter);
                    newer = null;
                }
                catch (Exception ex)
                {
                    targets = this._targetting.GetTargets(stats.combatSlots, this._caster.SlotID, !this._caster.IsUnitCharacter);
                }
                areTargetSlots = this._targetting.AreTargetSlots;
            }
            yield return stats.combatUI.PlayAbilityAnimation(this._visuals, targets, areTargetSlots);
            yield break;
        }

        // Token: 0x040001A3 RID: 419
        public BaseCombatTargettingSO _targetting;

        // Token: 0x040001A4 RID: 420
        public AttackVisualsSO _visuals;

        // Token: 0x040001A5 RID: 421
        public IUnit _caster;
    }
}
