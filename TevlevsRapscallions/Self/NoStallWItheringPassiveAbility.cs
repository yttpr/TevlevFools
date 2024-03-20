// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.NoStallWItheringPassiveAbility
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class NoStallWItheringPassiveAbility : BasePassiveAbilitySO
  {
    public override bool DoesPassiveTrigger => true;

    public override bool IsPassiveImmediate => true;

    public override void TriggerPassive(object sender, object args)
    {
      if (!(sender is IUnit iunit))
        return;
      if (iunit.IsUnitCharacter)
        CombatManager.Instance.AddRootAction((CombatAction) new CharacterWitheringAction());
      else
        CombatManager.Instance.AddRootAction((CombatAction) new EnemyWitheringAction());
    }

    public override void OnPassiveConnected(IUnit unit)
    {
      if (unit.IsUnitCharacter)
        CombatManager.Instance.AddRootAction((CombatAction) new CharacterWitheringAction());
      else
        CombatManager.Instance.AddRootAction((CombatAction) new EnemyWitheringAction());
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
