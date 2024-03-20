using System;
using System.Collections;
using UnityEngine;

namespace TevlevsRapscallions
{
    // Token: 0x020000BC RID: 188
    public class SwapSidesEffectAction : CombatAction
    {
        // Token: 0x060002D8 RID: 728 RVA: 0x0001D2B5 File Offset: 0x0001B4B5
        public SwapSidesEffectAction(EffectInfo[] effects, IUnit caster, int startResult = 0)
        {
            this._effects = effects;
            this._caster = caster;
            this._startResult = startResult;
        }

        // Token: 0x170000CF RID: 207
        // (get) Token: 0x060002D9 RID: 729 RVA: 0x0001D2D4 File Offset: 0x0001B4D4
        public static GilbertFlipTargetting Choice
        {
            get
            {
                bool flag = SwapSidesEffectAction._choice == null;
                if (flag)
                {
                    SwapSidesEffectAction._choice = ScriptableObject.CreateInstance<GilbertFlipTargetting>();
                }
                return SwapSidesEffectAction._choice;
            }
        }

        // Token: 0x060002DA RID: 730 RVA: 0x0001D304 File Offset: 0x0001B504
        public override IEnumerator Execute(CombatStats stats)
        {
            bool isCasterCharacter = this._caster.IsUnitCharacter;
            int resultValue = this._startResult;
            int num;
            for (int i = 0; i < this._effects.Length; i = num + 1)
            {
                EffectConditionSO condition = this._effects[i].condition;
                bool flag = condition == null || condition.Equals(null) || condition.MeetCondition(this._caster, this._effects, i);
                if (flag)
                {
                    TargetSlotInfo[] possibleTargets = new TargetSlotInfo[0];
                    try
                    {
                        GilbertFlipTargetting newer = SwapSidesEffectAction.Choice;
                        newer.origin = this._effects[i].targets;
                        possibleTargets = ((this._effects[i].targets != null) ? newer.GetTargets(stats.combatSlots, this._caster.SlotID, isCasterCharacter) : new TargetSlotInfo[0]);
                        newer = null;
                    }
                    catch (Exception ex)
                    {
                        possibleTargets = ((this._effects[i].targets != null) ? this._effects[i].targets.GetTargets(stats.combatSlots, this._caster.SlotID, !isCasterCharacter) : new TargetSlotInfo[0]);
                    }
                    bool areTargetSlots = !(this._effects[i].targets != null) || this._effects[i].targets.AreTargetSlots;
                    resultValue = this._effects[i].StartEffect(stats, this._caster, possibleTargets, areTargetSlots, resultValue);
                    possibleTargets = null;
                }
                else
                {
                    resultValue = this._effects[i].FailEffect(resultValue);
                }
                yield return null;
                condition = null;
                num = i;
            }
            yield break;
        }

        // Token: 0x0400019E RID: 414
        public EffectInfo[] _effects;

        // Token: 0x0400019F RID: 415
        public IUnit _caster;

        // Token: 0x040001A0 RID: 416
        public int _startResult;

        // Token: 0x040001A1 RID: 417
        private static GilbertFlipTargetting _choice;
    }
}
