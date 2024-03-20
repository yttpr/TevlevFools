// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AddRootActionAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;

#nullable disable
namespace TevlevsRapscallions
{
  public class AddRootActionAction : CombatAction
  {
    private CombatAction Add;

    public AddRootActionAction(CombatAction add) => this.Add = add;

    public override IEnumerator Execute(CombatStats stats)
    {
      CombatManager.Instance.AddRootAction(this.Add);
      yield return (object) null;
    }
  }
}
