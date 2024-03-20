// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.CasterSubActionEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class CasterSubActionEffect : EffectSO
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
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(effectInfoArray, caster, 0));
      return true;
    }

    public static CasterSubActionEffect Create(Effect[] e)
    {
      CasterSubActionEffect instance = ScriptableObject.CreateInstance<CasterSubActionEffect>();
      instance.effects = e;
      return instance;
    }
  }
}
