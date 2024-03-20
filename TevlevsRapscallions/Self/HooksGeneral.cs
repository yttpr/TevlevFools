// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.HooksGeneral
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class HooksGeneral
  {
    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("Damage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("DamageCH", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("Damage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("DamageEN", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("WillApplyDamageCH", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("WillApplyDamageEN", ~BindingFlags.Default));
      IDetour idetour5 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("Start", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("StartMenu", ~BindingFlags.Default));
      IDetour idetour6 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("InitializeCombat", ~BindingFlags.Default));
      IDetour idetour7 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnStart", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("PlayerTurnStart", ~BindingFlags.Default));
      IDetour idetour8 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnEnd", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("PlayerTurnEnd", ~BindingFlags.Default));
      IDetour idetour9 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("PostNotification", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("PostNotification", ~BindingFlags.Default));
      IDetour idetour10 = (IDetour) new Hook((MethodBase) typeof (EffectAction).GetMethod("Execute", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("EffectActionExecute", ~BindingFlags.Default));
      IDetour idetour11 = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("AddStoredValue", ~BindingFlags.Default));
    }

    public static DamageInfo DamageCH(
      Func<CharacterCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig,
      CharacterCombat self,
      int amount,
      IUnit killer,
      DeathType deathType,
      int targetSlotOffset = -1,
      bool addHealthMana = true,
      bool directDamage = true,
      bool ignoresShield = false,
      DamageType specialDamage = 0)
    {
      return orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
    }

    public static DamageInfo DamageEN(
      Func<EnemyCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig,
      EnemyCombat self,
      int amount,
      IUnit killer,
      DeathType deathType,
      int targetSlotOffset = -1,
      bool addHealthMana = true,
      bool directDamage = true,
      bool ignoresShield = false,
      DamageType specialDamage = 0)
    {
      return orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
    }

    public static int WillApplyDamageCH(
      Func<CharacterCombat, int, IUnit, int> orig,
      CharacterCombat self,
      int amount,
      IUnit targetUnit)
    {
      return orig(self, amount, targetUnit);
    }

    public static int WillApplyDamageEN(
      Func<EnemyCombat, int, IUnit, int> orig,
      EnemyCombat self,
      int amount,
      IUnit targetUnit)
    {
      return orig(self, amount, targetUnit);
    }

    public static void StartMenu(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
    }

    public static void InitializeCombat(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
    }

    public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
    {
      orig(self);
      SpeederHandler.ResetAll();
    }

    public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self) => orig(self);

    public static void PostNotification(
      Action<CombatManager, string, object, object> orig,
      CombatManager self,
      string call,
      object sender,
      object args)
    {
      orig(self, call, sender, args);
      EnemyCombat enemy = null;
      int num;
      if (call == ((TriggerCalls) 8).ToString() && sender is EnemyCombat)
      {
        enemy = sender as EnemyCombat;
        num = enemy != null ? 1 : 0;
      }
      else
        num = 0;
      if (num == 0)
        return;
      SpeederHandler.TickUp(enemy);
    }

    public static IEnumerator EffectActionExecute(
      Func<EffectAction, CombatStats, IEnumerator> orig,
      EffectAction self,
      CombatStats stats)
    {
      if (self._caster is CharacterCombat caster && caster.HasUsableItem && caster.HeldItem._itemName == "Throwing Darts" && caster.HeldItem._flavourText == "\"Throw them in the dark.\"")
      {
        CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(self._caster.ID, "Throwing Darts", false, ThrowingDarts.Image));
        EffectInfo[] effectInfoArray = new EffectInfo[self._effects.Length];
        for (int index = 0; index < effectInfoArray.Length && index < self._effects.Length; ++index)
          effectInfoArray[index] = new EffectInfo()
          {
            condition = self._effects[index].condition,
            targets = (BaseCombatTargettingSO) RandomTargettingByAmount.Create(self._effects[index].targets),
            effect = self._effects[index].effect,
            entryVariable = self._effects[index].entryVariable
          };
        self._effects = effectInfoArray;
      }
      return orig(self, stats);
    }

    public static string AddStoredValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      string str1;
      if (storedValue == (UnitStoredValueNames)77889 && value > 0)
      {
        string str2 = "Multiattack" + string.Format(" +{0}", (object) value);
        string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
        string str4 = "</color>";
        str1 = str3 + str2 + str4;
      }
      else if (storedValue == MortarCycleEffect.value && value > 0)
      {
        string str5 = "Targetting Slot" + string.Format(" {0}", (object) value);
        string str6 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.grey) + ">";
        string str7 = "</color>";
        str1 = str6 + str5 + str7;
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }
  }
}
