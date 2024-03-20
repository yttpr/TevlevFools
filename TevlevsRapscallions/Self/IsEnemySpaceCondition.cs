// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.IsEnemySpaceCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class IsEnemySpaceCondition : EffectConditionSO
  {
    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      foreach (CombatSlot enemySlot in CombatManager.Instance._stats.combatSlots.EnemySlots)
      {
        if (!enemySlot.HasUnit)
          return true;
      }
      return false;
    }
  }
}
