// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.MultiplyFloatModifier
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System;

#nullable disable
namespace TevlevsRapscallions
{
  public class MultiplyFloatModifier : IntValueModifier
  {
    public float num;
    public bool roundUp;
    public bool doNegative;

    public MultiplyFloatModifier(float num, bool roundUp, bool dealing, bool doNegative = false)
      : base(dealing ? 20 : 70)
    {
      this.num = num;
      this.roundUp = roundUp;
      this.doNegative = doNegative;
    }

    public override int Modify(int value)
    {
      float num = (float) value * this.num;
      int val2 = this.roundUp ? (int) Math.Ceiling((double) num) : (int) Math.Floor((double) num);
      return this.doNegative ? val2 : Math.Max(0, val2);
    }
  }
}
