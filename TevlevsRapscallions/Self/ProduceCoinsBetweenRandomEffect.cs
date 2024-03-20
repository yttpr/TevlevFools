// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ProduceCoinsBetweenRandomEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ProduceCoinsBetweenRandomEffect : EffectSO
  {
    public int _min;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        int num = Random.Range(this._min, entryVariable);
        exitAmount = stats.TryGainCurrency(num, true);
        if (exitAmount > 0)
          CombatManager.Instance.AddUIAction((CombatAction) new PlayCurrencyEffectUIAction(caster.ID, caster.IsUnitCharacter, exitAmount, false));
      }
      return exitAmount > 0;
    }
  }
}
