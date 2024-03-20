// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.BubbleViewer
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class BubbleViewer
  {
    public static GameObject[] BubblesFool = new GameObject[5];
    public static GameObject[] BubblesEnemy = new GameObject[5];
    public static GameObject Fool;
    public static GameObject Enemy;

    public static void UpdateFieldListCharacterModdedLayout(
      Action<CharacterSlotLayout, List<SlotStatusEffectInfoSO>, Sprite[], string[]> orig,
      CharacterSlotLayout self,
      List<SlotStatusEffectInfoSO> effects,
      Sprite[] icons,
      string[] texts)
    {
      self._fieldListLayout.SetInformation(self.SlotID, icons, texts, true);
      bool flag = false;
      foreach (SlotStatusEffectInfoSO effect in effects)
      {
        if (effect.slotStatusEffectType == (SlotStatusEffectType)866795)
          flag = true;
      }
      GameObject fool = BubbleViewer.Fool;
      if (( BubbleViewer.BubblesFool[self.SlotID] ==null))
      {
        BubbleViewer.BubblesFool[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(fool, ((Component) self).transform.localPosition, ((Component) self).transform.localRotation, ((Component) self._constrictedEffect.transform.parent).transform);
        BubbleViewer.BubblesFool[self.SlotID].transform.localPosition = Vector3.zero;
        BubbleViewer.BubblesFool[self.SlotID].transform.rotation = self._constrictedEffect.transform.rotation;
        BubbleViewer.BubblesFool[self.SlotID].GetComponent<RectTransform>().anchorMin = self._shieldEffect.GetComponent<RectTransform>().anchorMin;
        BubbleViewer.BubblesFool[self.SlotID].GetComponent<RectTransform>().anchorMax = self._shieldEffect.GetComponent<RectTransform>().anchorMax;
        ((Transform) BubbleViewer.BubblesFool[self.SlotID].GetComponent<RectTransform>()).position = ((Transform) self._shieldEffect.GetComponent<RectTransform>()).position;
      }
      BubbleViewer.BubblesFool[self.SlotID].SetActive(flag);
      orig(self, effects, icons, texts);
    }

    public static void UpdateFieldListModdedLayout(
      Action<EnemySlotLayout, List<SlotStatusEffectInfoSO>, Sprite[], string[]> orig,
      EnemySlotLayout self,
      List<SlotStatusEffectInfoSO> effects,
      Sprite[] icons,
      string[] texts)
    {
      self.SlotUI.UpdateFieldListLayout(self.SlotID, icons, texts);
      bool flag = false;
      using (List<SlotStatusEffectInfoSO>.Enumerator enumerator = effects.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          if (enumerator.Current.slotStatusEffectType == (SlotStatusEffectType)866795)
            flag = true;
        }
        GameObject enemy = BubbleViewer.Enemy;
        if (BubbleViewer.BubblesEnemy[self.SlotID] == null)
        {
          BubbleViewer.BubblesEnemy[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(enemy, ((Component) self).transform.localPosition, ((Component) self).transform.localRotation, ((Component) self).transform);
          BubbleViewer.BubblesEnemy[self.SlotID].transform.localPosition = Vector3.zero;
          BubbleViewer.BubblesEnemy[self.SlotID].transform.localRotation = Quaternion.identity;
        }
        if (flag)
        {
          BubbleViewer.BubblesEnemy[self.SlotID].SetActive(true);
          ((Component) BubbleViewer.BubblesEnemy[self.SlotID].transform.GetChild(0)).GetComponent<ParticleSystem>().Play(true);
        }
        else if (!flag)
          ((Component) BubbleViewer.BubblesEnemy[self.SlotID].transform.GetChild(0)).GetComponent<ParticleSystem>().Stop(true);
        orig(self, effects, icons, texts);
      }
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (EnemySlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof (BubbleViewer).GetMethod("UpdateFieldListModdedLayout", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CharacterSlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof (BubbleViewer).GetMethod("UpdateFieldListCharacterModdedLayout", ~BindingFlags.Default));
      BubbleViewer.Enemy = PYMNHere.Assets.LoadAsset<GameObject>("Assets/Bubble/BubblesEnemy.prefab");
      BubbleViewer.Fool = PYMNHere.Assets.LoadAsset<GameObject>("Assets/Bubble/FinalBubblesChar.prefab");
    }
  }
}
