// Decompiled with JetBrains decompiler
// Type: randomizer
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
public class randomizer : StateMachineBehaviour
{
  public float[] nums = new float[5]
  {
    0.1f,
    0.3f,
    0.6f,
    0.8f,
    1f
  };
  public int index = 0;

  public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    int index1 = this.index;
    for (int index2 = 0; index2 < 10 && index1 == this.index; ++index2)
      this.index = Random.Range(0, 5);
    animator.SetFloat("Blend", this.nums[this.index]);
  }
}
