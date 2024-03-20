// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GenericItem`1
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class GenericItem<T> : BrutalAPI.Item where T : BaseWearableSO
  {
    public T Item;

    public override BaseWearableSO Wearable()
    {
      T instance = ScriptableObject.CreateInstance<T>();
      instance.BaseWearable((BrutalAPI.Item) this);
      this.Item = instance;
      return (BaseWearableSO) instance;
    }
  }
}
