// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.CasterOpposingTargettingSubActionEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class CasterOpposingTargettingSubActionEffect : EffectSO
  {
    public Effect[] effects;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      EffectInfo[] effectInfoArray = ExtensionMethods.ToEffectInfoArray(this.effects);
      exitAmount = 0;
      CombatManager.Instance.AddSubAction((CombatAction) new SwapSidesEffectAction(effectInfoArray, caster));
      return true;
    }

    public static CasterOpposingTargettingSubActionEffect Create(Effect[] e)
    {
      CasterOpposingTargettingSubActionEffect instance = ScriptableObject.CreateInstance<CasterOpposingTargettingSubActionEffect>();
      instance.effects = e;
      return instance;
    }
  }
}
