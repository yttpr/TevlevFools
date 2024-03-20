// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.PYMNHere
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class PYMNHere
  {
    public static AssetBundle Assets;
    public static ManaColorSO[] Mentos = new ManaColorSO[4]
    {
      Pigments.Red,
      Pigments.Blue,
      Pigments.Yellow,
      Pigments.Purple
    };

    public static void Setup()
    {
      PYMNHere.Assets = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("nutcracker"));
    }
  }
}
