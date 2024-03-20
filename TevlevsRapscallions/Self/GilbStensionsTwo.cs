// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GilbStensionsTwo
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class GilbStensionsTwo
  {
        public static List<T> Firsten<T>(this List<T> list, T add)
        {
            List<T> newer = new List<T>() { add };
            foreach (T og in list) newer.Add(og);
            return newer;
        }
        public static void MoveToFirst(this TimelineSlotGroup self)
        {
            //Debug.Log(self + " move to first");
            self.slot.transform.SetSiblingIndex(2);
            self.intent.transform.SetSiblingIndex(2);
        }
        public static TimelineSlotGroup PrepareFrontUnusedSlot(this TimelineZoneLayout self, Sprite enemy, Sprite[] intents, Color[] intentColors)
        {
            //Debug.Log(self + " prepare front unused slot");
            if (self._unusedSlots.Count <= 0)
            {
                self.GenerateUnusedSlot();
            }

            TimelineSlotGroup timelineSlotGroup = self._unusedSlots.Dequeue();
            timelineSlotGroup.MoveToFirst();
            timelineSlotGroup.SetInformation(self._slotsInUse.Count, enemy, intents, intentColors);
            timelineSlotGroup.SetActivation(enable: true);
            self._slotsInUse = self._slotsInUse.Firsten(timelineSlotGroup);
            //self._slotsInUse.Add(timelineSlotGroup);
            self._pointerRect.SetAsLastSibling();
            return timelineSlotGroup;
        }
        public static IEnumerator AddFrontTimelineSlots(this TimelineZoneLayout self, Sprite[] turnSprites, AbilitySO[] abilities)
        {
            //Debug.Log(self + " add front timeline slots");
            int count = self._slotsInUse.Count;
            count = 0;
            for (int i = 0; i < turnSprites.Length; i++)
            {
                Sprite enemy;
                Sprite[] intents;
                Color[] spriteColors;
                if (turnSprites[i] == null)
                {
                    enemy = self._blindTimelineIcon;
                    intents = new Sprite[0];
                    spriteColors = new Color[0];
                }
                else
                {
                    enemy = turnSprites[i];
                    intents = self.IntentHandler.GenerateSpritesFromAbility(abilities[i], casterIsCharacter: false, out spriteColors);
                }

                TimelineSlotGroup timelineSlotGroup = self.PrepareFrontUnusedSlot(enemy, intents, spriteColors);
                timelineSlotGroup.SetSlotScale(grow: false);
                timelineSlotGroup.SetActivation(enable: false);
            }

            for (int j = count; j < self._slotsInUse.Count && j < turnSprites.Length; j++)
            {
                self._slotsInUse[j].GenerateTweenScale(grow: true, self._timelineMoveTime);
                self._slotsInUse[j].SetActivation(enable: true);
            }

            self.UpdateTimelineContentSize(self._slotsInUse.Count + 1);
            yield return self.UpdateTimelineBackgroundSize(self._slotsInUse.Count + 1);
        }
        public static void AddTimelineFrontTurn(this EnemyCombatUIInfo self, TurnUIInfo turn)
        {
            //Debug.Log(self + " add tiemline front turn");
            if (!turn.isSecret && turn.abilitySlotID >= 0 && turn.abilitySlotID < self.AbilityTimelineSlots.Count)
            {
                self.AbilityTimelineSlots[turn.abilitySlotID].Add(0);//turn.timeSlotID
            }
        }
        public static IEnumerator AddFrontTimelineSlots(this CombatVisualizationController self, TurnUIInfo[] enemyTurns)
        {
            //Debug.Log(self + " add front timeline slots");
            Sprite[] array = new Sprite[enemyTurns.Length];
            AbilitySO[] array2 = new AbilitySO[enemyTurns.Length];
            for (int i = 0; i < enemyTurns.Length; i++)
            {
                TurnUIInfo turnUIInfo = enemyTurns[i];
                //List<TimelineInfo> gap = new List<TimelineInfo>(self._timelineSlotInfo);
                //self._timelineSlotInfo.Clear();
                //self._timelineSlotInfo.Add(new TimelineInfo(turnUIInfo));
                //for (int b = 0; b < gap.Count; b++) self._timelineSlotInfo.Add(gap[b]);
                self._timelineSlotInfo.Add(new TimelineInfo(turnUIInfo));
                foreach (EnemyCombatUIInfo uiin in self._enemiesInCombat.Values)
                {
                    foreach (List<int> dual in uiin.AbilityTimelineSlots)
                    {
                        List<int> newer = new List<int>(dual);
                        dual.Clear();
                        foreach (int inni in newer) dual.Add(inni + 1);
                    }
                }
                EnemyCombatUIInfo enemyCombatUIInfo = self._enemiesInCombat[turnUIInfo.enemyID];
                enemyCombatUIInfo.AddTimelineFrontTurn(turnUIInfo);
                array[i] = (turnUIInfo.isSecret ? null : enemyCombatUIInfo.Portrait);
                array2[i] = enemyCombatUIInfo.Abilities[turnUIInfo.abilitySlotID].ability;
            }
            //self.ReadOutUI(self._timelineSlotInfo);
            yield return self._timeline.AddFrontTimelineSlots(array, array2);
            if (!self._isInfoFromCharacter && self._unitInfoID != -1)
            {
                self.TryUpdateEnemyIDInformation(self._unitInfoID);
            }
        }
        public static void AddFrontExtraEnemyTurns(this Timeline self, List<EnemyCombat> units, List<int> abilitySlots)
        {
            //Debug.Log(self + " add front extra enemy turns");
            TurnUIInfo[] list = new TurnUIInfo[units.Count];
            for (int i = 0; i < units.Count; i++)
            {
                if (self.Enemies.Contains(units[i]))
                {
                    TurnInfo item = new TurnInfo(units[i], abilitySlots[i], player: false);
                    List<TurnInfo> gap = new List<TurnInfo>(self.Round);
                    self.Round.Clear();
                    self.Round.Add(gap[0]);
                    self.Round.Add(item);
                    for (int w = 1; w < gap.Count; w++) self.Round.Add(gap[w]);
                    list[i] = item.GenerateTurnUIInfo(1, self.IsConfused);//units.Count - (i + 1)
                }
            }
            //ReadOutRound(self.Round);
            CombatManager.Instance.AddUIAction(new AddedSlotsFrontTimelineUIAction(list.ToArray()));
        }
        public static void TryAddNewFrontExtraEnemyTurns(this Timeline self, ITurn unit, int turnsToAdd)
        {
            //Debug.Log(self + " try add new front extra enemy turns");
            if (self.Enemies.Contains(unit))
            {
                TurnUIInfo[] list = new TurnUIInfo[turnsToAdd];
                for (int i = 0; i < turnsToAdd; i++)
                {
                    int singleAbilitySlotUsage = unit.GetSingleAbilitySlotUsage(-1);
                    TurnInfo item = new TurnInfo(unit, singleAbilitySlotUsage, player: false);
                    List<TurnInfo> gap = new List<TurnInfo>(self.Round);
                    self.Round.Clear();
                    self.Round.Add(gap[0]);
                    self.Round.Add(item);
                    for (int w = 1; w < gap.Count; w++) self.Round.Add(gap[w]);
                    list[i] = item.GenerateTurnUIInfo(1, self.IsConfused);
                }
                //ReadOutRound(self.Round);
                CombatManager.Instance.AddUIAction(new AddedSlotsFrontTimelineUIAction(list.ToArray()));
            }
        }
        public static int GetLastAbilityIDFromNameUsingAbilityName(this EnemyCombat enemy, string abilityName)
        {
            for (int num = enemy.Abilities.Count - 1; num >= 0; num--)
            {
                if (enemy.Abilities[num].ability._abilityName == abilityName)
                {
                    return num;
                }
            }

            return -1;
        }

        public static void ReadOutRound(List<TurnInfo> list)
    {
      Debug.Log((object) "IN GAME TIMELINE");
      foreach (TurnInfo turnInfo in list)
      {
        Debug.Log((object) ("TURN: " + turnInfo.ToString()));
        if (turnInfo.turnUnit is EnemyCombat turnUnit)
          Debug.Log((object) (turnInfo.turnUnit?.ToString() + " " + turnUnit._currentName + " Slot: " + turnInfo.turnUnit.SlotID.ToString()));
        else
          Debug.Log((object) turnInfo.turnUnit);
      }
    }

    public static void ReadOutUI(this CombatVisualizationController self, List<TimelineInfo> list)
    {
      Debug.Log((object) "UI TIMELINE");
      foreach (TimelineInfo timelineInfo in list)
      {
        Debug.Log((object) ("TURN: " + timelineInfo.ToString()));
        EnemyCombatUIInfo enemyCombatUiInfo;
        int num;
        if (self._enemiesInCombat.TryGetValue(timelineInfo.enemyID, out enemyCombatUiInfo))
        {
          string[] strArray = new string[5]
          {
            enemyCombatUiInfo?.ToString(),
            " ",
            enemyCombatUiInfo.EnemyBase._enemyName,
            " Slot: ",
            null
          };
          num = enemyCombatUiInfo.SlotID;
          strArray[4] = num.ToString();
          Debug.Log((object) string.Concat(strArray));
        }
        else
        {
          num = timelineInfo.enemyID;
          Debug.LogWarning((object) ("Didn't find the enemy for: " + num.ToString()));
        }
      }
    }
  }
}
