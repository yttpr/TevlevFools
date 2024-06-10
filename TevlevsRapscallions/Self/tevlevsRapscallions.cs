// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.tevlevsRapscallions
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BepInEx;
using BOSpecialItems;
using HarmonyLib;
using Hawthorne;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  [BepInPlugin("Tevlev.TevlevsRapscallions", "TevlevsRapscallions", "1.2.2.2")]
    [BepInDependency("Bones404.BrutalAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class tevlevsRapscallions : BaseUnityPlugin
  {
    public static bool Debugging = false;
    public static AssetBundle assetBundle;
    public static GameObject[] BubbleEffect = new GameObject[5];
    public static ParticleSystem[] BubbleParticles = new ParticleSystem[5];
    public static SlotStatusEffectInfoSO Bubble = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
    public static IntentInfoBasic BubbleIntent = new IntentInfoBasic();
    public static Sprite[] LoveBugYippee = new Sprite[10]
    {
      ResourceLoader.LoadSprite("LovebugFront"),
      ResourceLoader.LoadSprite("LovebugPose1"),
      ResourceLoader.LoadSprite("LovebugPose2"),
      ResourceLoader.LoadSprite("LovebugPose3"),
      ResourceLoader.LoadSprite("LovebugPose4"),
      ResourceLoader.LoadSprite("LovebugPose5"),
      ResourceLoader.LoadSprite("LovebugPose6"),
      ResourceLoader.LoadSprite("LovebugPose7"),
      ResourceLoader.LoadSprite("LovebugPose8"),
      ResourceLoader.LoadSprite("LovebugPose9")
    };
    public static Sprite[] ScuttleFuckYippee = new Sprite[10]
    {
      ResourceLoader.LoadSprite("ScuttleFaceFront"),
      ResourceLoader.LoadSprite("ScuttleFacePose1"),
      ResourceLoader.LoadSprite("ScuttleFacePose2"),
      ResourceLoader.LoadSprite("ScuttleFacePose3"),
      ResourceLoader.LoadSprite("ScuttleFacePose4"),
      ResourceLoader.LoadSprite("ScuttleFacePose5"),
      ResourceLoader.LoadSprite("ScuttleFacePose6"),
      ResourceLoader.LoadSprite("ScuttleFacePose7"),
      ResourceLoader.LoadSprite("ScuttleFacePose8"),
      ResourceLoader.LoadSprite("ScuttleFacePose9")
    };

    public void Awake()
    {
      try
      {
        yalbbb.Adbum();
      }
      catch (Exception ex)
      {
      }
      AbilityNameFix.Setup();
      tevlevsRapscallions.assetBundle = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("tevlevday"));
      AllySlots.Setup();
      ExtendedSlots.Setup();
      Nails.Add();
      Brain.Add();
      Carpy.Add();
      Zensuke.Add();
      Meatshot.add();
      LoveBug.add();
      LoadedAssetsHandler.LoadedCharacters["Meatshot_CH"].characterAnimator = tevlevsRapscallions.assetBundle.LoadAsset<RuntimeAnimatorController>("Assets/Prototype/Mods/AnimationBaseData/NewBigGuy/BigAnimController.overrideController");
      JunkItems.add();
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("TryConsumeWearable", ~BindingFlags.Default), typeof (tevlevsRapscallions).GetMethod("TryConsumeWearable", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CharacterInFieldLayout).GetMethod("TryUpdateLookAnimation", ~BindingFlags.Default), typeof (tevlevsRapscallions).GetMethod("TryUpdateLookAnimation", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (tevlevsRapscallions).GetMethod("AddBubblesSlotEffect", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (tevlevsRapscallions).GetMethod("BubblesIntentInfo", ~BindingFlags.Default));
      DamageTypeHook.Add();
      PYMNHere.Setup();
      BubbleViewer.Setup();
      SoundClass.Setup();
      BubbleBlower.Add();
      GilbertPassiveStuff.Setup();
      new Harmony("Fuck.KYS.orIllKMS").PatchAll();
      Shittary.Setup();
      ShitBurg.Lev1();
      ShitBurg.Lev2();
      ShitBurg.Lev3();
      ShitBurg.Lev4();
      ShitBurg.Add();
      GlossaryStuffAdder.AddKeyword("Jolly Damage", "Direct damage that ignores Shield and generates random Pigment instead of Pigment of the target's health color.");
      GilbertDamage.Setup();
      EZExtensions.PCall(new Action(AttackSlotsErrorHook.Add), "attack slot error fix");
      Backrooms.Setup();
      EZExtensions.PCall(new Action(Unlocks.Add), "unlocks");
            //foreach (string zone in Backrooms.Hard) Backrooms.MoreFool(zone);
    }

    public static void MultiplyFools()
    {
      Backrooms.MoreFool(Backrooms.Easy[0]);
      Backrooms.MoreFool(Backrooms.Easy[1]);
      Backrooms.MoreFool(Backrooms.Easy[2]);
      Backrooms.MoreFool(Backrooms.Hard[0]);
      Backrooms.MoreFool(Backrooms.Hard[1]);
      Backrooms.MoreFool(Backrooms.Hard[2]);
    }

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
        if (effect.slotStatusEffectType == (SlotStatusEffectType)886955)
          flag = true;
      }
      GameObject gameObject = tevlevsRapscallions.assetBundle.LoadAsset<GameObject>("assets/infectedsmokestacks/smokestackscharacterfieldeffect1.prefab").gameObject;
      if (tevlevsRapscallions.BubbleEffect[self.SlotID] == null)
      {
        tevlevsRapscallions.BubbleEffect[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(gameObject, ((Component) self).transform.localPosition, ((Component) self).transform.localRotation, ((Component) self._constrictedEffect.transform.parent).transform);
        tevlevsRapscallions.BubbleEffect[self.SlotID].transform.localPosition = Vector3.zero;
        tevlevsRapscallions.BubbleEffect[self.SlotID].transform.rotation = Quaternion.identity;
        tevlevsRapscallions.BubbleEffect[self.SlotID].GetComponent<RectTransform>().anchorMin = self._shieldEffect.GetComponent<RectTransform>().anchorMin;
        tevlevsRapscallions.BubbleEffect[self.SlotID].GetComponent<RectTransform>().anchorMax = self._shieldEffect.GetComponent<RectTransform>().anchorMax;
        ((Transform) tevlevsRapscallions.BubbleEffect[self.SlotID].GetComponent<RectTransform>()).position = ((Transform) self._shieldEffect.GetComponent<RectTransform>()).position;
      }
      tevlevsRapscallions.BubbleEffect[self.SlotID].SetActive(flag);
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
          if (enumerator.Current.slotStatusEffectType == (SlotStatusEffectType)886955)
            flag = true;
        }
        ParticleSystem component = tevlevsRapscallions.assetBundle.LoadAsset<GameObject>("assets/infectedsmokestacks/smokestacksenemyfieldeffect1.prefab").GetComponent<ParticleSystem>();
        if (tevlevsRapscallions.BubbleParticles[self.SlotID] = null)
        {
          tevlevsRapscallions.BubbleParticles[self.SlotID] = UnityEngine.Object.Instantiate<ParticleSystem>(component, ((Component) self).transform.localPosition, ((Component) self).transform.localRotation, ((Component) self).transform);
          ((Component) tevlevsRapscallions.BubbleParticles[self.SlotID]).transform.localPosition = Vector3.zero;
          ((Component) tevlevsRapscallions.BubbleParticles[self.SlotID]).transform.localRotation = Quaternion.identity;
        }
        if (flag)
          tevlevsRapscallions.BubbleParticles[self.SlotID].Play(true);
        else if (!flag)
          tevlevsRapscallions.BubbleParticles[self.SlotID].Stop(true);
        orig(self, effects, icons, texts);
      }
    }

    private static void BubblesIntentInfo(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      ((IntentInfo) tevlevsRapscallions.BubbleIntent)._type = (IntentType) 76443;
      ((IntentInfo) tevlevsRapscallions.BubbleIntent)._sprite = ResourceLoader.LoadSprite("BubbleIcon.png");
      ((IntentInfo) tevlevsRapscallions.BubbleIntent)._color = Color.white;
      ((IntentInfo) tevlevsRapscallions.BubbleIntent)._sound = self._intentDB[(IntentType) 157]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) 76443, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) 76443, (IntentInfo) tevlevsRapscallions.BubbleIntent);
    }

    public static void AddBubblesSlotEffect(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      ( tevlevsRapscallions.Bubble).name = "Bubbles";
      tevlevsRapscallions.Bubble.icon = ResourceLoader.LoadSprite("BubbleIcon.png");
      tevlevsRapscallions.Bubble._fieldName = "Bubbles";
      tevlevsRapscallions.Bubble.slotStatusEffectType = (SlotStatusEffectType) 866795;
      tevlevsRapscallions.Bubble._description = "Upon taking any damage in this position remove all Bubbles and receive an equal amount of Jolly Damage.\nUpon an ally performing an action in this position, remove all Bubbles and receive an equal amount of healing.\nBubbles is increased by 1 at the end of each turn.";
      tevlevsRapscallions.Bubble._applied_SE_Event = "event:/BubblesNoise";
      tevlevsRapscallions.Bubble._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 9].UpdatedSoundEvent;
      tevlevsRapscallions.Bubble._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 9].RemovedSoundEvent;
      SlotStatusEffectInfoSO statusEffectInfoSo;
      self._stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 866795, out statusEffectInfoSo);
      if (statusEffectInfoSo != null)
        return;
      self._stats.slotStatusEffectDataBase.Add((SlotStatusEffectType) 866795, tevlevsRapscallions.Bubble);
    }

    public static void TryUpdateLookAnimation(
      Action<CharacterInFieldLayout> orig,
      CharacterInFieldLayout self)
    {
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        if (characterCombat._currentName.Contains("Lovebug") && characterCombat.ID == self.CharacterID)
          self.CharacterSprite = tevlevsRapscallions.LoveBugYippee.GetRandom<Sprite>();
        else if (characterCombat._currentName.Contains("ScuttleFace") && characterCombat.ID == self.CharacterID)
          self.CharacterSprite = tevlevsRapscallions.ScuttleFuckYippee.GetRandom<Sprite>();
      }
      orig(self);
    }

    public static bool TryConsumeWearable(Func<CharacterCombat, bool> orig, CharacterCombat self)
    {
      tevlevsRapscallions.WearableWillBeConsumed(self);
      foreach (CharacterCombat self1 in CombatManager.Instance._stats.CharactersOnField.Values)
        tevlevsRapscallions.AnyWearableWillBeConsumed(self1, self);
      return orig(self);
    }

    public static void WearableWillBeConsumed(CharacterCombat self)
    {
      bool flag = self.HeldItem == null || self.HeldItem.Equals((object) null);
      bool wearableConsumed = self.IsWearableConsumed;
      if (flag || wearableConsumed)
        return;
      CombatManager.Instance.PostNotification(JunkItems.Call.ToString(), (object) self, (object) null);
    }

    public static void AnyWearableWillBeConsumed(CharacterCombat self, CharacterCombat itemholder)
    {
      bool flag =  itemholder.HeldItem == null || itemholder.HeldItem.Equals((object) null);
      bool wearableConsumed = itemholder.IsWearableConsumed;
      if (flag || wearableConsumed)
        return;
      CombatManager.Instance.PostNotification(((TriggerCalls) 809617).ToString(), (object) self, (object) null);
    }

    public static void ConsumeWearable(Action<CharacterCombat> orig, CharacterCombat self)
    {
      orig(self);
      foreach (CharacterCombat self1 in CombatManager.Instance._stats.CharactersOnField.Values)
        tevlevsRapscallions.AnyWearableWillBeConsumed(self1, self);
    }

    public static void WearableHasBeenConsumed(CharacterCombat self, CharacterCombat itemholder)
    {
      CombatManager.Instance.PostNotification(((TriggerCalls) 746717).ToString(), (object) itemholder, (object) null);
      CombatManager.Instance.PostNotification(((TriggerCalls) 756417).ToString(), (object) self, (object) null);
    }

    public static ExtraAbilityInfo GetRandomItemAbility()
    {
      CasterAddRandomExtraAbilityEffect effect = (LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility).connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect;
      List<BasicAbilityChange_Wearable_SMS> changeWearableSmsList = new List<BasicAbilityChange_Wearable_SMS>((IEnumerable<BasicAbilityChange_Wearable_SMS>) effect._slapData);
      List<ExtraAbility_Wearable_SMS> abilityWearableSmsList = new List<ExtraAbility_Wearable_SMS>((IEnumerable<ExtraAbility_Wearable_SMS>) effect._extraData);
      int count1 = changeWearableSmsList.Count;
      int count2 = abilityWearableSmsList.Count;
      int index1 = UnityEngine.Random.Range(0, count1 + count2);
      ExtraAbilityInfo randomItemAbility;
      if (index1 < changeWearableSmsList.Count)
      {
        BasicAbilityChange_Wearable_SMS changeWearableSms = changeWearableSmsList[index1];
        changeWearableSmsList.RemoveAt(index1);
        int num = count1 - 1;
        randomItemAbility = new ExtraAbilityInfo(changeWearableSms.BasicAbility);
      }
      else
      {
        int index2 = index1 - count1;
        ExtraAbility_Wearable_SMS abilityWearableSms = abilityWearableSmsList[index2];
        abilityWearableSmsList.RemoveAt(index2);
        int num = count2 - 1;
        randomItemAbility = new ExtraAbilityInfo(abilityWearableSms.ExtraAbility);
      }
      return randomItemAbility;
    }
  }
}
