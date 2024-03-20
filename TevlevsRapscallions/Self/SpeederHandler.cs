// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SpeederHandler
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public static class SpeederHandler
  {
    public static UnitStoredValueNames moved => (UnitStoredValueNames) 8916004;

    public static TriggerCalls call => (TriggerCalls) SpeederHandler.moved;

    public static void ResetAll()
    {
      foreach (EnemyCombat enemyCombat in CombatManager.Instance._stats.EnemiesOnField.Values)
        enemyCombat.SetStoredValue(SpeederHandler.moved, 0);
    }

    public static void TickUp(EnemyCombat enemy)
    {
      enemy.SetStoredValue(SpeederHandler.moved, enemy.GetStoredValue(SpeederHandler.moved) + 1);
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(SpeederHandler.call.ToString(), (object) characterCombat, (object) new ObjectHolder((object) enemy));
    }
  }
}
