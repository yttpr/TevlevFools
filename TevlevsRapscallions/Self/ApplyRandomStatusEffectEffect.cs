// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ApplyRandomStatusEffectEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ApplyRandomStatusEffectEffect : EffectSO
  {
    public static EffectSO[] effects = new EffectSO[9]
    {
       ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(),
       ScriptableObject.CreateInstance<ApplyFrailEffect>(),
       ScriptableObject.CreateInstance<ApplyScarsEffect>(),
       ScriptableObject.CreateInstance<ApplyRupturedEffect>(),
       ScriptableObject.CreateInstance<ApplyLinkedEffect>(),
       ScriptableObject.CreateInstance<ApplyCursedEffect>(),
       ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(),
       ScriptableObject.CreateInstance<ApplyFireSlotEffect>(),
       ScriptableObject.CreateInstance<ApplyBubblesEffect>()
    };
    public int _repeatAmount = 1;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      for (int index1 = 0; index1 < targets.Length; ++index1)
      {
        if (targets[index1].HasUnit)
        {
          for (int index2 = 0; index2 < this._repeatAmount; ++index2)
          {
            int num;
            ApplyRandomStatusEffectEffect.effects.GetRandom<EffectSO>().PerformEffect(stats, caster, targets[index1].SelfArray<TargetSlotInfo>(), areTargetSlots, entryVariable, out num);
            exitAmount += num;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
