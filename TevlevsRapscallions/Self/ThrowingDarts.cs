// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ThrowingDarts
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class ThrowingDarts
  {
    private static Sprite image;

    public static Sprite Image
    {
      get
      {
        if (image == null)
          ThrowingDarts.image = ResourceLoader.LoadSprite("ThrowingDarts.png");
        return ThrowingDarts.image;
      }
    }
  }
}
