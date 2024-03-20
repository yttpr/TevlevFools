// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SubActionAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;

#nullable disable
namespace TevlevsRapscallions
{
  public class SubActionAction : CombatAction
  {
    public CombatAction ex;

    public SubActionAction(CombatAction a) => this.ex = a;

    public override IEnumerator Execute(CombatStats stats)
    {
      CombatManager.Instance.AddSubAction(this.ex);
      yield return (object) null;
    }
  }
}
