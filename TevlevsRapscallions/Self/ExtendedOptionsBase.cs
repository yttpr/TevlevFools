// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ExtendedOptionsBase
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class ExtendedOptionsBase
  {
    public static void Add()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("EnemyDeath", ~BindingFlags.Default), typeof (ExtendedOptionsBase).GetMethod("EnemyDeath", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("CharacterDeath", ~BindingFlags.Default), typeof (ExtendedOptionsBase).GetMethod("CharacterDeath", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("SwapTo", ~BindingFlags.Default), typeof (ExtendedOptionsBase).GetMethod("CharacterSwapTo", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("SwappedTo", ~BindingFlags.Default), typeof (ExtendedOptionsBase).GetMethod("CharacterSwappedTo", ~BindingFlags.Default));
      IDetour idetour5 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("SwapTo", ~BindingFlags.Default), typeof (ExtendedOptionsBase).GetMethod("EnemySwapTo", ~BindingFlags.Default));
      IDetour idetour6 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("SwappedTo", ~BindingFlags.Default), typeof (ExtendedOptionsBase).GetMethod("EnemySwappedTo", ~BindingFlags.Default));
      IDetour idetour7 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("TryConsumeWearable", ~BindingFlags.Default), typeof (ExtendedOptionsBase).GetMethod("TryConsumeWearable", ~BindingFlags.Default));
    }

    public static void EnemyDeath(
      Action<EnemyCombat, DeathReference, DeathType> orig,
      EnemyCombat self,
      DeathReference deathReference,
      DeathType deathType)
    {
      foreach (EnemyCombat enemyCombat in CombatManager.Instance._stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(((TriggerCalls) 90987).ToString(), (object) enemyCombat, (object) deathReference);
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(((TriggerCalls) 90987).ToString(), (object) characterCombat, (object) deathReference);
      orig(self, deathReference, deathType);
    }

    public static void CharacterDeath(
      ExtendedOptionsBase.OutFourth<CharacterCombat, DeathReference, DeathType, bool> orig,
      CharacterCombat self,
      DeathReference deathReference,
      DeathType deathType,
      out bool canBeRemoved)
    {
      foreach (EnemyCombat enemyCombat in CombatManager.Instance._stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(((TriggerCalls) 90987).ToString(), (object) enemyCombat, (object) deathReference);
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(((TriggerCalls) 90987).ToString(), (object) characterCombat, (object) deathReference);
      orig(self, deathReference, deathType, out canBeRemoved);
    }

    public static void CharacterSwapTo(
      Action<CharacterCombat, int> orig,
      CharacterCombat self,
      int slotID)
    {
      orig(self, slotID);
      foreach (EnemyCombat enemyCombat1 in CombatManager.Instance._stats.EnemiesOnField.Values)
      {
        TriggerCalls triggerCalls;
        if (enemyCombat1.SlotID == slotID)
        {
          CombatManager instance = CombatManager.Instance;
          triggerCalls = (TriggerCalls) 90987;
          string str = triggerCalls.ToString();
          EnemyCombat enemyCombat2 = enemyCombat1;
          instance.PostNotification(str, (object) enemyCombat2, (object) null);
        }
        CombatManager instance1 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str1 = triggerCalls.ToString();
        EnemyCombat enemyCombat3 = enemyCombat1;
        instance1.PostNotification(str1, (object) enemyCombat3, (object) null);
        CombatManager instance2 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str2 = triggerCalls.ToString();
        EnemyCombat enemyCombat4 = enemyCombat1;
        instance2.PostNotification(str2, (object) enemyCombat4, (object) null);
      }
      foreach (CharacterCombat characterCombat1 in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        TriggerCalls triggerCalls;
        if (characterCombat1.SlotID == slotID)
        {
          CombatManager instance = CombatManager.Instance;
          triggerCalls = (TriggerCalls) 90987;
          string str = triggerCalls.ToString();
          CharacterCombat characterCombat2 = characterCombat1;
          instance.PostNotification(str, (object) characterCombat2, (object) null);
        }
        CombatManager instance3 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str3 = triggerCalls.ToString();
        CharacterCombat characterCombat3 = characterCombat1;
        instance3.PostNotification(str3, (object) characterCombat3, (object) null);
        CombatManager instance4 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str4 = triggerCalls.ToString();
        CharacterCombat characterCombat4 = characterCombat1;
        instance4.PostNotification(str4, (object) characterCombat4, (object) null);
      }
    }

    public static void CharacterSwappedTo(
      Action<CharacterCombat, int> orig,
      CharacterCombat self,
      int slotID)
    {
      orig(self, slotID);
      foreach (EnemyCombat enemyCombat1 in CombatManager.Instance._stats.EnemiesOnField.Values)
      {
        TriggerCalls triggerCalls;
        if (enemyCombat1.SlotID == slotID)
        {
          CombatManager instance = CombatManager.Instance;
          triggerCalls = (TriggerCalls) 90987;
          string str = triggerCalls.ToString();
          EnemyCombat enemyCombat2 = enemyCombat1;
          instance.PostNotification(str, (object) enemyCombat2, (object) null);
        }
        CombatManager instance1 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str1 = triggerCalls.ToString();
        EnemyCombat enemyCombat3 = enemyCombat1;
        instance1.PostNotification(str1, (object) enemyCombat3, (object) null);
        CombatManager instance2 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str2 = triggerCalls.ToString();
        EnemyCombat enemyCombat4 = enemyCombat1;
        instance2.PostNotification(str2, (object) enemyCombat4, (object) null);
      }
      foreach (CharacterCombat characterCombat1 in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        TriggerCalls triggerCalls;
        if (characterCombat1.SlotID == slotID)
        {
          CombatManager instance = CombatManager.Instance;
          triggerCalls = (TriggerCalls) 90987;
          string str = triggerCalls.ToString();
          CharacterCombat characterCombat2 = characterCombat1;
          instance.PostNotification(str, (object) characterCombat2, (object) null);
        }
        CombatManager instance3 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str3 = triggerCalls.ToString();
        CharacterCombat characterCombat3 = characterCombat1;
        instance3.PostNotification(str3, (object) characterCombat3, (object) null);
        CombatManager instance4 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str4 = triggerCalls.ToString();
        CharacterCombat characterCombat4 = characterCombat1;
        instance4.PostNotification(str4, (object) characterCombat4, (object) null);
      }
    }

    public static bool TryConsumeWearable(Func<CharacterCombat, bool> orig, CharacterCombat self)
    {
      ExtendedOptionsBase.WearableWillBeConsumed(self);
      foreach (CharacterCombat self1 in CombatManager.Instance._stats.CharactersOnField.Values)
        ExtendedOptionsBase.AnyWearableWillBeConsumed(self1, self);
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
      bool flag = itemholder.HeldItem == null || self.HeldItem.Equals((object) null);
      bool wearableConsumed = itemholder.IsWearableConsumed;
      if (flag || wearableConsumed)
        return;
      CombatManager.Instance.PostNotification(((TriggerCalls) 809617).ToString(), (object) self, (object) null);
      foreach (EnemyCombat enemyCombat in CombatManager.Instance._stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(JunkItems.Call.ToString(), (object) enemyCombat, (object) null);
    }

    public static void EnemySwapTo(Action<EnemyCombat, int> orig, EnemyCombat self, int slotID)
    {
      orig(self, slotID);
      foreach (EnemyCombat enemyCombat1 in CombatManager.Instance._stats.EnemiesOnField.Values)
      {
        TriggerCalls triggerCalls;
        if (enemyCombat1.SlotID == slotID)
        {
          CombatManager instance = CombatManager.Instance;
          triggerCalls = (TriggerCalls) 90987;
          string str = triggerCalls.ToString();
          EnemyCombat enemyCombat2 = enemyCombat1;
          instance.PostNotification(str, (object) enemyCombat2, (object) null);
        }
        CombatManager instance1 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str1 = triggerCalls.ToString();
        EnemyCombat enemyCombat3 = enemyCombat1;
        instance1.PostNotification(str1, (object) enemyCombat3, (object) null);
        CombatManager instance2 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str2 = triggerCalls.ToString();
        EnemyCombat enemyCombat4 = enemyCombat1;
        instance2.PostNotification(str2, (object) enemyCombat4, (object) null);
      }
      foreach (CharacterCombat characterCombat1 in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        TriggerCalls triggerCalls;
        if (characterCombat1.SlotID == slotID)
        {
          CombatManager instance = CombatManager.Instance;
          triggerCalls = (TriggerCalls) 90987;
          string str = triggerCalls.ToString();
          CharacterCombat characterCombat2 = characterCombat1;
          instance.PostNotification(str, (object) characterCombat2, (object) null);
        }
        CombatManager instance3 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str3 = triggerCalls.ToString();
        CharacterCombat characterCombat3 = characterCombat1;
        instance3.PostNotification(str3, (object) characterCombat3, (object) null);
        CombatManager instance4 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str4 = triggerCalls.ToString();
        CharacterCombat characterCombat4 = characterCombat1;
        instance4.PostNotification(str4, (object) characterCombat4, (object) null);
      }
    }

    public static void EnemySwappedTo(Action<EnemyCombat, int> orig, EnemyCombat self, int slotID)
    {
      orig(self, slotID);
      foreach (EnemyCombat enemyCombat1 in CombatManager.Instance._stats.EnemiesOnField.Values)
      {
        TriggerCalls triggerCalls;
        if (enemyCombat1.SlotID == slotID)
        {
          CombatManager instance = CombatManager.Instance;
          triggerCalls = (TriggerCalls) 90987;
          string str = triggerCalls.ToString();
          EnemyCombat enemyCombat2 = enemyCombat1;
          instance.PostNotification(str, (object) enemyCombat2, (object) null);
        }
        CombatManager instance1 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str1 = triggerCalls.ToString();
        EnemyCombat enemyCombat3 = enemyCombat1;
        instance1.PostNotification(str1, (object) enemyCombat3, (object) null);
        CombatManager instance2 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str2 = triggerCalls.ToString();
        EnemyCombat enemyCombat4 = enemyCombat1;
        instance2.PostNotification(str2, (object) enemyCombat4, (object) null);
      }
      foreach (CharacterCombat characterCombat1 in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        TriggerCalls triggerCalls;
        if (characterCombat1.SlotID == slotID)
        {
          CombatManager instance = CombatManager.Instance;
          triggerCalls = (TriggerCalls) 90987;
          string str = triggerCalls.ToString();
          CharacterCombat characterCombat2 = characterCombat1;
          instance.PostNotification(str, (object) characterCombat2, (object) null);
        }
        CombatManager instance3 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str3 = triggerCalls.ToString();
        CharacterCombat characterCombat3 = characterCombat1;
        instance3.PostNotification(str3, (object) characterCombat3, (object) null);
        CombatManager instance4 = CombatManager.Instance;
        triggerCalls = (TriggerCalls) 90987;
        string str4 = triggerCalls.ToString();
        CharacterCombat characterCombat4 = characterCombat1;
        instance4.PostNotification(str4, (object) characterCombat4, (object) null);
      }
    }

    public static ExtraAbilityInfo GetRandomItemAbility()
    {
      ExtraAbilityInfo randomItemAbility = new ExtraAbilityInfo();
      randomItemAbility.ability = LoadedAssetsHandler.GetCharacterAbility("Slap_Snap_A");
      randomItemAbility.cost = new ManaColorSO[1]
      {
        Pigments.Yellow
      };
      List<ExtraAbilityInfo> extraAbilityInfoList = new List<ExtraAbilityInfo>((IEnumerable<ExtraAbilityInfo>) new ExtraAbilityInfo[16]
      {
        randomItemAbility,
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_BladedMalediction_A"),
          cost = new ManaColorSO[2]
          {
            Pigments.Red,
            Pigments.Purple
          }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_SeamRipper_A"),
          cost = new ManaColorSO[1]
          {
            Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple)
          }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_SwellingEnergies_A"),
          cost = new ManaColorSO[1]{ Pigments.Purple }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_AbjectRejection_A"),
          cost = new ManaColorSO[1]{ Pigments.Yellow }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_AlchemicalAbomination_A"),
          cost = new ManaColorSO[4]
          {
            Pigments.Purple,
            Pigments.Blue,
            Pigments.Red,
            Pigments.Yellow
          }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_BloodGamble_A"),
          cost = new ManaColorSO[2]
          {
            Pigments.Purple,
            Pigments.Red
          }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_Cannibalize_A"),
          cost = new ManaColorSO[2]
          {
            Pigments.Red,
            Pigments.Blue
          }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_CrownOfThorns_A"),
          cost = new ManaColorSO[1]{ Pigments.Purple }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_Icarus_A"),
          cost = new ManaColorSO[2]
          {
            Pigments.Yellow,
            Pigments.Red
          }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_InhumanUtterings_A"),
          cost = new ManaColorSO[1]{ Pigments.Purple }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_OriginalSin_A"),
          cost = new ManaColorSO[1]{ Pigments.Yellow }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_Penance_A"),
          cost = new ManaColorSO[2]
          {
            Pigments.Purple,
            Pigments.Red
          }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_Sabbath_A"),
          cost = new ManaColorSO[1]{ Pigments.Blue }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_Trout_A"),
          cost = new ManaColorSO[1]
          {
            Pigments.SplitPigment(Pigments.Yellow, Pigments.Blue)
          }
        },
        new ExtraAbilityInfo()
        {
          ability = LoadedAssetsHandler.GetCharacterAbility("Extra_WormSkin_A"),
          cost = new ManaColorSO[1]{ Pigments.Yellow }
        }
      });
      foreach (ExtraAbilityInfo extraAbilityInfo in extraAbilityInfoList)
      {
        if (extraAbilityInfo.ability == null || extraAbilityInfo.Equals((object) null))
        {
          Debug.LogError((object) ("Failed to get ability " + extraAbilityInfo.ability._abilityName + "."));
          return randomItemAbility;
        }
        if (extraAbilityInfo.cost == null)
        {
          AbilitySO ability = extraAbilityInfo.ability;
          Debug.LogWarning((object) ("Did not set " + ( ability).name + " cost."));
          Debug.LogError((object) ( ability).name);
          return randomItemAbility;
        }
      }
      int index = UnityEngine.Random.Range(0, extraAbilityInfoList.Count);
      return extraAbilityInfoList[index];
    }

    public static ExtraAbilityInfo GetRandomCustomAbility(ExtraAbilityInfo[] _extraAbilityInfos)
    {
      ExtraAbilityInfo randomCustomAbility = new ExtraAbilityInfo();
      randomCustomAbility.ability = LoadedAssetsHandler.GetCharacterAbility("Slap_Snap_A");
      randomCustomAbility.cost = new ManaColorSO[1]
      {
        Pigments.Yellow
      };
      List<ExtraAbilityInfo> extraAbilityInfoList = new List<ExtraAbilityInfo>((IEnumerable<ExtraAbilityInfo>) _extraAbilityInfos);
      foreach (ExtraAbilityInfo extraAbilityInfo in extraAbilityInfoList)
      {
        if (extraAbilityInfo.ability == null || extraAbilityInfo.Equals((object) null))
        {
          Debug.LogError((object) ("Failed to get ability " + extraAbilityInfo.ability._abilityName + "."));
          return randomCustomAbility;
        }
        if (extraAbilityInfo.cost == null)
        {
          Debug.LogWarning((object) ("Did not set " + ( extraAbilityInfo.ability).name + " cost."));
          return randomCustomAbility;
        }
      }
      int index =UnityEngine.Random.Range(0, extraAbilityInfoList.Count);
      return extraAbilityInfoList[index];
    }

    public static EnemyCombat GetRandomEnemy(EnemyCombat ignoreenemy)
    {
      List<EnemyCombat> enemyCombatList = new List<EnemyCombat>();
      foreach (EnemyCombat enemyCombat in CombatManager.Instance._stats.EnemiesOnField.Values)
      {
        if (enemyCombat.IsAlive)
        {
          if (ignoreenemy != null)
          {
            if (enemyCombat != ignoreenemy)
              enemyCombatList.Add(enemyCombat);
          }
          else
            enemyCombatList.Add(enemyCombat);
        }
      }
      if (enemyCombatList.Count <= 0)
        return (EnemyCombat) null;
      int index = UnityEngine.Random.Range(0, enemyCombatList.Count);
      return enemyCombatList[index];
    }

    public static CharacterCombat GetRandomCharacter(CharacterCombat ignorcharacter)
    {
      List<CharacterCombat> characterCombatList = new List<CharacterCombat>();
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        if (characterCombat.IsAlive)
        {
          if (ignorcharacter != null)
          {
            if (characterCombat != ignorcharacter)
              characterCombatList.Add(characterCombat);
          }
          else
            characterCombatList.Add(characterCombat);
        }
      }
      if (characterCombatList.Count <= 0)
        return (CharacterCombat) null;
      int index = UnityEngine.Random.Range(0, characterCombatList.Count);
      return characterCombatList[index];
    }

    public delegate void OutFourth<T1, T2, T3, T4>(T1 a, T2 b, T3 c, out T4 d);
  }
}
