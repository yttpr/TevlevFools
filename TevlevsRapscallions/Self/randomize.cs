// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.randomize
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class randomize : MonoBehaviour
  {
    public float timer = 1.25f;
    public Animator animator;

    public void Update()
    {
      this.timer -= Time.deltaTime;
      if ((double) this.timer > 0.0)
        return;
      this.timer = 1.25f;
      this.animator.SetFloat("Blend", Random.Range(0.0f, 1f));
    }
  }
}
