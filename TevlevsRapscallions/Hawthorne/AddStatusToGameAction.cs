// Decompiled with JetBrains decompiler
// Type: Hawthorne.AddStatusToGameAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BOSpecialItems;
using System.Collections;

#nullable disable
namespace Hawthorne
{
  public class AddStatusToGameAction : CombatAction
  {
    public override IEnumerator Execute(CombatStats stats)
    {
      foreach (StatusEffectInfoSO status in stats.statusEffectDataBase.Values)
        GlossaryStuffAdder.AddStatus(status);
      foreach (SlotStatusEffectInfoSO field in stats.slotStatusEffectDataBase.Values)
        GlossaryStuffAdder.AddField(field);
      yield return (object) null;
    }
  }
}
