// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.EZEffects
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class EZEffects
  {
    public static PreviousEffectCondition DidThat<T>(bool success, int prev = 1) where T : PreviousEffectCondition
    {
      PreviousEffectCondition instance = (PreviousEffectCondition) ScriptableObject.CreateInstance<T>();
      instance.wasSuccessful = success;
      instance.previousAmount = prev;
      return instance;
    }

    public static AnimationVisualsEffect GetVisuals<T>(
      string visuals,
      bool isChara,
      BaseCombatTargettingSO targets)
      where T : AnimationVisualsEffect
    {
      AnimationVisualsEffect instance = (AnimationVisualsEffect) ScriptableObject.CreateInstance<T>();
      instance._visuals = !isChara ? LoadedAssetsHandler.GetEnemyAbility(visuals).visuals : LoadedAssetsHandler.GetCharacterAbility(visuals).visuals;
      instance._animationTarget = targets;
      return instance;
    }

    public static Targetting_ByUnit_Side TargetSide<T>(bool allies, bool allSlots, bool ignoreCast = false) where T : Targetting_ByUnit_Side
    {
      Targetting_ByUnit_Side instance = (Targetting_ByUnit_Side) ScriptableObject.CreateInstance<T>();
      instance.ignoreCastSlot = ignoreCast;
      instance.getAllies = allies;
      instance.getAllUnitSlots = allSlots;
      return instance;
    }

    public static SwapToOneSideEffect GoSide<T>(bool right) where T : SwapToOneSideEffect
    {
      SwapToOneSideEffect instance = (SwapToOneSideEffect) ScriptableObject.CreateInstance<T>();
      instance._swapRight = right;
      return instance;
    }

    public static PercentageEffectorCondition Condition<T>(int chance) where T : PercentageEffectorCondition
    {
      PercentageEffectorCondition instance = (PercentageEffectorCondition) ScriptableObject.CreateInstance<T>();
      instance.triggerPercentage = chance;
      return instance;
    }
  }
}
