// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ConvertAllMungsToPartyMemberSideEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class ConvertAllMungsToPartyMemberSideEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
      {
        if (enemyCombat.IsAlive && enemyCombat.Name == "Mung")
        {
          Debug.Log((object) "silly");
          enemyCombat.UnitWillFlee();
          CombatManager.Instance.AddSubAction((CombatAction) new FleetingUnitAction(enemyCombat.ID, enemyCombat.IsUnitCharacter));
          ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
