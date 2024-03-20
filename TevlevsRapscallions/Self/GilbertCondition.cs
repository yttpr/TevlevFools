// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GilbertCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Linq;

#nullable disable
namespace TevlevsRapscallions
{
  public class GilbertCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      IUnit caster = null;
      int num;
      if (args is StringReference stringReference && effector is IUnit)
      {
        caster = effector as IUnit;
        num = caster != null ? 1 : 0;
      }
      else
        num = 0;
      if (num == 0)
        return true;
      CombatManager.Instance.AddRootAction((CombatAction) new AddRootActionAction((CombatAction) new GilbertAction(caster, (args as StringReference).value, CombatManager.Instance._stats.EnemiesOnField.Values.ToArray<EnemyCombat>())));
      return false;
    }
  }
}
